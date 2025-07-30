# 🎨 TaskFlowPro Frontend - Blazor Server

## 🚀 Quick Start

### Prerequisites
- **.NET 9 SDK**
- **Node.js 18+** (for Tailwind CSS)
- **npm** (comes with Node.js)

### 🔧 Setup

1. **Install Node.js dependencies:**
   ```bash
   npm install
   ```

2. **Compile Tailwind CSS:**
   ```bash
   npm run build-css
   ```

3. **Run the application:**
   ```bash
   dotnet run --urls "https://localhost:7001"
   ```

### 🎯 Development Mode

For development with **automatic CSS compilation**, use one of these options:

#### Option 1: PowerShell Script (Recommended)
```powershell
.\start-dev.ps1
```

#### Option 2: Manual (Two terminals)

**Terminal 1 - Tailwind Watch:**
```bash
npx tailwindcss -i ./Styles/app.css -o ./wwwroot/css/app.css --watch
```

**Terminal 2 - Blazor App:**
```bash
dotnet run --urls "https://localhost:7001"
```

### 🛑 Stop Development
```powershell
.\stop-dev.ps1
```

## 🎨 Styling System

### **Tailwind CSS Configuration**
- **Input:** `Styles/app.css`
- **Output:** `wwwroot/css/app.css`
- **Config:** `tailwind.config.js`

### **Custom Design System**
The app uses a custom design system with:
- **Primary:** `#0891b2` (Teal)
- **Secondary:** `#f97316` (Orange)
- **Accent:** `#65a30d` (Lime Green)
- **Status Colors:** Success, Warning, Error, Pending

### **Component Classes**
- `.nav-button` - Navigation buttons
- `.page-title` - Page titles with gradient
- `.create-button` - Action buttons with animations
- `.card-title` - Card headers
- `.icon-container` - Icon containers with glow effect

## 📁 Project Structure

```
📁 TaskFlowPro.Web/
├── 📁 Components/
│   ├── 📁 UI/              # Reusable UI components
│   └── 📁 Layout/          # Layout components
├── 📁 Features/
│   ├── 📁 Auth/            # Authentication
│   ├── 📁 Tasks/           # Task management
│   ├── 📁 Users/           # User management
│   └── 📁 Teams/           # Team management
├── 📁 Services/            # Application services
├── 📁 Styles/              # Tailwind source files
├── 📁 wwwroot/css/         # Compiled CSS output
├── package.json            # Node.js dependencies
└── tailwind.config.js      # Tailwind configuration
```

## 🔧 Available Scripts

```json
{
  "build-css": "tailwindcss -i ./Styles/app.css -o ./wwwroot/css/app.css --watch"
}
```

## 🎯 Features

- ✅ **Blazor Server** with SignalR
- ✅ **Tailwind CSS** with custom design system
- ✅ **Component-based architecture**
- ✅ **Code-behind pattern**
- ✅ **Responsive design**
- ✅ **Font Awesome icons**
- ✅ **Custom animations**
- ✅ **Mock data service**

## 🌐 URLs

- **Development:** https://localhost:7001
- **API Documentation:** https://localhost:7001/scalar/v1

## 🔍 Troubleshooting

### CSS Not Loading?
1. Ensure Tailwind is compiled: `npm run build-css`
2. Check `wwwroot/css/app.css` exists
3. Verify `_Layout.cshtml` includes the CSS file

### Styles Not Updating?
1. Make sure Tailwind watch is running
2. Check browser cache (Ctrl+F5)
3. Verify file changes are being detected

### Build Errors?
1. Run `dotnet clean` and `dotnet build`
2. Check for syntax errors in `.razor` files
3. Ensure all dependencies are installed

## 📚 Documentation

- [Blazor Documentation](https://docs.microsoft.com/en-us/aspnet/core/blazor/)
- [Tailwind CSS Documentation](https://tailwindcss.com/docs)
- [Font Awesome Icons](https://fontawesome.com/icons)
