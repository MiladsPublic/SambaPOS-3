// Tickets page functionality
class TicketsManager {
    constructor() {
        this.apiBaseUrl = 'http://localhost:5000/api'; // Update with actual API URL
        this.init();
    }

    init() {
        this.loadTickets();
        this.setDefaultDates();
    }

    setDefaultDates() {
        const today = new Date().toISOString().split('T')[0];
        const weekAgo = new Date(Date.now() - 7 * 24 * 60 * 60 * 1000).toISOString().split('T')[0];
        
        document.getElementById('dateFrom').value = weekAgo;
        document.getElementById('dateTo').value = today;
    }

    async loadTickets(filters = {}) {
        try {
            // In a real implementation, load from API with filters
            // const queryParams = new URLSearchParams(filters);
            // const response = await fetch(`${this.apiBaseUrl}/tickets?${queryParams}`);
            // const tickets = await response.json();
            
            // For now, use sample data
            const tickets = [
                {
                    id: 1,
                    ticketNumber: 'T001',
                    date: '2025-01-15 10:30',
                    itemCount: 3,
                    total: 25.50,
                    status: 'Paid'
                },
                {
                    id: 2,
                    ticketNumber: 'T002',
                    date: '2025-01-15 11:15',
                    itemCount: 1,
                    total: 12.00,
                    status: 'Open'
                },
                {
                    id: 3,
                    ticketNumber: 'T003',
                    date: '2025-01-15 12:00',
                    itemCount: 2,
                    total: 18.50,
                    status: 'Paid'
                }
            ];
            
            this.displayTickets(tickets);
        } catch (error) {
            console.error('Error loading tickets:', error);
            alert('Failed to load tickets');
        }
    }

    displayTickets(tickets) {
        const tbody = document.getElementById('ticketsTableBody');
        
        if (tickets.length === 0) {
            tbody.innerHTML = '<tr><td colspan="6" class="text-center text-muted">No tickets found</td></tr>';
            return;
        }

        tbody.innerHTML = tickets.map(ticket => `
            <tr>
                <td>${ticket.ticketNumber}</td>
                <td>${ticket.date}</td>
                <td>${ticket.itemCount}</td>
                <td>$${ticket.total.toFixed(2)}</td>
                <td>
                    <span class="badge ${this.getStatusBadgeClass(ticket.status)}">
                        ${ticket.status}
                    </span>
                </td>
                <td>
                    <button class="btn btn-sm btn-outline-primary me-1" onclick="ticketsManager.viewTicket(${ticket.id})">
                        <i class="fas fa-eye"></i> View
                    </button>
                    ${ticket.status === 'Open' ? 
                        `<button class="btn btn-sm btn-outline-success me-1" onclick="ticketsManager.continueTicket(${ticket.id})">
                            <i class="fas fa-play"></i> Continue
                        </button>` : ''
                    }
                    <button class="btn btn-sm btn-outline-secondary" onclick="ticketsManager.printTicket(${ticket.id})">
                        <i class="fas fa-print"></i> Print
                    </button>
                </td>
            </tr>
        `).join('');
    }

    getStatusBadgeClass(status) {
        switch (status.toLowerCase()) {
            case 'paid':
                return 'bg-success';
            case 'open':
                return 'bg-warning';
            case 'closed':
                return 'bg-secondary';
            default:
                return 'bg-secondary';
        }
    }

    async viewTicket(ticketId) {
        try {
            // In a real implementation, fetch ticket details from API
            // const response = await fetch(`${this.apiBaseUrl}/tickets/${ticketId}`);
            // const ticket = await response.json();
            
            // Sample ticket data
            const ticket = {
                id: ticketId,
                ticketNumber: `T${ticketId.toString().padStart(3, '0')}`,
                date: '2025-01-15 10:30',
                status: 'Paid',
                orders: [
                    { name: 'Cheeseburger', quantity: 1, price: 15.50, total: 15.50 },
                    { name: 'French Fries', quantity: 1, price: 5.00, total: 5.00 },
                    { name: 'Coca Cola', quantity: 1, price: 5.00, total: 5.00 }
                ],
                payments: [
                    { type: 'Cash', amount: 25.50, date: '2025-01-15 10:35' }
                ],
                subtotal: 25.50,
                tax: 2.04,
                total: 27.54
            };

            this.showTicketDetailModal(ticket);
        } catch (error) {
            console.error('Error loading ticket details:', error);
            alert('Failed to load ticket details');
        }
    }

