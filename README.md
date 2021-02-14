# Rearquitetando sistemas legados aplicando CQRS

## descrição
Quando se está rearquitetando sistemas computacionais, é perfeitamente natural que as pessoas envolvidas no processo desse desenvolvimento tragam uma série de padrões arquiteturais como soluções para resolver problemas antigos. No entanto, vem se observando na indústria de software que a utilização de alguns padrões está sendo feita com alguns equívocos, no que diz respeito ao entendimento dos conceitos e de suas aplicabilidades. Este curso traz uma abordagem, em detalhes, sobre cada preocupação que precisa existe quando se aplica técnicas de reengenharia de sistemas e, também, questões que você sempre teve sobre a implementação de CQRS.

## Público Alvo
Analistas, Desenvolvedores e Arquitetos de Software.

## Pré-Requisitos Desejaveis
Experiência em desenvolvimento web, C#, Asp.Net e HTTP/REST.

## Ementa do Curso
### Dia 1

O primeiro dia do curso será um misto de teoria e prática, onde o foco será esclarecer algumas dúvidas sobre esses acrônimos e responder algumas perguntas, como: O que é? Para que serve? Quando se aplica? e Que benefícios um projeto tem ao utilizar uma abordagem arquitetural CQS/CQRS? A outra parte do primeiro dia, está destinada a aplicação de técnicas de Análise, Refatoração e Redesenho de uma aplicação legada onde não foram aplicadas boas práticas arquiteturais, utilizando técnicas de identificação sobre quais tarefas/eventos acontecem no sistema e quais ações são demandadas.

* Introdução ao curso
  * Apresentação sobre métodos didáticos utilizados no decorrer do curso.
* O que são as abordagens arquiteturais CQRS e CQS e o que elas resolvem?
  *Sempre que se fala em CQS pensa-se logo: Mas não seria CQRS? É com base nessa dúvida que nesta parte do curso será apresentada as principais diferenças conceituais e arquiteturais entre as essas duas abordagens.
* Apresentação da primeira fase do projeto base do curso: Arquitetura altamente acomplada e sem separação de responsabilidade!
  * Todo desenvolvedor, consultor ou arquiteto de soluções está mais que habituado a lidar com projetos monolíticos que não possuem nenhum tipo de separação de responsabilidades, o que torna difícil identificar quais são os contextos de negócio dentro do projeto. É com essa visão que iremos enfrentar a primeira fase do projeto, completamente descontextualizado e desorganizado. Essa abordagem traz uma situação muito próxima da realidade e tem o objetivo de passar o conhecimento sobre a prespectiva de reengenharia de um software e como identificarmos contextos e ações, os quais serão agentes de mudança do estado de um sistema.
* Aplicando engenharia reversa para descobrir ações dentro da aplicação
  * Nesta parte do curso, será apresentada técnicas de identificação comportamental com base em Tarefas e Ações. Essa abordagem tem o objetivo de ajudar a identificar:
    * Intenções;
    * Ações;
    * Momentos;
    * Resultados.
* Redesenhando o projeto base utilizando Comandos e Consultas
  * Finalizando o primeiro dia do curso, a primeira fase do projeto passará por um processo de reengenharia com base em fluxos e diagramas, possibilitando adquirir:
    * Visão contextual de negócio;
    * Diagramação do processo de reengenharia;
    * Documentação dos Comandos e Consultas;
    * Visão da organização da solução (Visual Studio).

### Dia 2
O segundo dia trará ainda alguns pontos teóricos, porém o seu maior foco será em sessões mais práticas (Hands-On). Trazendo os conceitos que foram trabalhados no Dia 1, teremos base paratrabalhar os dois principais conceitos e práticas dentro do padrão arquitetural CQS/CQRS: Comandos (Commands) e Consultas (Queries). As sessões iniciais abodarão conceitos, práticas e implementações de Comandos e Consultas, além clarificar quais as diferenças entre um comando e um DTO (Data Transfer Object), bem como a apresentação e explicação de como o CQS/CQRS se encaixa dentro da  Onion Architecture. Aplicar seprações de responsabilidades em uma aplicação, exige que o própio sistema seja resiliente e seja tolerante a falhas. Para resolvermos essas necessidades, o curso trará a implementação do padrão conhecido com Retry Pattern utilizando um framework bastante conhecido, chamado: Polly. Ao final desse dia, vamos abordar as técnicas para separação da base de dados em leitura e escrita.

* Introdução do dia
* Criando o primeiro Commando
  * Neste tópico, utilizando o que foi aprendido em teoria no Dia 1, será apresentado como se criar o primeiro comando dentro da aplicação e quais as mudanças que esse modo de desenvolvimento traz para dentro de uma aplicação tradicional.
* Diferenças entre comandos em CQS e CQRS
  * Aqui vamos entender quais as diferenças existem ou não entre esses dois padrões.
* Explicando a diferença entre Comandos e DTOs
  * Quando se pensa no modelo tradicional de desenvolvimento, logo nos vem a dúvida: Mas um Comando não seria também UM DTO?! Aqui, vamos entender quais são as  diferenças entre eles e quais cenários de aplicação para cada um dessas duas abordagens.
* Onion Architecture
  * Neste momento do Dia 2, vamos entender onde o CQS/CQRS se encaixa dentro do diagrama desse tipo de arquitetura e quais mudanças ocorrem dentro desse diagrama dada a introdução desse padrão.
