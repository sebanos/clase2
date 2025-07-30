# 🗄️ TaskFlowPro Database Kit

## 📋 Descripción

Este kit contiene todo lo necesario para configurar la base de datos de **TaskFlowPro**. Incluye scripts de creación, datos de prueba y configuraciones necesarias para que el proyecto funcione correctamente.

## ⚠️ IMPORTANTE - Leer Antes de Continuar

**Este paso es OBLIGATORIO antes de ejecutar la aplicación.** Sin una base de datos configurada correctamente, la aplicación no funcionará.

## 📋 Prerrequisitos

Antes de comenzar, asegúrate de tener:

- **SQL Server** instalado (LocalDB, Express, Developer o Standard)
- **SQL Server Management Studio (SSMS)** o **Azure Data Studio**
- **Permisos de administrador** en SQL Server

## 🚀 Opción 1: Configuración Rápida (Recomendada)

### **Paso 1: Verificar SQL Server**

Abre **SQL Server Management Studio** y conéctate con:

- **Servidor**: `localhost` o `localhost\SQLEXPRESS`
- **Autenticación**: Windows Authentication o SQL Server Authentication

### **Paso 2: Crear Base de Datos**

Ejecuta este script en SSMS:

```sql
-- Crear base de datos
CREATE DATABASE TaskFlowProDB;
GO

-- Usar la base de datos
USE TaskFlowProDB;
GO

-- Verificar que se creó correctamente
SELECT name FROM sys.databases WHERE name = 'TaskFlowProDB';
```

### **Paso 3: Crear Usuario (Si usas SQL Authentication)**

```sql
-- Crear login
CREATE LOGIN taskflow_admin WITH PASSWORD = 'TaskFlow2024!';
GO

-- Crear usuario en la base de datos
USE TaskFlowProDB;
CREATE USER taskflow_admin FOR LOGIN taskflow_admin;
GO

-- Dar permisos
ALTER ROLE db_owner ADD MEMBER taskflow_admin;
GO
```

### **Paso 4: Configurar Cadena de Conexión**

En tu proyecto, edita `Backend/TaskFlowPro.Api/appsettings.json`:

**Para Windows Authentication:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TaskFlowProDB;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true"
  }
}
```

**Para SQL Authentication:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=TaskFlowProDB;User Id=sa;Password=TaskFlow2024!;TrustServerCertificate=true;MultipleActiveResultSets=true"
  }
}
```

### **Paso 5: Ejecutar Migraciones**

Desde la carpeta raíz del proyecto:

```bash
# Restaurar paquetes
dotnet restore

# Ejecutar migraciones
dotnet ef database update --project Backend/TaskFlowPro.Persistence --startup-project Backend/TaskFlowPro.Api
```

### **Paso 6: Verificar Instalación**

Ejecuta la aplicación y visita:
```
GET https://localhost:7001/api/users/test-connection
```

Deberías ver:
```json
{
  "success": true,
  "message": "Database connection successful",
  "data": {
    "databaseConnected": true,
    "counts": {
      "roles": 4,
      "users": 0,
      "teams": 0,
      "tasks": 0
    }
  }
}
```

## 🛠️ Opción 2: Configuración Manual

### **Estructura de Base de Datos**

La base de datos incluye las siguientes tablas:

```sql
-- Tabla de Roles
CREATE TABLE Roles (
    RoleId int IDENTITY(1,1) PRIMARY KEY,
    RoleName nvarchar(50) NOT NULL
);

-- Tabla de Equipos
CREATE TABLE Teams (
    TeamId int IDENTITY(1,1) PRIMARY KEY,
    TeamName nvarchar(100) NOT NULL,
    Description nvarchar(500),
    LeaderId int NULL,
    CreatedAt datetime2 DEFAULT GETDATE(),
    UpdatedAt datetime2 DEFAULT GETDATE()
);

-- Tabla de Usuarios
CREATE TABLE Users (
    UserId int IDENTITY(1,1) PRIMARY KEY,
    Email nvarchar(255) NOT NULL UNIQUE,
    PasswordHash nvarchar(255) NOT NULL,
    FirstName nvarchar(100) NOT NULL,
    LastName nvarchar(100) NOT NULL,
    RoleId int NOT NULL,
    TeamId int NULL,
    IsActive bit DEFAULT 1,
    CreatedAt datetime2 DEFAULT GETDATE(),
    UpdatedAt datetime2 DEFAULT GETDATE(),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
    FOREIGN KEY (TeamId) REFERENCES Teams(TeamId)
);

-- Tabla de Tareas
CREATE TABLE Tasks (
    TaskId int IDENTITY(1,1) PRIMARY KEY,
    Title nvarchar(200) NOT NULL,
    Description nvarchar(1000),
    Status nvarchar(50) DEFAULT 'Pending',
    Priority nvarchar(50) DEFAULT 'Medium',
    TeamId int NOT NULL,
    AssignedUserId int NULL,
    CreatedByUserId int NOT NULL,
    DueDate datetime2 NULL,
    CreatedAt datetime2 DEFAULT GETDATE(),
    UpdatedAt datetime2 DEFAULT GETDATE(),
    FOREIGN KEY (TeamId) REFERENCES Teams(TeamId),
    FOREIGN KEY (AssignedUserId) REFERENCES Users(UserId),
    FOREIGN KEY (CreatedByUserId) REFERENCES Users(UserId)
);
```

