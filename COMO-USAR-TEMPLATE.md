# 🚀 Cómo Crear tu Proyecto Personal desde el Template

## 📋 Instrucciones para Estudiantes

Este repositorio es un **Template** que te permite crear tu propio proyecto TaskFlowPro completamente independiente. Sigue estos pasos para configurar tu proyecto personal:

---

## 🎯 **PASO 1: Crear tu Repositorio Personal**

### 1.1 Usar el Template
1. **Ir al repositorio template:** [TaskFlowPro-Estudiantes](https://github.com/JohanCalaT/TaskFlowPro-Estudiantes)
2. **Buscar el botón verde "Use this template"** (arriba a la derecha)
3. **Hacer clic en "Use this template"** → **"Create a new repository"**

### 1.2 Configurar tu Repositorio
```
📝 Llenar el formulario:
Repository name: TaskFlowPro-[TU-NOMBRE-APELLIDO]
Description: Mi proyecto TaskFlowPro para el curso de Desarrollo Web
Owner: [TU-USUARIO] (debe ser tu cuenta personal)
Public/Private: [Elige según tu preferencia]
☑️ Include all branches (recomendado)
```

### 1.3 Crear el Repositorio
- **Hacer clic en "Create repository"**
- **¡Listo!** Ya tienes tu propio repositorio TaskFlowPro

---

## 💻 **PASO 2: Clonar TU Repositorio**

### 2.1 Copiar la URL de TU repositorio
```
Tu repositorio estará en:
https://github.com/[TU-USUARIO]/TaskFlowPro-[TU-NOMBRE]
```

### 2.2 Clonar localmente
```bash
# Reemplaza con TU URL real
git clone https://github.com/[TU-USUARIO]/TaskFlowPro-[TU-NOMBRE].git

# Entrar al directorio
cd TaskFlowPro-[TU-NOMBRE]
```

### 2.3 Verificar que es TU repositorio
```bash
git remote -v
# Debe mostrar:
# origin  https://github.com/[TU-USUARIO]/TaskFlowPro-[TU-NOMBRE].git
```

**⚠️ IMPORTANTE:** Si ves el usuario del profesor en lugar del tuyo, algo salió mal. Repite el proceso.

---

## 🔧 **PASO 3: Configurar el Proyecto**

### 3.1 Verificar que .NET está instalado
```bash
dotnet --version
# Debe mostrar: 9.0.x o superior
```

### 3.2 Restaurar dependencias
```bash
dotnet restore Frontend/TaskFlowPro.Web/TaskFlowPro.Web.csproj
```

### 3.3 Compilar el proyecto
```bash
dotnet build Frontend/TaskFlowPro.Web/TaskFlowPro.Web.csproj
```

### 3.4 Ejecutar el proyecto
```bash
dotnet run --project Frontend/TaskFlowPro.Web/TaskFlowPro.Web.csproj --urls "https://localhost:7001"
```

### 3.5 Abrir en el navegador
- **URL:** `https://localhost:7001`
- **Deberías ver:** La aplicación TaskFlowPro funcionando

---

## 📚 **PASO 4: Empezar a Trabajar**

### 4.1 Leer la documentación
- **Abrir:** `Frontend/TaskFlowPro.Web/README-ESTUDIANTES.md`
- **Revisar:** Estructura del proyecto y tareas a completar

### 4.2 Primera tarea: LoginForm
- **Archivo:** `Frontend/TaskFlowPro.Web/Features/Auth/Components/LoginForm.razor`
- **Objetivo:** Implementar el diseño del formulario de login
- **Seguir:** Los comentarios TODO en el archivo

### 4.3 Subir tus cambios
```bash
# Agregar cambios
git add .

# Hacer commit
git commit -m "feat: Implement LoginForm design"

# Subir a TU repositorio
git push origin master
```

---

## ✅ **Verificación Final**

### Confirma que todo está correcto:
- [ ] Tienes tu propio repositorio (no es un fork)
- [ ] La URL contiene TU usuario, no el del profesor
- [ ] El proyecto compila sin errores
- [ ] Puedes acceder a `https://localhost:7001`
- [ ] Puedes hacer commits y push a TU repositorio

---

## 🎓 **Progresión de Tareas**

Una vez configurado, sigue esta progresión:

### **Nivel 1: Autenticación**
1. **LoginForm.razor** - Formulario básico
2. **RegisterForm.razor** - Formulario con validaciones

### **Nivel 2: Listas**
3. **UserListView.razor** - Lista de usuarios
4. **TeamListView.razor** - Lista de equipos
5. **TaskListView.razor** - Lista de tareas
6. **TaskCard.razor** - Componente de tarea

### **Nivel 3: Formularios**
7. **UserFormView.razor** - Formulario de usuario
8. **TeamFormView.razor** - Formulario de equipo
9. **TaskFormView.razor** - Formulario de tarea

---

## 🆘 **Solución de Problemas**

### ❌ "No veo el botón 'Use this template'"
- **Causa:** El repositorio no está configurado como template
- **Solución:** Contactar al profesor

### ❌ "Error al clonar el repositorio"
- **Causa:** URL incorrecta o problemas de permisos
- **Solución:** Verificar que la URL sea de TU repositorio

### ❌ "dotnet: command not found"
- **Causa:** .NET no está instalado
- **Solución:** Instalar .NET 9 desde [dotnet.microsoft.com](https://dotnet.microsoft.com)

### ❌ "El proyecto no compila"
- **Causa:** Dependencias faltantes
- **Solución:** Ejecutar `dotnet restore` y luego `dotnet build`

---

## 📞 **Contacto**

Si tienes problemas con la configuración:
1. **Revisar** este tutorial paso a paso
2. **Verificar** que seguiste todos los pasos correctamente
3. **Contactar** al profesor con detalles específicos del error

---

## 🎯 **Recordatorio Importante**

### ✅ **Tu repositorio es TUYO:**
- Puedes modificarlo como quieras
- Es perfecto para tu portfolio personal
- No afecta el trabajo de otros estudiantes
- No recibes actualizaciones automáticas del profesor

### ✅ **Trabajo independiente:**
- Cada estudiante tiene su propio proyecto
- No hay conflictos entre estudiantes
- Puedes experimentar libremente
- Es tu espacio de aprendizaje personal

**¡Éxito en tu proyecto TaskFlowPro!** 🚀