* Alterando o estado do domínio através de Commandos
  * Um comando tem a responsabilidade de trabalhar sobre a perspectiva da mudança de estado de um domínio! Neste tópico, será apresentado como implementar lógica de negócio dentro de um comando, como trabalhar suas validações e desmisticaremos alguns mitos sobre esta implementação.
* Criando a primeira Query
  * Neste tópico, utilizando o que foi aprendido em teoria no Dia 1, será apresentado como se criar a primeira consulta dentro da aplicação e quais as mudanças que esse modo de desenvolvimento traz para dentro de uma aplicação tradicional.
* Consultando dados através de Queries
  * A consulta é uma das partes mais importantes de uma aplicação. É através das consultas que podemos visualizar os dados que foram inseridos, alterados e, também, através delas podemos realizar validações com base no estado atual de uma aplicação. Dada essa responsabilidade de importância, nessa parte do curso veremos como implementar as consultas (Queries) utilizando o conceito CQS/CQRS.
* Tolerância a falhas e aumento da confiabilidade com uso de Retry Pattern
  * Cada vez mais precisamos escalar sistemas e trablahar a separação de responsabilidades sobre componentes arquiteturais, e isso não é diferente quando aplicamos o padrão CQS/CQRS em sistemas computacionais. Nesta etapa do curso, a questão da resiliência e tolerância a falhas será trabalhada dentro do projeto, implementando Retry Pattern, utilizando um framework famoso chamado: Polly.
* Separando as responsabilidades, simplificando o Modelo de Leitura
  * Vimos no tópico "Consultando dados através de Queries" o quão importante são as consultas para um sistema. Nesta etapa do curso, vamos trabalhar a separação de responsabilidades, não só do ponto de vista da implementação do padrão em código, mas também do ponto de vista dos dados de leitura e dos dados de escrita.
* Introdução a separação das base de dados (Escrita e Leitura)
  * Neste último tópico do dia 2, serão apresentadas as vantagens sobre a separação das base de dados de escrita e leitura, como devemos modelar os dados para obtermos a melhor performance tanto para escrita quanto para leitura.

### Dia 3
O dia 3 apresentará aspectos muito importantes e interessantes desse universo de contextualização de ações, dados e segregação dos dados. A abordagem que será foco do último dia do curso, será o espaço de problema sobre sincronização de dados e como podemos resolver essa necessidade aplicacional utilizando Kafka como plataforma de stream de dados, construindo um Database Sync através de produtores e consumidores Kafka.

* Introdução do dia
* Lidando com eventos do seu dominio na aplicação
  * Este tópico do curso pode gerar dúvidas natuais, como por exemplo: O que eventos tem a ver com CQRS? Bem, TUDO! Aqui será abordado estratégias de atualizações de contextos com o uso de eventos de domínio e a plataforma de stream de dados Kafka.
* Sincronizando o banco de escrita com a base de leitura
  * Após termos separado as base de dados, vem a pergunta: Ok! Agora como vamos fazer para atualizar a base de leitura em relação aos acontecimentos que ocorreram na base de escrita? Aqui será apresentado a abordagem Database Sync utilizando produtores e consumidores Kafka.
* Apresentação do fluxo da aplicação, após Re-Arquitetura para o modelo CQRS
  * Neste último tópico, vamos apresentar a aplicação funcionando em cima de toda a plataforma sistêmica que foi rearquitetada durante todo o curso.

## Objetivos do curso
Este curso visa, além de apresentar conceitos de reengenharia de software, como desmistificar conceitos e padrões computacionais com base e fundamentos, técnicas e implementações sobre a perspectiva de aplicações do mundo real e situações reais. Além dos pontos abordados pela Emerging Code, aqui temos outros objetivos complementares que é colocar nossos alunos em contato com tecnologias que estão sendo utilizadas no mercado e apresenta-los técnicas que os levarão a saber quando inserir essas novas tecnologias em projetos de software. São elas:

* Kafka
* RavenDB
* Polly
* Projetos implementados em dotnet core e standard
* Docker

## Ferramentas
* Visual Studio 2017 (pode usar a versão Community)
* SQL Server 2017 (pode usar as versões: Express / Developer / Container)

## Forma de pagamento
À vista ou parcelado através da plataforma sympla; Boleto Bancário; Débito Online
*Aceitamos as bandeiras: Visa, Master, American Express, Diners, Hiper.*

## Benefícios de você imergir neste curso
* Acesso ao canal exclusivo das video aulas;
* Acesso exclusivo ao repositório de código da turma;
* Certificado Emerging Code de conclusão do curso;
* Suporte para tirar dúvidas.

## Sobre o acesso ao curso on-line
Todos os alunos receberão um hora antes do início das aulas, em suas contas de email (indicadas no momento da inscrição NO SYMPLA), um link para acessar a plataforma utilizada durante o curso.

## Sobre a gravação do Curso
O curso será gravado e disponibilizado através do Vimeo Privado, onde terão acesso apenas os inscritos no curso. 

## Sobre Reembolso e Cancelamento
Após efetuado o pagamento, não teremos suporte ao cancelamento ou reembolso.

## Ficou alguma dúvida?
Antes de realizar a compra do nosso curso, tire todas as dúvidas através do email: **contato@emergingcode.com.br.**



 
