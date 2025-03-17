# LiftVerse API

LiftVerse é uma API para que os usuários possam criar e gerenciar seus treinos de musculação. Com ela, é possível controlar séries, exercícios, repetições, cargas e muito mais.

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- Fluent Validation
- AutoMapper
- Autenticação via JWT

## Endpoints Principais

### Usuário

| Método | Endpoint | Descrição |
|--------|---------|-----------|
| `GET` | `/api/usuario` | Retorna todos os usuários (Apenas Admin) |
| `POST` | `/api/usuario` | Cria um novo usuário |
| `PUT` | `/api/usuario` | Edita um usuário existente (autorizado apenas para o próprio usuário ou Admin) |
| `DELETE` | `/api/usuario` | Exclui um usuário (autorizado apenas para o próprio usuário ou Admin) |
| `POST` | `/api/usuario/autenticar` | Autentica um usuário e retorna um token JWT |

### Treino

| Método | Endpoint | Descrição |
|--------|---------|-----------|
| `POST` | `/api/treino` | Cria um treino |
| `PUT` | `/api/treino` | Edita um treino existente |
| `GET` | `/api/treino` | Retorna todos os treinos do usuário autenticado |
| `GET` | `/api/treino/{id}` | Retorna um treino específico |
| `DELETE` | `/api/treino/{id}` | Exclui um treino |

### Exercício

| Método | Endpoint | Descrição |
|--------|---------|-----------|
| `GET` | `/api/exercicio/{id}` | Retorna um exercício pelo ID |
| `POST` | `/api/exercicio` | Cria um novo exercício (Apenas Admin) |
| `PUT` | `/api/exercicio` | Edita um exercício existente (Apenas Admin) |
| `DELETE` | `/api/exercicio/{id}` | Exclui um exercício (Apenas Admin) |
| `GET` | `/api/exercicio` | Lista os exercícios paginados |

## Autenticação

A API utiliza autenticação via JWT. Para acessar os endpoints protegidos, é necessário enviar um token válido no cabeçalho da requisição:

```http
Authorization: Bearer {seu_token_aqui}
```

## Contribuição

Caso queira contribuir com o projeto, siga os seguintes passos:

1. Fork este repositório
2. Crie uma branch para sua feature (`git checkout -b minha-feature`)
3. Commit suas mudanças (`git commit -m 'Adicionando minha feature'`)
4. Envie para o branch principal (`git push origin minha-feature`)
5. Abra um Pull Request

## Licença

Este projeto está sob a licença MIT.

