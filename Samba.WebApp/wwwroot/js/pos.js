// POS JavaScript functionality
class POSSystem {
    constructor() {
        this.currentOrder = [];
        this.apiBaseUrl = 'http://localhost:5000/api'; // Update with actual API URL
        this.init();
    }

    init() {
        this.bindEvents();
        this.loadMenuItems();
    }

    bindEvents() {
        // Menu item click handlers
        document.querySelectorAll('.menu-item-btn').forEach(btn => {
            btn.addEventListener('click', (e) => this.addToOrder(e));
        });

        // Category filter handlers
        document.querySelectorAll('.category-btn').forEach(btn => {
            btn.addEventListener('click', (e) => this.filterByCategory(e));
        });
    }

    addToOrder(event) {
        const btn = event.currentTarget;
        const itemId = btn.dataset.itemId;
        const itemName = btn.dataset.name;
        const itemPrice = parseFloat(btn.dataset.price);

        // Check if item already exists in order
        const existingItem = this.currentOrder.find(item => item.id === itemId);
        
        if (existingItem) {
            existingItem.quantity += 1;
            existingItem.total = existingItem.quantity * existingItem.price;
        } else {
            this.currentOrder.push({
                id: itemId,
                name: itemName,
                price: itemPrice,
                quantity: 1,
                total: itemPrice
            });
        }

        this.updateOrderDisplay();
        this.updateTotals();
    }

    removeFromOrder(itemId) {
        this.currentOrder = this.currentOrder.filter(item => item.id !== itemId);
        this.updateOrderDisplay();
        this.updateTotals();
    }

    updateQuantity(itemId, newQuantity) {
        const item = this.currentOrder.find(item => item.id === itemId);
        if (item) {
            if (newQuantity <= 0) {
                this.removeFromOrder(itemId);
            } else {
                item.quantity = newQuantity;
                item.total = item.quantity * item.price;
                this.updateOrderDisplay();
                this.updateTotals();
            }
        }
    }

    updateOrderDisplay() {
        const orderItemsContainer = document.getElementById('orderItems');
        
        if (this.currentOrder.length === 0) {
            orderItemsContainer.innerHTML = `
                <div class="text-center text-muted py-5">
                    <i class="fas fa-shopping-cart fa-3x mb-3"></i>
                    <p>No items in current order</p>
                </div>
            `;
            document.getElementById('holdBtn').disabled = true;
            document.getElementById('payBtn').disabled = true;
        } else {
            let html = '';
            this.currentOrder.forEach(item => {
                html += `
                    <div class="order-item mb-3 p-2 border rounded">
                        <div class="d-flex justify-content-between align-items-center">
                            <div>
                                <div class="fw-bold">${item.name}</div>
                                <div class="text-muted">$${item.price.toFixed(2)} each</div>
                            </div>
                            <div class="d-flex align-items-center">
                                <button class="btn btn-sm btn-outline-secondary me-2" onclick="pos.updateQuantity('${item.id}', ${item.quantity - 1})">-</button>
                                <span class="mx-2">${item.quantity}</span>
                                <button class="btn btn-sm btn-outline-secondary me-2" onclick="pos.updateQuantity('${item.id}', ${item.quantity + 1})">+</button>
                                <div class="fw-bold me-2">$${item.total.toFixed(2)}</div>
                                <button class="btn btn-sm btn-outline-danger" onclick="pos.removeFromOrder('${item.id}')">×</button>
                            </div>
                        </div>
                    </div>
                `;
            });
            orderItemsContainer.innerHTML = html;
            document.getElementById('holdBtn').disabled = false;
            document.getElementById('payBtn').disabled = false;
        }
    }

    updateTotals() {
        const subtotal = this.currentOrder.reduce((sum, item) => sum + item.total, 0);
        const taxRate = 0.08; // 8% tax
        const tax = subtotal * taxRate;
        const total = subtotal + tax;

        document.getElementById('subtotal').textContent = `$${subtotal.toFixed(2)}`;
        document.getElementById('tax').textContent = `$${tax.toFixed(2)}`;
        document.getElementById('total').textContent = `$${total.toFixed(2)}`;
    }

    filterByCategory(event) {
        const btn = event.currentTarget;
        const category = btn.dataset.category;
        
        // Update active category button
        document.querySelectorAll('.category-btn').forEach(b => b.classList.remove('active'));
        btn.classList.add('active');

        // Filter menu items (in a real implementation, this would filter the actual menu data)
        // For now, this is a placeholder
        console.log(`Filtering by category: ${category}`);
    }

    async loadMenuItems() {
        try {
            // In a real implementation, load from API
            // const response = await fetch(`${this.apiBaseUrl}/menu/screens`);
            // const menuData = await response.json();
            
            // For now, menu items are already in the HTML
            console.log('Menu items loaded');
        } catch (error) {
            console.error('Error loading menu items:', error);
        }
    }

    newTicket() {
        if (this.currentOrder.length > 0) {
            if (confirm('Current order will be lost. Are you sure?')) {
                this.currentOrder = [];
                this.updateOrderDisplay();
                this.updateTotals();
            }
        }
    }

    holdTicket() {
        if (this.currentOrder.length > 0) {
            // In a real implementation, save the ticket to backend
            alert('Ticket held successfully');
            this.currentOrder = [];
            this.updateOrderDisplay();
            this.updateTotals();
        }
    }

    showPaymentModal() {
        if (this.currentOrder.length > 0) {
            const total = this.currentOrder.reduce((sum, item) => sum + item.total, 0) * 1.08; // Including tax
            document.getElementById('paymentTotal').textContent = `$${total.toFixed(2)}`;
            
            const modal = new bootstrap.Modal(document.getElementById('paymentModal'));
            modal.show();
        }
    }

    async processPayment(paymentType) {
        try {
            // In a real implementation, process payment via API
            const total = this.currentOrder.reduce((sum, item) => sum + item.total, 0) * 1.08;
            
            // Simulate payment processing
            await new Promise(resolve => setTimeout(resolve, 1000));
            
            alert(`Payment of $${total.toFixed(2)} processed successfully via ${paymentType}`);
            
            // Clear order and close modal
            this.currentOrder = [];
            this.updateOrderDisplay();
            this.updateTotals();
            
            const modal = bootstrap.Modal.getInstance(document.getElementById('paymentModal'));
            modal.hide();
            
        } catch (error) {
            console.error('Payment processing error:', error);
            alert('Payment processing failed. Please try again.');
        }
    }
}

// Initialize POS system
let pos;
document.addEventListener('DOMContentLoaded', function() {
    pos = new POSSystem();
});

// Global functions for HTML onclick handlers
function newTicket() {
    pos.newTicket();
}

function holdTicket() {
    pos.holdTicket();
}

function showPaymentModal() {
    pos.showPaymentModal();
}

function processPayment(paymentType) {
    pos.processPayment(paymentType);
}

function logout() {
    if (confirm('Are you sure you want to logout?')) {
        // In a real implementation, clear session and redirect to login
        window.location.href = '/login';
    }
}