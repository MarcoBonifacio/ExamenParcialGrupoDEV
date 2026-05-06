# ParcialGrupoDEV

Aplicación WinForms de consulta sobre las bases de datos Northwind y Pubs.

## Resumen

Proyecto de escritorio (Windows Forms) desarrollado sobre .NET Framework 4.7.2. Provee una UI con dos módulos principales:
- Northwind: consultas básicas, intermedias y avanzadas sobre la base Northwind.
- Pubs: consultas básicas, intermedias y avanzadas sobre la base pubs.

Las consultas se centralizan en la capa BLL (NorthwindService, PubsService) que usa Entity Framework Database-First y mapea resultados a DTOs para mostrarlos en DataGridView.

## Requisitos

- Windows con .NET Framework 4.7.2 instalado.
- Visual Studio (recomendado) para compilar y ejecutar el proyecto.
- SQL Server accesible desde la máquina (el App.config apunta a `localhost`).
- Bases de datos: `Northwind` y `pubs` disponibles en el servidor SQL. Las connectionStrings usan autenticación integrada (Integrated Security).

## Archivos y estructura relevante

- ParcialGrupoDEV.csproj — proyecto WinForms.
- Program.cs — punto de entrada (arranca Form1).
- Form1* — formulario principal que abre los módulos.
- Form1Northwind* — UI para consultas Northwind.
- Form2Pubs* — UI para consultas Pubs.
- BLL\NorthwindService.cs, BLL\PubsService.cs — lógica de negocio y consultas.
- BLL\*Dtos.cs — DTOs para resultados de consultas.
- NorthwindDiagrama.Context.cs, Pubs.Context.cs — DbContext generados por EF (Database-First).
- Utils\CsvExporter.cs — exporta un DataGridView a CSV (UTF-8).
- App.config — connectionStrings y configuración de EF.

## Cómo ejecutar

1. Abrir la solución/project en Visual Studio.
2. Verificar App.config → connectionStrings. Si la base está en otro servidor o usa SQL Auth, actualizar la cadena.
3. Compilar (Build) en modo `Debug` o `Release`.
4. Ejecutar la aplicación: se mostrará el Form1. Abrir "Abrir Northwind" o "Abrir Pubs".
5. Seleccionar la consulta en el ComboBox (Básica / Intermedia / Avanzada) y presionar el botón correspondiente. Los resultados aparecen en la grilla.

## Demo / pasos de comprobación rápidos

1. Asegurar que SQL Server tiene las bases `Northwind` y `pubs` y que el usuario Windows tiene acceso.
2. Ejecutar la consulta "Clientes" (Northwind) — debería listar clientes.
3. Ejecutar "Top 10 clientes por gasto" — debería mostrar clientes ordenados por gasto.
4. Probar exportar la grilla a CSV usando la utilidad CsvExporter (si está integrada en la UI).

## Problemas comunes

- Error de conexión a la base: revisar `App.config` y permisos sobre SQL Server.
- Faltan tablas/BD: restaurar las bases `Northwind` y `pubs` o modificar las cadenas para apuntar a un backup/restauración.

## Siguiente pasos recomendados

- Añadir un README más detallado con scripts SQL o archivos .bak para restaurar las bases.
- Crear un instalador (ClickOnce/InnoSetup) o un ZIP de `bin\\Release` para distribución.
- Agregar pruebas unitarias para la capa BLL.

---

Proyecto generado y preparado para revisión. Para asistencia con la creación del ZIP de distribución, generación de un release en GitHub o incluir scripts SQL, pedirlo explícitamente.
