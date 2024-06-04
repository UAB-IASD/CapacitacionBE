# CapacitacionBE
Sistema de HUB

```
| SUINT.Hub.Nombre.Api (Folder Soluction)
├── Nombre.Domain (Proyect Class Library)
|   ├── Adapters
|   ├── Common
|   ├── Exceptions
|   ├── Models
│   └── Repositories
├── Nombre.Application (Proyect Class Library)
|   ├── Common
|   ├── Exceptions
|   ├── Providers
│   └── Services
├── Nombre.Infrastructure (Proyect Class Library)
|   ├── Database
|   |   ├─── Dapper  
|   |   └─── EntityFramework  
|   |        ├─── Entities
|   |        ├─── Extensions
|   |        └─── Repositories
|   ├── Ioc
|   |   └─── Di  
|   ├── Providers
|   |   └─── Validators
├── Api (Folder Solution)
│   └── Nombre.Api (Proyect Web Api)
├── Test (Folder Solution)
│   └─── Nombre.Domain.Test  (Proyecto Unit Test)
│   └─── Nombre.Aplication.Test  (Proyecto Unit Test)
│        └─── Common
│        └─── Mock

```
