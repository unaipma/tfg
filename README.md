# TPV Bar - Terminal Punto de Venta para Hostelería

**Desarrollado por:** Unai Pastor Martínez  
**Proyecto de Fin de Grado - CFGS Desarrollo de Aplicaciones Web (MULWEB)**

## Descripción

Este proyecto es un sistema TPV (Terminal Punto de Venta) orientado a la gestión eficiente de bares o pequeños establecimientos de hostelería. Se trata de una aplicación de escritorio desarrollada en **C#**, utilizando **.NET Framework** y **WinForms**, con una arquitectura en tres capas que garantiza una separación clara entre la presentación, lógica de negocio y acceso a datos.

El sistema ofrece:

- Gestión centralizada de productos y usuarios (rol administrador).
- Registro de ventas y generación de facturas/tickets (rol empleado).
- **Modo offline** gracias a la integración de **SQLite**.
- Sincronización en la nube mediante **PostgreSQL** alojado en **Neon.tech**.
- Seguridad con hashing de contraseñas y control de roles.

---

## Tecnologías utilizadas

- `C#` y `.NET Framework`
- `WinForms` para interfaz gráfica
- `PostgreSQL` (cloud - Neon.tech)
- `SQLite` (local)
- `iText7` para generación de PDFs
- `BouncyCastle` para soporte criptográfico
- `Advanced Installer` para empaquetado

---

## Características principales

-  Aplicación de escritorio para Windows
-  Inicio de sesión por rol (empleado sin contraseña / administrador con credenciales)
-  Sincronización de datos online/offline
-  Facturación y generación de tickets PDF
-  Estadísticas de ventas y cierre diario
-  CRUD completo de productos y usuarios
-  Filtros de búsqueda avanzados
-  Instalación mediante `.exe` o `.msi`

---

## Instalación

1. Descarga el instalador `.msi` generado con **Advanced Installer** desde la sección de releases.
2. Ejecuta el instalador como administrador.
3. Asegúrate de tener conexión a Internet para sincronizar datos por primera vez.
4. Usa el **manual de instalación** incluido para más detalles.

---

## Manuales incluidos

-  **Manual de Usuario**: para empleados
-  **Manual de Administrador**: para tareas de gestión
-  **Manual de Instalación**: pasos para desplegar correctamente la app

---

## Posibles ampliaciones

- Versión web o móvil para estadísticas remotas
- Sincronización en tiempo real entre SQLite y PostgreSQL
- Módulo de inventario
- Gestión de mesas

---

## Autor

**Unai Pastor Martínez**  
Trabajo de Fin de Grado 2025

---

## Licencia de Usuario Final (EULA)

### 1. ACEPTACIÓN DE LA LICENCIA
Al instalar o utilizar esta aplicación, usted acepta quedar vinculado por los términos de esta Licencia de Usuario Final (EULA). Si no está de acuerdo con los términos, no instale ni utilice esta aplicación.

### 2. LICENCIA DE USO
Esta aplicación es un proyecto académico desarrollado con fines educativos. Se concede al usuario una licencia no exclusiva, no transferible y gratuita para usar esta aplicación únicamente con fines personales, educativos o de demostración.

### 3. DERECHOS DE AUTOR
Este software y toda su documentación asociada están protegidos por derechos de autor. Todos los derechos están reservados por el autor. Queda prohibida su reproducción, distribución o modificación sin autorización expresa.

### 4. LIMITACIÓN DE RESPONSABILIDAD
El autor no se hace responsable de ningún daño, pérdida de datos o perjuicio derivado del uso de esta aplicación. El uso del software es bajo su propio riesgo.

### 5. TERMINACIÓN
Esta licencia se terminará automáticamente si incumple cualquiera de sus términos. En tal caso, deberá eliminar todas las copias del software de sus dispositivos.

### 6. CONTACTO
Para cualquier duda o comentario sobre esta licencia, por favor contacte al autor.

