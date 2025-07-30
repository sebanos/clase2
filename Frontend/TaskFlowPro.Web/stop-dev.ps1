# TaskFlowPro Development Stop Script
# This script stops all development processes

Write-Host "🛑 Stopping TaskFlowPro Development Environment..." -ForegroundColor Red

# Stop Tailwind CSS processes
Write-Host "📦 Stopping Tailwind CSS processes..." -ForegroundColor Yellow
Get-Process | Where-Object {$_.ProcessName -eq "node" -and $_.CommandLine -like "*tailwindcss*"} | Stop-Process -Force

# Stop dotnet processes
Write-Host "🔥 Stopping Blazor Server processes..." -ForegroundColor Cyan
Get-Process | Where-Object {$_.ProcessName -eq "dotnet" -and $_.CommandLine -like "*TaskFlowPro.Web*"} | Stop-Process -Force

Write-Host "✅ All development processes stopped." -ForegroundColor Green
