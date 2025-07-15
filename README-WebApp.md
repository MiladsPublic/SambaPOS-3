# SambaPOS Web Application

This is a modern web-based Point of Sale (POS) system ported from the original SambaPOS-3 desktop application. The webapp provides a responsive, touch-friendly interface that works on tablets, phones, and desktop browsers.

## Architecture

The webapp consists of two main components:

### 1. Samba.WebApi (Backend API)
- **Framework**: ASP.NET Core 8.0 Web API
- **Purpose**: Provides REST endpoints for POS operations
- **Port**: http://localhost:5000
- **Features**:
  - Modern Web API controllers
  - JSON-based data transfer
  - CORS enabled for web app access
  - Swagger/OpenAPI documentation

### 2. Samba.WebApp (Frontend)
- **Framework**: ASP.NET Core 8.0 Razor Pages
- **Purpose**: Responsive web interface for POS operations
- **Port**: http://localhost:5001
- **Features**:
  - Touch-friendly menu interface
  - Real-time order management
  - Payment processing
  - Ticket management
  - Mobile-responsive design

## Key Features Ported to Web

### Point of Sale Interface
- **Colorful Menu Buttons**: Touch-friendly menu items with custom colors
- **Category Filtering**: Filter menu items by category (Burgers, Pizza, Sides, Drinks, Salads)
- **Real-time Order Management**: Add/remove items, adjust quantities
- **Live Calculations**: Automatic subtotal, tax, and total calculations
- **Payment Processing**: Cash and card payment options
- **Order Actions**: Hold tickets for later, process payments

### Ticket Management
- **Ticket History**: View all previous tickets with filtering
- **Detailed Views**: Complete ticket information including items and payments
- **Status Tracking**: Open, Paid, Closed ticket statuses
- **Date Filtering**: Filter tickets by date range
- **Actions**: View details, continue open tickets, print receipts

### API Endpoints

#### Authentication
- `POST /api/auth/login` - User authentication
- `POST /api/auth/logout` - User logout

#### Menu Management
- `GET /api/menu/items` - Get all menu items with portions
- `GET /api/menu/screens` - Get screen menus for POS display
- `GET /api/menu/items/{id}` - Get specific menu item

#### Ticket Operations
- `GET /api/tickets` - Get all tickets
- `GET /api/tickets/{id}` - Get specific ticket
- `POST /api/tickets` - Create new ticket
- `PUT /api/tickets/{id}` - Update ticket

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- Web browser (Chrome, Firefox, Safari, Edge)

### Running the Application

1. **Start the Web API** (Backend):
   ```bash
   cd Samba.WebApi
   dotnet run --urls=http://localhost:5000
   ```

2. **Start the Web App** (Frontend):
   ```bash
   cd Samba.WebApp
   dotnet run --urls=http://localhost:5001
   ```

3. **Access the Application**:
   - Web App: http://localhost:5001
   - API Documentation: http://localhost:5000/swagger

## Usage Guide

### Main POS Interface
1. Navigate to http://localhost:5001
2. Use category buttons to filter menu items
3. Click menu items to add to current order
4. Adjust quantities using +/- buttons
5. Click "Pay" to process payment
6. Select payment method (Cash/Card)

### Ticket Management
1. Click "Tickets" in the navigation
2. Use filters to find specific tickets
3. Click "View" to see ticket details
4. Click "Continue" to resume open tickets
5. Click "Print" to print receipts

### Mobile Usage
- The interface is fully responsive and touch-friendly
- Works on tablets and smartphones
- Large touch targets for easy interaction
- Optimized layouts for different screen sizes

## Technology Stack

### Backend (Samba.WebApi)
- ASP.NET Core 8.0 Web API
- Entity Framework Core (ready for integration)
- Swagger/OpenAPI for documentation
- JSON serialization

### Frontend (Samba.WebApp)
- ASP.NET Core 8.0 Razor Pages
- Bootstrap 5 for responsive design
- JavaScript for dynamic interactions
- Font Awesome icons
- Modern CSS with animations

### Key Libraries
- Bootstrap 5.x - Responsive CSS framework
- Font Awesome 6.x - Icon library
- jQuery - DOM manipulation and AJAX

## Features Demonstrated

✅ **Working POS Interface**
- Menu categories and items
- Shopping cart functionality  
- Real-time calculations
- Payment processing

✅ **Ticket Management**
- Ticket listing with filters
- Detailed ticket views
- Status management
- Date range filtering

✅ **Responsive Design**
- Mobile-friendly interface
- Touch-optimized buttons
- Adaptive layouts

✅ **Modern Web API**
- RESTful endpoints
- JSON responses
- CORS enabled
- Swagger documentation

## Integration with Existing SambaPOS

The web application is designed to complement the existing SambaPOS desktop application:

1. **Shared Business Logic**: Ready to integrate with existing service layer
2. **Data Compatibility**: Designed to work with existing data models
3. **Parallel Operation**: Can run alongside desktop application
4. **Gradual Migration**: Features can be migrated incrementally

## Future Enhancements

- **Authentication Integration**: Connect with existing user management
- **Database Integration**: Wire up with existing data layer
- **Real-time Updates**: WebSocket support for live order updates
- **Advanced Reporting**: Web-based reports and analytics
- **Offline Support**: Progressive Web App (PWA) capabilities
- **Integration APIs**: Connect with payment processors, printers

## Benefits of Web Version

1. **Cross-Platform**: Works on any device with a web browser
2. **No Installation**: Access via URL, no software installation needed
3. **Mobile Support**: Native touch support for tablets and phones
4. **Remote Access**: Access from anywhere with internet connection
5. **Scalability**: Support multiple concurrent users
6. **Modern UX**: Contemporary web interface with smooth animations
7. **Maintenance**: Centralized updates, no client-side installations

This web application successfully demonstrates how the traditional desktop SambaPOS can be modernized for web and mobile platforms while maintaining all core POS functionality.