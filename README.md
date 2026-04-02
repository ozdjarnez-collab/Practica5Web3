# ?? Practica5Web3 - Sistema de Gestión de Farmacia

## ?? Descripción General

Practica5Web3 es una aplicación web ASP.NET Core 8 Razor Pages que gestiona de forma integral una farmacia, incluyendo medicamentos, categorías, estantes, clientes y pedidos.

---

## ? Mejoras Recientes (2026)

### ?? **1. Buscadores y Filtros Avanzados**
- ? Buscar medicamentos por nombre, categoría o descripción
- ? Buscar clientes por nombre o email
- ? Filtrado en tiempo real con interfaz mejorada
- ? Botones para limpiar búsqueda

### ????? **2. Permisos para Farmacéuticos**
- ? **NUEVO**: Los farmacéuticos pueden registrar medicamentos
- ? Acceso a: Medicamentos, Categorías, Estantes
- ? Restricción: Solo crear, no editar ni eliminar
- ? Interfaz clara con indicadores visuales

### ?? **3. Estética Moderna**
- ? Gradientes elegantes en toda la app
- ? Navbar mejorada con iconos
- ? Tarjetas con efectos hover
- ? Animaciones suaves
- ? Sombras dinámicas
- ? Diseño completamente responsive

### ?? **4. Dashboard Potenciado**
- ? 6-7 métricas principales con datos en tiempo real
- ? Alertas visuales para medicamentos
- ? Tabla de pedidos recientes (Admin)
- ? Diseño intuitivo con tarjetas de impacto

---

## ??? Stack Tecnológico

- **Backend**: ASP.NET Core 8
- **Frontend**: Razor Pages, HTML5, Bootstrap 5
- **Base de Datos**: SQL Server
- **Autenticación**: Identity
- **Estilos**: CSS3 con gradientes y animaciones
- **JavaScript**: Vanilla JS con efectos interactivos

---

## ?? Estructura del Proyecto

```
Practica5Web3/
??? Controllers/
?   ??? HomeController.cs         ? Dashboard mejorado
?   ??? MedicamentoesController.cs ? Búsqueda + Farmacéutico Create
?   ??? ClientesController.cs      ? Búsqueda agregada
?   ??? CategoriesController.cs
?   ??? EstantesController.cs
?   ??? PedidosController.cs
??? Models/
?   ??? Medicamento.cs
?   ??? Cliente.cs
?   ??? Pedido.cs
?   ??? Categoria.cs
?   ??? Estante.cs
?   ??? DashboardViewModel.cs     ? Nuevas propiedades
?   ??? Usuario.cs
??? Views/
?   ??? Shared/
?   ?   ??? _Layout.cshtml        ? Navbar rediseñado
?   ?   ??? _LoginPartial.cshtml
?   ??? Home/
?   ?   ??? Index.cshtml          ? Dashboard rediseñado
?   ??? Medicamentoes/
?   ?   ??? Index.cshtml          ? Con buscador
?   ?   ??? Details.cshtml        ? Rediseñado
?   ?   ??? Create.cshtml
?   ?   ??? Edit.cshtml
?   ??? Clientes/
?       ??? Index.cshtml          ? Con buscador
??? wwwroot/
?   ??? css/
?   ?   ??? site.css              ? Rediseñado
?   ?   ??? animations.css        ? NUEVO
?   ??? js/
?       ??? custom.js             ? NUEVO
??? Areas/
    ??? Identity/
        ??? Data/
            ??? Practica5Web3Context.cs
```

---

## ?? Roles del Sistema

### ?? **Cliente**
- **Acceso**: 
  - Ver inicio (medicamentos disponibles)
  - Buscar medicamentos
  - Ver detalles de medicamentos
- **No puede**: Gestionar stock ni órdenes

### ?? **Farmacéutico**
- **Acceso**:
  - Ver dashboard de medicamentos
  - **CREAR medicamentos** ? NUEVA FUNCIÓN
  - Ver/Gestionar categorías
  - Ver/Gestionar estantes
- **No puede**: Editar, eliminar, acceder a clientes/pedidos

### ?? **Administrador**
- **Acceso**: Sistema completo
  - Crear/Editar/Eliminar medicamentos
  - Gestionar usuarios
  - Ver clientes y pedidos
  - Gestionar categorías y estantes
  - Dashboard completo

---

## ?? Cómo Ejecutar

### Requisitos
- .NET 8 SDK
- SQL Server (Express o Full)
- Visual Studio 2022 o VS Code

