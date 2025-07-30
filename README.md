# 🚀 TaskFlowPro - Template Educativo

## 🎓 Para Estudiantes

**Este es un TEMPLATE REPOSITORY.** Para crear tu proyecto personal:

1. **Hacer clic en "Use this template"** (botón verde arriba)
2. **Crear tu repositorio personal**
3. **Seguir las instrucciones:** [📋 COMO-USAR-TEMPLATE.md](COMO-USAR-TEMPLATE.md)

**⚠️ NO clones este repositorio directamente. Usa el template para crear el tuyo.**

---

## 📋 Descripción del Proyecto

**TaskFlowPro** es un sistema completo de gestión de tareas y equipos desarrollado con **.NET 9**, **Blazor Server** y **Tailwind CSS**. Una aplicación moderna para organizar equipos, asignar tareas y gestionar proyectos de manera eficiente.

## 🎯 Características Principales

- ✅ **Gestión de Tareas** - Crear, asignar y seguir el progreso de tareas
- ✅ **Equipos de Trabajo** - Organizar usuarios en equipos colaborativos
- ✅ **Roles y Permisos** - Sistema de autenticación con diferentes niveles de acceso
- ✅ **Interfaz Moderna** - Diseño responsive con Tailwind CSS
- ✅ **Tiempo Real** - Actualizaciones en vivo con Blazor Server

## 🛠️ Tecnologías Utilizadas

- **.NET 9** - Framework principal
- **Blazor Server** - Frontend interactivo
- **Tailwind CSS** - Framework de estilos utilitarios
- **Entity Framework Core** - ORM para base de datos
- **Clean Architecture** - Patrón arquitectónico
- **Font Awesome** - Iconografía

## 🚀 Configuración e Instalación

### **Prerrequisitos**
Antes de comenzar, asegúrate de tener instalado:

- **.NET 9 SDK** - [Descargar aquí](https://dotnet.microsoft.com/download/dotnet/9.0)
- **Node.js 18+** - [Descargar aquí](https://nodejs.org/) (necesario para Tailwind CSS)
- **Visual Studio 2022** o **Visual Studio Code**
- **Git** para clonar el repositorio

### **Paso 1: Clonar el Repositorio**
```bash
git clone [URL_DEL_REPOSITORIO]
cd TaskFlowPro-Estudiantes
```

### **Paso 2: Restaurar Dependencias de .NET**
```bash
dotnet restore
```

### **Paso 3: Configurar Tailwind CSS**
```bash
# Navegar al directorio del frontend
cd Frontend/TaskFlowPro.Web

# Instalar dependencias de Node.js
npm install

# Compilar estilos de Tailwind CSS
npm run build-css
```

### **Paso 4: Ejecutar la Aplicación**
```bash
# Desde el directorio Frontend/TaskFlowPro.Web
dotnet run --urls "https://localhost:7001"
```

### **Paso 5: Abrir en el Navegador**
Abre tu navegador y ve a: **https://localhost:7001**

## 🔧 Desarrollo con Tailwind CSS

Para desarrollo activo con recompilación automática de estilos:

### **Opción 1: Script Automático (Recomendado)**
```bash
cd Frontend/TaskFlowPro.Web
.\start-dev.ps1
```

### **Opción 2: Manual (2 terminales)**
```bash
# Terminal 1 - Tailwind Watch (detecta cambios automáticamente)
cd Frontend/TaskFlowPro.Web
npx tailwindcss -i ./Styles/app.css -o ./wwwroot/css/app.css --watch

# Terminal 2 - Aplicación Blazor
cd Frontend/TaskFlowPro.Web
dotnet run --urls "https://localhost:7001"
```

**Nota**: El modo watch de Tailwind detecta cambios en archivos `.razor` y recompila automáticamente los estilos.

## 🎨 Sistema de Diseño

### **Colores Principales**
```css
--primary: #0891b2;     /* Teal vibrante */
--secondary: #f97316;   /* Naranja cálido */
--accent: #65a30d;      /* Verde lima */
```

### **Estructura del Proyecto**
```
📁 TaskFlowPro.Web/
├── 📁 Components/
│   ├── 📁 UI/              # Componentes reutilizables
│   └── 📁 Layout/          # Componentes de layout
├── 📁 Features/            # Funcionalidades por módulo
│   ├── 📁 Auth/            # Autenticación
│   ├── 📁 Tasks/           # Gestión de tareas
│   ├── 📁 Users/           # Gestión de usuarios
│   └── 📁 Teams/           # Gestión de equipos
├── 📁 Services/            # Servicios de la aplicación
├── 📁 Styles/              # Archivos fuente de Tailwind
└── 📁 wwwroot/             # Archivos estáticos
```

## 🔧 Comandos Útiles

```bash
# Compilar estilos una sola vez
npm run build-css

# Limpiar y reconstruir proyecto
dotnet clean
dotnet build

# Restaurar paquetes NuGet
dotnet restore

# Reinstalar dependencias de Node.js
rm -rf node_modules package-lock.json
npm install
```

## 🐛 Solución de Problemas

### **Los estilos no se cargan**
1. Verificar que `wwwroot/css/app.css` existe
2. Ejecutar `npm run build-css`
3. Limpiar caché del navegador (Ctrl+F5)

### **Error al compilar Tailwind**
1. Verificar que Node.js está instalado: `node --version`
2. Reinstalar dependencias: `npm install`
3. Ejecutar manualmente: `npx tailwindcss -i ./Styles/app.css -o ./wwwroot/css/app.css`

### **Puerto en uso**
Si el puerto 7001 está ocupado, cambiar en el comando:
```bash
dotnet run --urls "https://localhost:7002"
```

## 📚 Recursos Adicionales

- **Blazor**: [Documentación oficial](https://docs.microsoft.com/en-us/aspnet/core/blazor/)
- **Tailwind CSS**: [Documentación](https://tailwindcss.com/docs)
- **Font Awesome**: [Iconos](https://fontawesome.com/icons)

##  Funcionalidades del Sistema

- **Dashboard** - Vista general de tareas y equipos
- **Gestión de Tareas** - CRUD completo de tareas
- **Gestión de Usuarios** - Administración de usuarios y roles
- **Gestión de Equipos** - Organización de equipos de trabajo
- **Autenticación** - Sistema de login con roles diferenciados

¡Disfruta desarrollando con TaskFlowPro! 
