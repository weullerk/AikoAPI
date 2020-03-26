# Prova Técnica Aiko

API para cadastrar, administrar e consumir pontos de interesses.
CRUD nos padrões RESTful com DDD, Design Patterns e principios SOLID.

## Apresentação
Desenvolvi a aplicação separando as camadas, DDD, Application, Infra e API,
para que tenha uma baixa dependência(Loosely Coupled) entre as camadas entre sí,
e possa facilitar uma implementação ou substituição de algum recurso.
Aplicando as orientações do SOLID, e também utilizando Auto Mapper,
para organizar os mapeamentos, deixando o código mais consciso e organizado,
e Fluent para gerenciar as validações de entrada de dados.

API: Essa camada é responsavel somente pela api, possui validações dos dados,
mapeamento das requisições e faz a comunicação com a camada da aplicação
para que essa consuma o serviço do oferecido pelo dominio.

Application: Camada que consome os serviços do dominio e faz algumas validações
de integridade, consumindo alguns serviços do dominio para dar prosseguimento as
operações.

DDD: Camada onde contem a regra de negocio principal, nesse caso a persistencia dos 
pontos de interesse, que a faz abstraindo a camada de persistencia - infraestrutura,
para que possa a possibilidade de se fazer outra implementação para que se provenha
um outro serviço de persistencia se necessário.

Infra: Essa camada possui a implementação a interface de repositorio do dominio,
e sua resposabilidade é fazer a integração com o banco de dados e prover a implementação
dos serviços de armazenamento e leitura para o dominio.


## Requisitos

A aplicação foi desenvolvida sob o ASP.NET Core WebAP; informações no link abaixo:

https://docs.microsoft.com/en-us/dotnet/core/about

## Executar aplicação

Para executar essa aplicação em seu computador, siga os passos abaixo:

1) Clone este repositório, importe-o no visual studio e execute a aplicação.

```shell
$ git clone https://github.com/weullerk/Teste-Aiko.git
```
2) Execute o comando "Update-Database" no projeto "Infra" no Package Manager Console
para criar a database local.


## Contexts
Ponto de Interesse - Dominio Principal

## Glossário
Ponto de Interesse - Pessoa Física ou Júridica que possui conta no banco.

## Referências

Domain Driven Design - O que você precisa saber - School Of Net

https://www.youtube.com/watch?v=E-1rcCzAOi0

O que é SOLID: O guia completo para você entender os 5 princípios da POO

https://medium.com/joaorobertopb/o-que-%C3%A9-solid-o-guia-completo-para-voc%C3%AA-entender-os-5-princ%C3%ADpios-da-poo-2b937b3fc530

## Plugins
AutoMapper (Mapeamento de classes)

https://github.com/AutoMapper/AutoMapper

Fluent (Validação de dados)

https://github.com/FluentValidation/FluentValidation

Swagger (Documentação da API)

https://github.com/domaindrivendev/Swashbuckle.AspNetCore