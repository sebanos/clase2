# 🎓 TaskFlowPro - Guía para Estudiantes

## 📚 Objetivos de Aprendizaje

Este proyecto te enseñará:
- **Patrón CodeBehind** en Blazor Server
- **Arquitectura de componentes** reutilizables
- **Inyección de dependencias** en .NET
- **Manejo de estado** y navegación
- **Formularios y validación** en Blazor
- **Estilos con Tailwind CSS**

## 🏗️ Estructura del Proyecto

### **Componentes UI (✅ Completamente Implementados con CodeBehind)**
Estos componentes están listos para usar y siguen el patrón CodeBehind:

```
📁 Components/UI/
├── Button/          # ✅ Button.razor + Button.razor.cs
├── Input/           # ✅ Input.razor + Input.razor.cs
├── Card/            # ✅ Card.razor + Card.razor.cs
├── Badge/           # ✅ Badge.razor + Badge.razor.cs
├── Avatar/          # ✅ Avatar.razor + Avatar.razor.cs
├── EmptyState/      # ✅ EmptyState.razor (simple, sin lógica)
└── LoadingSpinner/  # ✅ LoadingSpinner.razor + LoadingSpinner.razor.cs
```

### **Modelos de Formularios (✅ Arquitectura Limpia)**
Modelos separados siguiendo principios de arquitectura limpia:

```
📁 Models/
├── Auth/
│   ├── LoginFormModel.cs      # ✅ Modelo con validaciones
│   └── RegisterFormModel.cs   # ✅ Modelo con validaciones
├── Users/
│   └── UserFormModel.cs       # ✅ Modelo con validaciones
├── Teams/
│   └── TeamFormModel.cs       # ✅ Modelo con validaciones
├── Tasks/
│   └── TaskFormModel.cs       # ✅ Modelo con validaciones
└── README.md                  # ✅ Documentación de arquitectura
```

**Beneficios:**
- ✅ **Separación de responsabilidades** - Modelos independientes de UI
- ✅ **Validaciones centralizadas** - Data Annotations en un solo lugar
- ✅ **Reutilización** - Modelos compartidos entre componentes
- ✅ **Mantenibilidad** - Fácil testing y modificación

### **Componentes de Funcionalidad (🚧 Para Implementar)**
Estos son los que debes completar:

```
📁 Features/
├── Auth/Components/
│   ├── LoginForm.razor        # 🚧 Diseño para implementar
│   ├── LoginForm.razor.cs     # 🚧 Lógica para implementar
│   ├── RegisterForm.razor     # 🚧 Diseño para implementar
│   └── RegisterForm.razor.cs  # 🚧 Lógica para implementar
├── Users/Components/
│   ├── UserListView.razor     # 🚧 Diseño para implementar
│   ├── UserListView.razor.cs  # 🚧 Lógica para implementar
│   ├── UserFormView.razor     # 🚧 Diseño para implementar
│   └── UserFormView.razor.cs  # 🚧 Lógica para implementar
├── Teams/Components/
│   ├── TeamListView.razor     # 🚧 Diseño para implementar
│   ├── TeamListView.razor.cs  # 🚧 Lógica para implementar
│   ├── TeamFormView.razor     # 🚧 Diseño para implementar
│   └── TeamFormView.razor.cs  # 🚧 Lógica para implementar
└── Tasks/Components/
    ├── TaskListView.razor     # 🚧 Diseño para implementar
    ├── TaskListView.razor.cs  # 🚧 Lógica para implementar
    ├── TaskCard.razor         # 🚧 Diseño para implementar
    ├── TaskCard.razor.cs      # 🚧 Lógica para implementar
    ├── TaskFormView.razor     # 🚧 Diseño para implementar
    └── TaskFormView.razor.cs  # 🚧 Lógica para implementar
```

## 🏗️ Uso de Modelos de Formularios

### **Antes (❌ Incorrecto)**
```csharp
// Dentro del componente .razor.cs
protected class UserFormData
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    // ...
}
```

### **Después (✅ Correcto)**
```csharp
// En el componente .razor.cs
using TaskFlowPro.Web.Models.Users;

public partial class UserFormViewBase : ComponentBase
{
    protected UserFormModel formData = new();
    // ...
}
```

### **Validaciones Automáticas**
Los modelos incluyen validaciones con Data Annotations:
```csharp
[Required(ErrorMessage = "Email is required")]
[EmailAddress(ErrorMessage = "Please enter a valid email address")]
public string Email { get; set; } = "";
```

## 🎯 Tareas por Completar

### **NIVEL 1: Diseño de Formularios de Autenticación**

#### **0. LoginForm.razor (PRIMERA TAREA)**
**Diseño + Lógica:**
- Diseñar formulario usando `<Card>`, `<Input>`, `<Button>`
- Implementar `HandleSubmit()` y `TogglePasswordVisibility()`
- Mostrar credenciales de prueba

#### **1. RegisterForm.razor**
**Diseño + Lógica:**
- Formulario con FirstName, LastName, Email, Password, ConfirmPassword
- Validar que las contraseñas coincidan
- Implementar `HandleSubmit()`, `TogglePasswordVisibility()`, `ToggleConfirmPasswordVisibility()`

### **NIVEL 2: Listas de Datos**

#### **2. UserListView.razor**
**Diseño + Lógica:**
- **Diseño:** Grid de tarjetas con Avatar, Badge, Button
- **Lógica:** `LoadUsers()`, `GetUserInitials()`, `GetRoleBadgeVariant()`, `GetRoleDisplayName()`, `HandleCreateUser()`, `HandleEditUser()`, `HandleDeleteUser()`

