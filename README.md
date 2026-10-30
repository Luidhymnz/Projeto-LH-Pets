# LH-Pets — Web API em ASP.NET Core

Web API desenvolvida em C# (ASP.NET Core, padrão Controllers) para a empresa **LH-Pets**, com cadastro e listagem de **Clientes** e **Pets**. Os dados ficam em memória (`List<T>`), sem banco de dados, e o vínculo entre as entidades é feito por `ClienteId`.

## Tecnologias
- C# / .NET 8
- ASP.NET Core Web API (Controllers)
- Swagger (Swashbuckle) para documentação e testes
- Data Annotations para validação

## Estrutura
```
LH-Pets/
├── Controllers/
│   ├── ClientesController.cs
│   └── PetsController.cs
├── Data/
│   └── DadosEmMemoria.cs
├── Models/
│   ├── Cliente.cs
│   └── Pet.cs
├── Properties/launchSettings.json
├── Program.cs
└── LHPets.csproj
```

## Como executar
Pré-requisito: [.NET 8 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/SEU_USUARIO/LH-Pets.git
cd LH-Pets
dotnet run
```

Acesse o Swagger em: **https://localhost:7100/swagger**
(se a porta for diferente, use a que aparecer no terminal).

## Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/clientes` | Lista todos os clientes |
| POST | `/api/clientes` | Cadastra um cliente |
| GET | `/api/pets` | Lista todos os pets |
| POST | `/api/pets` | Cadastra um pet vinculado a um cliente |
| GET | `/api/pets/cliente/{clienteId}` | Lista os pets de um cliente |

### Exemplos

**POST /api/clientes**
```json
{ "nome": "Maria Silva", "cpf": "123.456.789-00", "email": "maria@email.com" }
```

**POST /api/pets**
```json
{ "nome": "Rex", "especie": "Cachorro", "raca": "Labrador", "clienteId": 1 }
```

## Validações
- Campos obrigatórios (nome, CPF, e-mail, espécie) e formato de e-mail → `400 Bad Request`
- CPF duplicado ao cadastrar cliente → `409 Conflict`
- `ClienteId` inexistente ao cadastrar pet ou consultar pets por cliente → `404 Not Found`
- Ids gerados automaticamente (sequenciais)

## Roteiro de testes no Swagger
1. `POST /api/clientes` com o exemplo acima → `201 Created`
2. `POST /api/pets` com `clienteId: 1` → `201 Created`
3. `GET /api/clientes` e `GET /api/pets` → listas preenchidas
4. `GET /api/pets/cliente/1` → pets da Maria
5. `GET /api/pets/cliente/99` → `404`

> Os dados são perdidos ao reiniciar a aplicação (armazenamento em memória).

## Autor
André Luidhy Menezes Barbosa
GitName: Luidhymnz
