# Domain

**Domain layer** describe what our application does.

## Deep structure exemple

```text
├── Core
├── Data
├── Presentation
└── Domain
    ├── Model
    │   ├── Todo.ts
    │   └── User.ts
    ├── Repository
    │   ├── TodoRepository.ts
    │   └── UserRepository.ts
    └── UseCase
        ├── Todo
        │   ├── GetTodos.ts
        │   ├── GetTodo.ts
        │   ├── DeleteTodo.ts
        │   ├── UpdateTodo.ts
        │   └── CreateTodo.ts
        └── User
            ├── GetUsers.ts
            ├── GetUser.ts
            ├── DeleteUser.ts
            ├── UpdateUser.ts
            └── CreateUser.ts
```