#### **3. TeamListView.razor**
**Diseño + Lógica:**
- **Diseño:** Lista de equipos con información del líder y acciones
- **Lógica:** `LoadData()`, `GetTeamLeaderName()`, `GetTimeAgo()`, `HandleCreateTeam()`, `HandleEditTeam()`, `HandleDeleteTeam()`, `HandleViewTasks()`, `HandleViewMembers()`

#### **4. TaskListView.razor**
**Diseño + Lógica:**
- **Diseño:** Lista de tareas con filtros y búsqueda
- **Lógica:** `GetTitle()`, `GetSubtitle()`, `CanCreateTasks()`, `GetStatusBadgeVariant()`, `GetPriorityBadgeVariant()`, `HandleCreateTask()`, `HandleEditTask()`, `HandleDeleteTask()`, `HandleCompleteTask()`

#### **5. TaskCard.razor**
**Diseño + Lógica:**
- **Diseño:** Tarjeta individual de tarea con checkbox y acciones
- **Lógica:** `GetTaskCardClasses()`, `GetCheckboxClasses()`, `GetTitleClasses()`, `HandleStatusToggle()`, `HandleDelete()`

### **NIVEL 3: Formularios Complejos**

#### **6. UserFormView.razor**
**Diseño + Lógica:**
- **Diseño:** Formulario con campos Name, Email, Role, Team
- **Lógica:** `HandleSubmit()`, `HandleBack()`, `GetTeams()`

#### **7. TeamFormView.razor**
**Diseño + Lógica:**
- **Diseño:** Formulario con Name, Description, Leader
- **Lógica:** `HandleSubmit()`, `HandleBack()`, `GetAvailableLeaders()`

#### **8. TaskFormView.razor**
**Diseño + Lógica:**
- **Diseño:** Formulario con Title, Description, Status, AssignedTo
- **Lógica:** `HandleSubmit()`, `HandleBack()`, `GetTeamMembers()`

## 🔧 Servicios Disponibles

### **UIStateService**
```csharp
UIState.NavigateTo("view-name")           // Navegar entre vistas
UIState.ShowSuccess("mensaje")            // Mostrar mensaje de éxito
UIState.ShowInfo("mensaje")               // Mostrar mensaje informativo
UIState.CurrentUser                       // Usuario actual
```

### **MockDataService**
```csharp
MockDataService.GetMockUsers()            // Obtener usuarios de prueba
MockDataService.GetMockTeams()            // Obtener equipos de prueba
MockDataService.GetMockTasks()            // Obtener tareas de prueba
```

## 🎨 Componentes UI - Ejemplos de Uso

### **Button**
```razor
<Button Variant="Button.ButtonVariant.Primary"
        OnClick="HandleClick"
        Icon="fas fa-save">
    Guardar
</Button>
```

### **Input**
```razor
<Input Id="email"
       Label="Email"
       @bind-Value="formData.Email"
       Placeholder="Ingresa tu email"
       LeftIcon="fas fa-envelope"
       IsRequired="true" />
```

### **Card**
```razor
<Card HasShadow="true" IsAnimated="true">
    <Header>
        <h3>Título de la tarjeta</h3>
    </Header>
    <ChildContent>
        Contenido de la tarjeta
    </ChildContent>
</Card>
```

## 🚀 Cómo Empezar

1. **Ejecutar el proyecto:**
   ```bash
   dotnet run --project Frontend/TaskFlowPro.Web/TaskFlowPro.Web.csproj --urls "https://localhost:7001"
   ```

2. **Acceder con credenciales de prueba:**
   - Admin: `admin@taskflow.com`
   - Team Leader: `leader@taskflow.com`
   - Team Member: `member@taskflow.com`
   - Password: cualquier texto

3. **Comenzar implementando:**
   - Abre `UserListView.razor.cs`
   - Busca los métodos con `TODO: ESTUDIANTE`
   - Implementa uno por uno siguiendo las instrucciones

## 📝 Patrón CodeBehind

### **Archivo .razor (Vista)**
```razor
@namespace Mi.Namespace
@inherits MiComponenteBase

<!-- HTML y componentes aquí -->
```

### **Archivo .razor.cs (Lógica)**
```csharp
public partial class MiComponenteBase : ComponentBase
{
    [Inject] protected IServicio Servicio { get; set; } = null!;
    
    protected override void OnInitialized()
    {
        // Inicialización del componente
    }
    
    protected void MiMetodo()
    {
        // Lógica del componente
    }
}
```

## 🎯 Consejos de Implementación

1. **Siempre usar `protected`** para métodos y propiedades que usa la vista
2. **Manejar errores** con try-catch en operaciones async
3. **Llamar `StateHasChanged()`** después de modificar listas
4. **Usar `await`** para operaciones asíncronas
5. **Validar datos** antes de procesarlos

## 🔍 Debugging

- Usa `Console.WriteLine()` para debug
- Revisa la consola del navegador (F12)
- Verifica que los servicios estén inyectados correctamente
- Asegúrate de que los métodos sean `protected` no `private`

## 📚 Recursos Adicionales

- [Documentación de Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/)
- [Tailwind CSS](https://tailwindcss.com/docs)
- [Font Awesome Icons](https://fontawesome.com/icons)

¡Buena suerte con tu implementación! 🚀
