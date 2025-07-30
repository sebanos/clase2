# 📋 TaskFlowPro - Modelos de Formularios

## 🏗️ Arquitectura Limpia - Separación de Responsabilidades

Esta carpeta contiene los **modelos de formularios** que siguen los principios de **Arquitectura Limpia**, separando las estructuras de datos de la lógica de presentación.

## 📁 Estructura de Carpetas

```
📁 Models/
├── 📁 Auth/                    # Modelos de autenticación
│   ├── LoginFormModel.cs      # Formulario de login
│   └── RegisterFormModel.cs   # Formulario de registro
├── 📁 Users/                  # Modelos de usuarios
│   └── UserFormModel.cs       # Formulario de usuario
├── 📁 Teams/                  # Modelos de equipos
│   └── TeamFormModel.cs       # Formulario de equipo
├── 📁 Tasks/                  # Modelos de tareas
│   └── TaskFormModel.cs       # Formulario de tarea
└── README.md                  # Esta documentación
```

## 🎯 Beneficios de esta Arquitectura

### ✅ **Separación de Responsabilidades**
- **Modelos**: Solo estructura de datos y validaciones
- **Componentes**: Solo lógica de presentación y UI
- **Servicios**: Solo lógica de negocio

### ✅ **Reutilización**
- Los modelos pueden usarse en múltiples componentes
- Fácil compartir entre diferentes vistas
- Consistencia en toda la aplicación

### ✅ **Mantenibilidad**
- Cambios en validaciones solo afectan el modelo
- Fácil testing de validaciones
- Código más limpio y organizado

### ✅ **Validaciones Centralizadas**
- Data Annotations en un solo lugar
- Validaciones consistentes
- Fácil modificación de reglas

## 📝 Convenciones de Nomenclatura

### **Archivos**
- `{Entity}FormModel.cs` - Para formularios
- Ejemplo: `UserFormModel.cs`, `TeamFormModel.cs`

### **Clases**
- `{Entity}FormModel` - Para modelos de formulario
- Ejemplo: `UserFormModel`, `TeamFormModel`

### **Propiedades**
- **PascalCase** para todas las propiedades
- **Data Annotations** para validaciones
- **Valores por defecto** cuando sea apropiado

## 🔧 Uso en Componentes

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

## 📚 Ejemplos de Modelos

### **LoginFormModel**
```csharp
public class LoginFormModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = "";

    public bool RememberMe { get; set; } = false;
}
```

### **UserFormModel**
```csharp
public class UserFormModel
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Role is required")]
    public string Role { get; set; } = "";

    public string? TeamId { get; set; }
    public int? UserId { get; set; } // Para edición
}
```

## 🎓 Para Estudiantes

### **Objetivos de Aprendizaje**
1. **Arquitectura Limpia** - Separación de responsabilidades
2. **Data Annotations** - Validaciones declarativas
3. **Reutilización** - Modelos compartidos
4. **Mantenibilidad** - Código organizado

### **Tareas**
1. **Usar los modelos** en lugar de clases internas
2. **Implementar validaciones** usando Data Annotations
3. **Reutilizar modelos** en diferentes componentes
4. **Mantener consistencia** en nomenclatura

### **Buenas Prácticas**
- ✅ Usar Data Annotations para validaciones
- ✅ Proporcionar valores por defecto
- ✅ Documentar propiedades complejas
- ✅ Mantener modelos simples (solo datos)
- ❌ No incluir lógica de negocio en modelos
- ❌ No referenciar servicios desde modelos

## 🔄 Migración desde Clases Internas

Si tienes clases internas en componentes, sigue estos pasos:

1. **Crear modelo** en la carpeta correspondiente
2. **Agregar validaciones** con Data Annotations
3. **Actualizar using** en el componente
4. **Cambiar tipo** de la propiedad formData
5. **Eliminar clase interna** del componente

## 📖 Referencias

- [Data Annotations](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations)
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Blazor Forms and Validation](https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation)
