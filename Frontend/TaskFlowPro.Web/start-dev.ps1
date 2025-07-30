# TaskFlowPro Development Startup Script
# This script starts both Tailwind CSS watch and the Blazor application

Write-Host "🚀 Starting TaskFlowPro Development Environment..." -ForegroundColor Green

# Start Tailwind CSS in watch mode
Write-Host "📦 Starting Tailwind CSS watch..." -ForegroundColor Yellow
Start-Process powershell -ArgumentList "-NoExit", "-Command", "npx tailwindcss -i ./Styles/app.css -o ./wwwroot/css/app.css --watch"

# Wait a moment for Tailwind to start
Start-Sleep -Seconds 2

# Start the Blazor application
Write-Host "🔥 Starting Blazor Server application..." -ForegroundColor Cyan
dotnet run --urls "https://localhost:7001"