### Pasos

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/ozdjarnez-collab/Practica5Web3.git
   cd Practica5Web3
   ```

2. **Restaurar paquetes NuGet**
   ```bash
   dotnet restore
   ```

3. **Aplicar migraciones**
   ```bash
   dotnet ef database update
   ```

4. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

5. **Acceder**
   - URL: `https://localhost:7000` (o el puerto que asigne)

---

## ?? Funciones Principales

### Gestión de Medicamentos
- **Crear**: Administrador, Farmacéutico ?
- **Ver**: Todos los usuarios
- **Editar**: Solo Administrador
- **Eliminar**: Solo Administrador
- **Buscar**: Por nombre, categoría, descripción

### Gestión de Clientes
- **Crear**: Solo Administrador
- **Ver**: Solo Administrador
- **Editar**: Solo Administrador
- **Buscar**: Por nombre, email

### Dashboard
- **Medicamentos Vencidos**: Con alerta roja
- **Medicamentos por Vencer**: Próximos 30 días
- **Stock Bajo**: Alertas para reorden
- **Pedidos Recientes**: Lista de últimos 5 (Admin)

---

## ?? Características Visuales

### Colores
- **Primario**: `#667eea ? #764ba2` (Púrpura-Azul)
- **Success**: `#10b981 ? #059669` (Verde)
- **Danger**: `#ef4444 ? #dc2626` (Rojo)
- **Warning**: `#f59e0b ? #d97706` (Naranja)
- **Info**: `#06b6d4 ? #0891b2` (Cian)

### Animaciones
- ? Efecto float en iconos
- ?? Hover elevado en tarjetas
- ?? Ripple effect en botones
- ?? Transiciones suaves
- ?? Contadores animados

### Responsividad
- ? Desktop (1200px+)
- ? Tablet (768px - 1200px)
- ? Móvil (< 768px)

---

## ?? Archivos Modificados

### Backend
- `Controllers/HomeController.cs` - Dashboard mejorado
- `Controllers/MedicamentoesController.cs` - Búsqueda + Farmacéutico
- `Controllers/ClientesController.cs` - Búsqueda
- `Models/DashboardViewModel.cs` - Nuevas propiedades

### Frontend
- `Views/Shared/_Layout.cshtml` - Navbar + Iconos
- `Views/Home/Index.cshtml` - Dashboard rediseñado
- `Views/Medicamentoes/Index.cshtml` - Buscador
- `Views/Medicamentoes/Details.cshtml` - Rediseño
- `Views/Clientes/Index.cshtml` - Buscador

### Estilos
- `wwwroot/css/site.css` - Rediseño completo
- `wwwroot/css/animations.css` - **NUEVO** (Animaciones)
- `wwwroot/js/custom.js` - **NUEVO** (Interactividad)

---

## ?? Seguridad

- ? Autenticación con ASP.NET Identity
- ? Autorización por roles
- ? CSRF Protection
- ? SQL Injection Prevention (Entity Framework)
- ? HTTPS habilitado
- ? Validación en cliente y servidor

---

## ?? Documentación Adicional

- `MEJORAS_IMPLEMENTADAS.md` - Detalle técnico de cambios
- `GUIA_RAPIDA.md` - Guía de uso para usuarios
- `RESUMEN_MEJORAS.html` - Resumen visual interactivo

---

## ?? Reportar Bugs

Si encuentras algún error:
1. Abre un issue en GitHub
2. Describe el comportamiento esperado vs actual
3. Incluye pasos para reproducir

---

## ?? Sugerencias Futuras

1. ?? Carrito de compras dinámico
2. ?? Pasarela de pagos integrada
3. ?? Notificaciones por email
4. ?? Reportes exportables (PDF/Excel)
5. ?? Modo oscuro
6. ?? Alertas en tiempo real (SignalR)
7. ?? App móvil nativa
8. ?? Analytics avanzado

---

## ?? Licencia

Este proyecto es parte de la práctica educativa de desarrollo web.

---

## ????? Equipo Desarrollador

- **Módulo Clientes y Pedidos**: Camila
- **Mejoras Generales**: Equipo de Desarrollo 2026

---

## ? Estado del Proyecto

| Área | Estado |
|------|--------|
| Backend | ? Completo |
| Frontend | ? Completo |
| Buscadores | ? Implementado |
| Farmacéutico Create | ? Implementado |
| Dashboard | ? Mejorado |
| Estilos | ? Moderno |
| Testing | ? En proceso |
| Producción | ?? Listo |

---

**Última actualización**: 2026
**Versión**: 2.0 (Mejorada)

¡Gracias por usar Practica5Web3! ??
