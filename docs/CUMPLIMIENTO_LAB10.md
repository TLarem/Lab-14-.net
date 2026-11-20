# Cumplimiento del Lab 10

Se revisaron el texto y las capturas del archivo `LAB 10 - JMAYHUA - 2025-I .docx`.

| Requisito de la guía | Implementación |
| --- | --- |
| Capas de arquitectura hexagonal | Domain, Application, Infrastructure y Api |
| Código de InfrastructureServicesExtensions (imagen 6) | AddInfrastructureServices registra TicketeraDbContext con AddDbContext, GetConnectionString("DefaultConnection") y UseNpgsql, además de repositorios y servicios |
| Código de ServiceRegistrationExtensions (imagen 8) | AddApplicationServices centraliza AddInfrastructureServices, autenticación JWT, controladores y SwaggerDoc v1 |
| Código de Program.cs (imagen 9) | Una llamada a AddApplicationServices antes de Build; Swagger, autenticación, autorización, MapControllers y Run permanecen en Program.cs |
| Base de datos proporcionada | Conexión comprobada con support_tickets_db en localhost:5432, usuario postgres; cinco tablas existentes compatibles |
| Repositorio | Contratos en Domain y adaptadores de EF Core en Infrastructure |
| JWT y Swagger | Login emite token; Swagger permite autorizar peticiones; sin token los tickets devuelven 401 |
| Opcionales | Se conservan BCrypt y Unit of Work |
| Salida documentada con datos generados | EVIDENCIA_API.json y swagger.json |

Los ejemplos de las capturas se adaptan a los nombres del proyecto, al DbContext de
la ticketera y a las versiones instaladas de .NET y Swagger. Los servicios de archivos,
Azure y actividades del ejemplo TrainingCenter no corresponden a la base del ejercicio.
Se usa CreateBuilder y se omite el bloque de configuración JSON vacío de la captura.

## Verificación realizada

- PostgreSQL confirmó current_database = support_tickets_db y current_user = postgres.
- Registro 201, login 200, ticket 201, consulta 200, respuesta 201, historial 200 y cierre 200.
- Petición de tickets sin token: 401.
- Se conservó un usuario de demostración, su ticket cerrado y su respuesta. Sus identificadores están en EVIDENCIA_API.json. No se modificaron registros anteriores.
- Se corrigió DatabaseClock para guardar fechas compatibles con timestamp without time zone, sin cambiar el esquema.
- dotnet build terminó sin errores. NuGet emitió NU1900 por el bloqueo de red al consultar vulnerabilidades; dotnet build -p:NuGetAudit=false terminó con cero errores y cero advertencias. Esta opción solo se aplicó a la verificación, no a la configuración del proyecto.
- Para arrancar dentro del entorno restringido se deshabilitó EventLog mediante una variable temporal de proceso; no se modificó la configuración de logging del proyecto.

## Conclusiones

La separación por capas mantiene el dominio independiente de EF Core y permite
sustituir adaptadores mediante contratos. La inyección de dependencias concentra
la configuración y mantiene Program.cs breve. Los repositorios y Unit of Work
organizan la persistencia, mientras JWT protege los recursos autenticados.
La prueba real de escritura permitió detectar una incompatibilidad de fechas que
la compilación por sí sola no revela.

Estos archivos aportan evidencia técnica. Si la entrega académica exige capturas
en Word, deben incorporarse al informe las pantallas de Swagger y estas conclusiones.
