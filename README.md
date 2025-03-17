# LiftVerse API

LiftVerse � uma API para que os usu�rios possam criar e gerenciar seus treinos de muscula��o. Com ela, � poss�vel controlar s�ries, exerc�cios, repeti��es, cargas e muito mais.

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- Fluent Validation
- AutoMapper
- Autentica��o via JWT

## Endpoints Principais

### Usu�rio

| M�todo | Endpoint | Descri��o |
|--------|---------|-----------|
| `GET` | `/api/usuario` | Retorna todos os usu�rios (Apenas Admin) |
| `POST` | `/api/usuario` | Cria um novo usu�rio |
| `PUT` | `/api/usuario` | Edita um usu�rio existente (autorizado apenas para o pr�prio usu�rio ou Admin) |
| `DELETE` | `/api/usuario` | Exclui um usu�rio (autorizado apenas para o pr�prio usu�rio ou Admin) |
| `POST` | `/api/usuario/autenticar` | Autentica um usu�rio e retorna um token JWT |

### Treino

| M�todo | Endpoint | Descri��o |
|--------|---------|-----------|
| `POST` | `/api/treino` | Cria um treino |
| `PUT` | `/api/treino` | Edita um treino existente |
| `GET` | `/api/treino` | Retorna todos os treinos do usu�rio autenticado |
| `GET` | `/api/treino/{id}` | Retorna um treino espec�fico |
| `DELETE` | `/api/treino/{id}` | Exclui um treino |

### Exerc�cio

| M�todo | Endpoint | Descri��o |
|--------|---------|-----------|
| `GET` | `/api/exercicio/{id}` | Retorna um exerc�cio pelo ID |
| `POST` | `/api/exercicio` | Cria um novo exerc�cio (Apenas Admin) |
| `PUT` | `/api/exercicio` | Edita um exerc�cio existente (Apenas Admin) |
| `DELETE` | `/api/exercicio/{id}` | Exclui um exerc�cio (Apenas Admin) |
| `GET` | `/api/exercicio` | Lista os exerc�cios paginados |

## Autentica��o

A API utiliza autentica��o via JWT. Para acessar os endpoints protegidos, � necess�rio enviar um token v�lido no cabe�alho da requisi��o:

```http
Authorization: Bearer {seu_token_aqui}
```

## Contribui��o

Caso queira contribuir com o projeto, siga os seguintes passos:

1. Fork este reposit�rio
2. Crie uma branch para sua feature (`git checkout -b minha-feature`)
3. Commit suas mudan�as (`git commit -m 'Adicionando minha feature'`)
4. Envie para o branch principal (`git push origin minha-feature`)
5. Abra um Pull Request

## Licen�a

Este projeto est� sob a licen�a MIT.