    showTicketDetailModal(ticket) {
        const content = document.getElementById('ticketDetailContent');
        
        content.innerHTML = `
            <div class="row">
                <div class="col-md-6">
                    <h6>Ticket Information</h6>
                    <table class="table table-sm">
                        <tr><td>Ticket #:</td><td>${ticket.ticketNumber}</td></tr>
                        <tr><td>Date:</td><td>${ticket.date}</td></tr>
                        <tr><td>Status:</td><td><span class="badge ${this.getStatusBadgeClass(ticket.status)}">${ticket.status}</span></td></tr>
                    </table>
                </div>
                <div class="col-md-6">
                    <h6>Summary</h6>
                    <table class="table table-sm">
                        <tr><td>Subtotal:</td><td>$${ticket.subtotal.toFixed(2)}</td></tr>
                        <tr><td>Tax:</td><td>$${ticket.tax.toFixed(2)}</td></tr>
                        <tr><td><strong>Total:</strong></td><td><strong>$${ticket.total.toFixed(2)}</strong></td></tr>
                    </table>
                </div>
            </div>
            
            <h6>Order Items</h6>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Item</th>
                        <th>Qty</th>
                        <th>Price</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    ${ticket.orders.map(order => `
                        <tr>
                            <td>${order.name}</td>
                            <td>${order.quantity}</td>
                            <td>$${order.price.toFixed(2)}</td>
                            <td>$${order.total.toFixed(2)}</td>
                        </tr>
                    `).join('')}
                </tbody>
            </table>
            
            <h6>Payments</h6>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Type</th>
                        <th>Amount</th>
                        <th>Date</th>
                    </tr>
                </thead>
                <tbody>
                    ${ticket.payments.map(payment => `
                        <tr>
                            <td>${payment.type}</td>
                            <td>$${payment.amount.toFixed(2)}</td>
                            <td>${payment.date}</td>
                        </tr>
                    `).join('')}
                </tbody>
            </table>
        `;

        const modal = new bootstrap.Modal(document.getElementById('ticketDetailModal'));
        modal.show();
    }

    continueTicket(ticketId) {
        // In a real implementation, load the ticket into the POS interface
        if (confirm('Continue with this ticket in POS?')) {
            window.location.href = `/?ticket=${ticketId}`;
        }
    }

    printTicket(ticketId) {
        // In a real implementation, send to printer
        alert(`Printing ticket ${ticketId}...`);
    }

    printTicketFromModal() {
        alert('Printing ticket...');
    }

    filterTickets() {
        const status = document.getElementById('statusFilter').value;
        const dateFrom = document.getElementById('dateFrom').value;
        const dateTo = document.getElementById('dateTo').value;

        const filters = {};
        if (status) filters.status = status;
        if (dateFrom) filters.dateFrom = dateFrom;
        if (dateTo) filters.dateTo = dateTo;

        this.loadTickets(filters);
    }

    refreshTickets() {
        this.loadTickets();
    }
}

// Initialize tickets manager
let ticketsManager;
document.addEventListener('DOMContentLoaded', function() {
    ticketsManager = new TicketsManager();
});

// Global functions for HTML onclick handlers
function refreshTickets() {
    ticketsManager.refreshTickets();
}

function filterTickets() {
    ticketsManager.filterTickets();
}

function viewTicket(ticketId) {
    ticketsManager.viewTicket(ticketId);
}

function continueTicket(ticketId) {
    ticketsManager.continueTicket(ticketId);
}

function printTicket(ticketId) {
    ticketsManager.printTicket(ticketId);
}

function printTicketFromModal() {
    ticketsManager.printTicketFromModal();
}