### **Datos de Prueba (Seed Data)**

```sql
-- Insertar roles
INSERT INTO Roles (RoleName) VALUES 
('Admin'),
('Manager'),
('Developer'),
('Tester');

-- Insertar equipos de ejemplo
INSERT INTO Teams (TeamName, Description) VALUES 
('Desarrollo Frontend', 'Equipo encargado del desarrollo de interfaces de usuario'),
('Desarrollo Backend', 'Equipo encargado del desarrollo de APIs y servicios'),
('QA Testing', 'Equipo de aseguramiento de calidad y testing');

-- Insertar usuarios de ejemplo (las contraseñas están hasheadas)
INSERT INTO Users (Email, PasswordHash, FirstName, LastName, RoleId, TeamId) VALUES 
('admin@taskflow.com', 'AQAAAAEAACcQAAAAEJ...', 'Admin', 'System', 1, NULL),
('manager@taskflow.com', 'AQAAAAEAACcQAAAAEJ...', 'Manager', 'Principal', 2, 1),
('dev1@taskflow.com', 'AQAAAAEAACcQAAAAEJ...', 'Developer', 'One', 3, 2),
('tester1@taskflow.com', 'AQAAAAEAACcQAAAAEJ...', 'Tester', 'One', 4, 3);
```

## 🔧 Configuraciones Adicionales

### **Configurar SQL Server para Conexiones TCP/IP**

1. Abrir **SQL Server Configuration Manager**
2. Ir a **SQL Server Network Configuration** > **Protocols for SQLEXPRESS**
3. Habilitar **TCP/IP**
4. Reiniciar el servicio **SQL Server (SQLEXPRESS)**

### **Configurar Firewall (Si es necesario)**

```bash
# Abrir puerto 1433 en Windows Firewall
netsh advfirewall firewall add rule name="SQL Server" dir=in action=allow protocol=TCP localport=1433
```

## 🆘 Solución de Problemas

### **Error: "Cannot connect to server"**

**Solución:**
1. Verificar que SQL Server esté ejecutándose
2. Comprobar el nombre del servidor (puede ser `localhost\SQLEXPRESS`)
3. Verificar que TCP/IP esté habilitado

### **Error: "Login failed for user"**

**Solución:**
1. Verificar credenciales en `appsettings.json`
2. Asegurarse de que el usuario tenga permisos
3. Probar conexión desde SSMS primero

### **Error: "Database does not exist"**

**Solución:**
1. Crear la base de datos manualmente
2. Ejecutar migraciones: `dotnet ef database update`
3. Verificar nombre de base de datos en cadena de conexión

### **Error: "Migration failed"**

**Solución:**
```bash
# Limpiar migraciones
dotnet ef migrations remove --project Backend/TaskFlowPro.Persistence --startup-project Backend/TaskFlowPro.Api

# Crear nueva migración
dotnet ef migrations add InitialCreate --project Backend/TaskFlowPro.Persistence --startup-project Backend/TaskFlowPro.Api

# Aplicar migración
dotnet ef database update --project Backend/TaskFlowPro.Persistence --startup-project Backend/TaskFlowPro.Api
```

## 📞 Soporte

Si tienes problemas con la configuración de la base de datos:

1. **Verificar logs** en la aplicación
2. **Probar conexión** con SSMS
3. **Revisar firewall** y configuraciones de red
4. **Contactar al profesor** si persisten los problemas

## ✅ Checklist de Verificación

Antes de continuar, asegúrate de que:

- [ ] SQL Server está instalado y ejecutándose
- [ ] Base de datos `TaskFlowProDB` existe
- [ ] Usuario tiene permisos correctos
- [ ] Cadena de conexión está configurada
- [ ] Migraciones se ejecutaron exitosamente
- [ ] Endpoint `/api/users/test-connection` responde correctamente

## 🎯 Próximos Pasos

Una vez completada la configuración de la base de datos:

1. **Ejecutar la aplicación** con Aspire
2. **Probar endpoints** de la API
3. **Explorar la documentación** en Scalar
4. **Comenzar con los ejercicios** del proyecto

---

**¡Base de datos lista! Ahora puedes continuar con el desarrollo. 🚀**
