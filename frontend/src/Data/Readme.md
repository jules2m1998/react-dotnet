# Data

The **DATA** layer will keep all the external dependency-related code as to **HOW** they are implemented:

## Deep structure example

```text
├── Core
├── Domain
├── Presentation
└── Data
    ├── Repository
    │   ├── TodoRepositoryImpl.ts
    └── DataSource
        ├── TodoDataSource.ts
        ├── API
        │   ├── TodoAPIDataSourceImpl.ts
        │   └── Entity
        │       ├── TodoAPIEntity.ts
        │       └── UserAPIEntity.ts
        └── DB
            ├── TodoDBDataSourceImpl.ts
            └── Entity
                ├── TodoDBEntity.ts
                └── UserDBEntity.ts
```
