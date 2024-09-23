

# ![](/assets/api.png) Cliente API

Este é um projeto de uma solução on-premise para fazer o cadastro e busca de um modelo de clientes hipotético. O desenvolvimento foi feito em C# e consiste de um microserviço com endpoints que persistem no banco de dados MySql. O projeto possui um docker compose para que seja possível testá-lo.

## Tecnologias e Frameworks Utilizados
- .NET/C#
- REST APIs
- AutoMapper
- Newtonsoft - Json.NET
- MySQL
- Docker

## Funcionalidades
### ClienteCadastro.html
- Form para cadastro de um registro de cliente.
  
### ClienteAPI Service
- Serviço que faz o cadastro de clientes persintindo em um banco de dados MySQL. Deve ser acessado pela porta 5106.

#### Validações do Cadastro
- Nome e obrigatório e deve ter menos de 100 caracteres
- Sobrenome e obrigatório e deve ter menos de 200 caracteres
- CPF é obrigatório e deve ser válido
- CEP é validado na API do serviço https://viacep.com.br/

### Banco de Dados (Migrations)
- As migrations são executadas ao subir os serviços.

## ClienteAPI Service Endpoints

### **[POST]**
`/cliente` - endpoint para cadastro de um receiver  
    - Entrada: JSON de CreateClienteDto.  
    - Ação: Cadastra o cliente recebido.
    - Saída: JSON com o cliente cadastrado e status 201.

### **[GET]**
`/cliente` - endpoint para buscar todos os clientes cadastrados no banco  
    - Entrada: não possui.  
    - Ação: Busca no banco os clientes cadastrados.  
    - Saída: JSON com todos os clientes cadastrados.  

`/cliente/{id}` - endpoint para buscar por id um cliente cadastrado no banco
    - Entrada: Parâmetro de ID na URI.  
    - Ação: Busca no banco o receiver com o id passado.  
    - Saída: JSON com o receiver buscado.  

## Exemplos de JSON

### CreateClienteDto
```json
{
    "nome" : "Nome",
    "sobrenome" : "Sobrenome",
    "cpf" : "715.614.180-56",
    "email" : "teste@teste.com",
    "telefone" : "222333125",
    "endereco" : 
    {
        "rua" : "Rua",
        "numero" : "123", 
        "complemento" : "SEM",
        "bairro" : "bairro",
        "cidade" : "cidade",
        "estado" : "CE",
        "cep" :  "69906-290"
    }
}
```