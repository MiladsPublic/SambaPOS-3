#!/bin/bash

# SambaPOS Web Deployment Script

echo "Starting SambaPOS Web Application..."

# Function to check if a port is in use
check_port() {
    if lsof -Pi :$1 -sTCP:LISTEN -t >/dev/null ; then
        echo "Port $1 is already in use"
        return 1
    else
        return 0
    fi
}

# Check ports
echo "Checking ports..."
if ! check_port 5000; then
    echo "Port 5000 (Web API) is already in use. Please stop the service or choose a different port."
    exit 1
fi

if ! check_port 5001; then
    echo "Port 5001 (Web App) is already in use. Please stop the service or choose a different port."
    exit 1
fi

echo "Building applications..."

# Build Web API
echo "Building Web API..."
cd Samba.WebApi
dotnet build --configuration Release
if [ $? -ne 0 ]; then
    echo "Failed to build Web API"
    exit 1
fi

# Build Web App
echo "Building Web App..."
cd ../Samba.WebApp
dotnet build --configuration Release
if [ $? -ne 0 ]; then
    echo "Failed to build Web App"
    exit 1
fi

cd ..

echo "Starting services..."

# Start Web API in background
echo "Starting Web API on http://localhost:5000..."
cd Samba.WebApi
dotnet run --urls=http://localhost:5000 --configuration Release &
WEBAPI_PID=$!
echo "Web API started with PID $WEBAPI_PID"

# Wait a moment for the API to start
sleep 5

# Start Web App in background
echo "Starting Web App on http://localhost:5001..."
cd ../Samba.WebApp
dotnet run --urls=http://localhost:5001 --configuration Release &
WEBAPP_PID=$!
echo "Web App started with PID $WEBAPP_PID"

cd ..

echo ""
echo "====================================="
echo "SambaPOS Web Application is running!"
echo "====================================="
echo ""
echo "Web Application: http://localhost:5001"
echo "API Documentation: http://localhost:5000/swagger"
echo ""
echo "Press Ctrl+C to stop both services"
echo ""

# Function to cleanup processes on exit
cleanup() {
    echo ""
    echo "Stopping services..."
    kill $WEBAPI_PID 2>/dev/null
    kill $WEBAPP_PID 2>/dev/null
    echo "Services stopped."
    exit 0
}

# Trap SIGINT (Ctrl+C) and SIGTERM
trap cleanup SIGINT SIGTERM

# Wait for both processes
wait $WEBAPI_PID $WEBAPP_PID