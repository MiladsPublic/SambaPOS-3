@echo off
echo Starting SambaPOS Web Application...

echo Building applications...

echo Building Web API...
cd Samba.WebApi
dotnet build --configuration Release
if %errorlevel% neq 0 (
    echo Failed to build Web API
    pause
    exit /b 1
)

echo Building Web App...
cd ..\Samba.WebApp
dotnet build --configuration Release
if %errorlevel% neq 0 (
    echo Failed to build Web App
    pause
    exit /b 1
)

cd ..

echo Starting services...

echo Starting Web API on http://localhost:5000...
start "SambaPOS Web API" cmd /k "cd Samba.WebApi && dotnet run --urls=http://localhost:5000 --configuration Release"

timeout /t 5 /nobreak > nul

echo Starting Web App on http://localhost:5001...
start "SambaPOS Web App" cmd /k "cd Samba.WebApp && dotnet run --urls=http://localhost:5001 --configuration Release"

echo.
echo =====================================
echo SambaPOS Web Application is running!
echo =====================================
echo.
echo Web Application: http://localhost:5001
echo API Documentation: http://localhost:5000/swagger
echo.
echo Close the command windows to stop the services
echo.

pause