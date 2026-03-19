# Mini Agenda Médica — API REST

API REST para gestión de citas médicas en un hospital, construida sobre **.NET 8** siguiendo **Clean Architecture** y **Domain-Driven Design (DDD)** para tener un proyecto limpio mantenible y escalable.

---

## Tabla de contenido

- [Descripción del proyecto](#descripción-del-proyecto)
- [Arquitectura](#arquitectura)
- [Estructura de carpetas](#estructura-de-carpetas)
- [Reglas de negocio](#reglas-de-negocio)
- [Modelo de dominio](#modelo-de-dominio)
- [Endpoints](#endpoints)
- [Stack tecnológico](#stack-tecnológico)
- [Cómo ejecutar](#cómo-ejecutar)
- [Decisiones de diseño](#decisiones-de-diseño)

---

## Descripción del proyecto

Sistema para agendar, cancelar y consultar citas médicas. Gestiona médicos con sus horarios de consulta por día de la semana, pacientes, y la lógica de disponibilidad de horarios, conflictos de citas y alertas de cancelaciones frecuentes.

---

## Arquitectura

El proyecto sigue **Clean Architecture** con separación en cuatro capas. Las dependencias solo apuntan hacia adentro, nunca hacia afuera.

```
┌─────────────────────────────────────────┐
│              API (Presentation)         │  Controllers, Middleware, Program.cs
├─────────────────────────────────────────┤
│             Application                 │  CQRS, Handlers, DTOs
├─────────────────────────────────────────┤
│            Infrastructure               │  EF Core, SQL Server, Implementaciones de repositorios
├─────────────────────────────────────────┤
│               Domain                    │  Entidades, Value Objects, Reglas de negocio
└─────────────────────────────────────────┘
```

**Regla de dependencias:** `API → Application → Domain ← Infrastructure`

La capa de Dominio no depende de ninguna otra. Infrastructure implementa los contratos (interfaces) que define el Dominio.

## Modelo de dominio

### Agregados

**Medico:** Gestiona sus horarios de consulta. Un médico puede tener un horario por día de la semana. La duración de sus citas está determinada por sus especialidades.

**Paciente:** Gestiona datos personales. El email y teléfono son Value Objects con validación propia.

**Cita:** Concentra todas las reglas de negocio de agendamiento. Que aplica todas las validaciones de dominio antes de construir la instancia.

### Value Objects

| Value Object | Valida |
|---|---|
| `Texto` | Validación basica, strings sin numeros |
| `CorreoElectronico` | Formato RFC, lowercase |
| `Telefono` | Formato de entre 8 y 15 digitos para contemplar casos nacional e internacional, ademas de normalizar quitando guiones, espacios, etc |
| `HorarioConsulta` | Punto de entrada para definir los slots de horaio disponibles del Medico |


## Endpoints

| Recurso | Método | Ruta | Descripción |
|---------|--------|------|-------------|
| Médicos | GET | `/api/medicos` | Lista todos los médicos |
| Médicos | GET | `/api/medicos/{id}` | Detalle de un médico |
| Médicos | POST | `/api/medicos` | Crear médico |
| Médicos | PUT | `/api/medicos/{id}` | Actualizar médico |
| Médicos | DELETE | `/api/medicos/{id}` | Eliminar médico |
| Médicos | GET | `/api/medicos/{id}/horarios-disponibles?fecha=` | Próximos 5 slots disponibles |
| Pacientes | GET | `/api/pacientes` | Lista todos los pacientes |
| Pacientes | GET | `/api/pacientes/{id}` | Detalle de un paciente |
| Pacientes | POST | `/api/pacientes` | Crear paciente |
| Pacientes | PUT | `/api/pacientes/{id}` | Actualizar paciente |
| Pacientes | DELETE | `/api/pacientes/{id}` | Eliminar paciente |
| Pacientes | GET | `/api/pacientes/{id}/historial` | Historial de citas del paciente |
| Citas | POST | `/api/citas/agendar` | Agendar cita |
| Citas | DELETE | `/api/citas/cancelar/{id}` | Cancelar cita |
| Citas | GET | `/api/citas/consultar/{id}` | Detalle de una cita |
| Agenda | GET | `/api/medicos/agenda/{id}/{fecha}` | Agenda del día de un médico |

## Pruebas GET
<img width="1883" height="919" alt="image" src="https://github.com/user-attachments/assets/56f920c1-8803-4b94-a862-53ce0264936f" />
<img width="1197" height="775" alt="image" src="https://github.com/user-attachments/assets/1962ce20-5d8b-4505-9b2e-a276f28e49f4" />
<img width="1244" height="797" alt="image" src="https://github.com/user-attachments/assets/0f69ebc7-2ebf-4ccc-bcc0-d9081de787dc" />

## Validacion de dominio con Value Object
<img width="1347" height="338" alt="image" src="https://github.com/user-attachments/assets/3cfe1541-1d5d-43b0-ab33-0e6784c2ecde" />
<img width="1353" height="386" alt="image" src="https://github.com/user-attachments/assets/f8f88d31-2283-43d7-ab4b-f476bc5ef0c5" />


---

## Stack tecnológico

| Componente | Tecnología |
|---|---|
| IDE | Visual Studio 2022 |
| Framework | .NET 8 |
| Base de datos | SQL Server 2022 |
| ORM | Entity Framework Core 9.0.14 |
| Patrón arquitectónico | Clean Architecture + DDD |

---

## Cómo ejecutar

**Prerrequisitos:** .NET 8 SDK, SQL Server 2022 y EF CORE 9.0.14

```bash
# 1. Clonar el repositorio desde consola en un carpeta para trabajar
git clone https://github.com/sau-c/AgendaMedica_API.git

# 2. Configurar la cadena de conexión
# Abrir la solución del proyecto (AgendaMedica.sln) en Visual Studio 
# Editar AgendaMedica.API/appsettings.json en caso de tener SQL Server con contraseña
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AgendaMedica;User Id=USUARIO_DE_SQL;Password=CONTRASENA_SQL;TrustServerCertificate=True;"
  }
}

# 3. Establecer proyecto de inicio
En la solucion de Visual Studio, Click derecho sobre 'AgendaMedica.API' y en "Establecer como proyecto de inicio"

# 4. Aplicar migraciones
En Visual Studio ir a Herramientas > Administrador de Paquetes NuGet > Consola del Administrador de Paquetes, en la opcion proyecto predeterminado seleccionar "AgendaMedica.Infrastructure" y ejecutar el comando 'update-database' para crear la base de datos en SQL junto a las tablas

# 5. Abrir SQL Server Management Studio y ejecutar el procedimiento almacenado que esta en src/SQL/PoblarBase.sql, luego ejecutar con "EXEC PoblarBase"

# 6. Ejecutar
dotnet run

o simplemente correr con el boton de Visual Studio por https
```

La API queda disponible en `https://localhost:5140`. Swagger en `https://localhost:5140/swagger`.

---

## Patrones de diseño

### Value Objects 
Son clases definidas por su valor que nos permiten hacer que el codigo se proteja asi mismo y que no dependamos de los datos primitivos del lenguaje de programación. Las entidades de dominio nunca se serializan directamente. Los handlers de Application mapean las entidades a DTOs planos antes de retornarlos, extrayendo la propiedad `.Valor` de cada Value Object. Esto evita respuestas anidadas como `{ "nombre": { "valor": "Juan" } }`.

### Patron Mediador (CQRS)
 
CQRS (Command Query Responsibility Segregation) separa las operaciones que **modifican estado** (Commands) de las que **leen estado** (Queries). En este proyecto se implementa a través del patron Mediador, donde cada caso de uso es una clase independiente con su propio handler.
 
**El problema que resuelve:** Sin CQRS, un mismo servicio o repositorio termina mezclando lógica de escritura con lógica de lectura. Las escrituras necesitan cargar agregados completos, aplicar invariantes de dominio, disparar eventos, son operaciones complejas que pasan por el modelo de dominio. Las lecturas en cambio casi siempre necesitan datos aplanados(DTO), joins entre tablas, proyecciones específicas por pantalla, nada de eso requiere instanciar entidades con sus Value Objects y reglas de negocio.
 
Meter ambas responsabilidades en el mismo lugar produce servicios que crecen sin control y que mezclan preocupaciones incompatibles. Ademas permite que aplicaciones grandes a futuro puedan optimizar recursos separando bases de datos con diferentes responsabilidades.

## PENDIENTES
Aún quedan áreas de mejora importantes en el sistema. Por un lado, se puede optimizar el manejo de operaciones que involucran múltiples entidades mediante la implementación del patrón Unit of Work junto con transacciones, evitando problemas de concurrencia y asegurando la consistencia de los datos.

Por otro lado, es necesario completar la aplicación de las reglas de dominio dentro de la entidad Cita, garantizando que toda la lógica de negocio se encuentre encapsulada en el dominio y no dispersa en otras capas.

Finalmente, se identifican oportunidades para fortalecer la validación, mejorar la expresividad del modelo y seguir alineando la solución con principios de DDD y Clean Architecture.
