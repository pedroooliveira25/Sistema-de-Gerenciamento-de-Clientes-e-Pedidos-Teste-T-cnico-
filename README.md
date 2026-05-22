# TESTE TÉCNICO (API REST) COM .NET - PATHBIT

### Teste técnico com o objetivo de desenvolver uma API REST em .NET utilizando C#. O foco desse desafio é desenvolver com boas práticas de mercado, design de software e arquiteturas modernas.

- Orientacao de objetos 

- SOLID e Clean Code

- Estrutura em DDD

- Testes unitarios com xUnit

- Banco de dados PostgresSQL

- Documentação com Swagger

Para consultar as regras desse desafio, estou deixando o repositorio:

 https://github.com/pathbit/pathbit-dotnet-test-level-1

 ### Um pouco sobre como foi desenvolver esse projeto...

Essa foi a primeira vez que tive contato com C# e .NET. Optei por desenvolver no VS Code e, no decorrer do caminho, descobri que talvez não tenha sido a melhor escolha, principalmente depois de perceber que a Microsoft disponibiliza o Visual Studio, que já faz praticamente tudo de maneira mais fácil.

Bom, sem desculpas por aqui, percorri o caminho das pedras e tive muitos problemas com versões do .NET e referências com namespace e using. Demorou um pouco para entender como funciona essa estrutura.

Continuando o desenvolvimento, percebi que entender que algo faz sentido porque simplesmente “tem que fazer sentido” é bem difícil, principalmente quando você não tem uma visão material sobre o objeto e sim abstrata.

Talvez você pense que o código é a parte mais difícil, mas vou lhe dizer que não. Ter formulações lógicas e raciocínio estruturado é extremamente difícil nesse começo da minha jornada.

 ## Vamos falar de SOLID e DDD meu amigo...

Já teve momentos em que você estava desenvolvendo algo e, por mais que estivesse funcionando, vinha aquela pergunta: “será que isso está certo? tudo junto aqui?”

Bom, eu tive esse questionamento quando estava desenvolvendo um projeto em Java e descobri, por conta desse desafio, que o uso de DDD e SOLID facilita tudo — ou complica, hahaha.

Demorei dois dias para “entender” esse conceito, porém, quando você chega no código, precisa ficar bem atento para não misturar responsabilidades.

A ideia de que uma classe deve ter “poder” apenas sobre si mesma é complicada quando você está entusiasmado com código, código, código...

## Estado do projeto(PENDENTE)

Por mais que eu tenha tido tempo para concluir este projeto (1 semana e 5 dias), infelizmente me perdi em alguns conceitos e problemas que eu não sabia resolver, o que me fez dedicar mais tempo para conseguir avançar.

Porém, irei concluir este desafio, independentemente dos problemas ou do prazo.

### Pendencias:
- Implementação de testes unitários utilizando o framework xUnit
- Proteção dos endpoints da API com autenticação Basic
- POST: no envio da ordem, deve-se buscar o endereço de entrega através do serviço viacep.com.br. Caso o endereço não exista, o envio da ordem deve ser negado
- Configuração para execução em Docker
- Fazer um overview da aplicação e verificar se há códigos desnecessários
- Corrigir bugs e lógica dos endpoints para fazer uma documentação melhor com Swagger.

## Fluxos de pensamento utilizados para construir esta API
### Um pouco de como estruturei as coisas...
 <p aling="center">
    <img src="src/img/Img01.png" width="270" />
    <img src="src/img/img2.png" width="380" />
    <img src="src/img/Img03.png" width="800" />
    <img src="src/img/Img04.png" width="400" />
 </p>
 
 ## Conclusão:
 Neste projeto tive a oportunidade de aprender e aplicar conceitos que realmente envolvem uma estrutura limpa e profissional no mercado de trabalho. Graças às minhas dificuldades, pude ter acesso a fluxos de camadas e ao pensamento lógico que devo ter antes de começar a criar uma aplicação. Acredito que ter uma visualização clara sobre o tipo de trabalho que está em suas mãos te livra de passar dificuldades pelo caminho. Irei continuar estudando, não só sobre .NET, mas sobre todo o conjunto que faz parte da criação de um sistema bem resolvido consigo mesmo. Quero também agradecer à equipe da PATHBIT, que disponibilizou todos os recursos para que isso pudesse ser feito! 

Já já publico o desafio 2!