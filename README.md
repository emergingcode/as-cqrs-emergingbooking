# Curso: Arquitetura de Software CQRS

Os projetos de tecnologia tem exigido, dos profissionais, conhecimento não só em tecnologia e programação, como também habilidades de alinhar estratégias de negócio com uma arquitetura de software robusta, capaz de ser evolutiva e flexível às mudanças. Permitindo que a entrega de soluções tecnológicas amplifique e dê suporte aos planos de negócios dentro do mundo digital.

Atacar a complexidade em projetos de grande porte não é uma tarefa fácil e, muitas vezes, devido a falta de conhecimento sobre qual técnica deve ser aplicada, qual a tecnologia é a mais adequada, por exemplo, pode levar um projeto ao fracasso.

O curso de Arquitetura de Software Moderna usando CQRS vai te tornar um profissional de tecnologia atualizado com o mercado, usando técnicas de desenvolvimento que são utilizadas em projetos grandes e complexos de software. Este curso alinha teoria e prática, por isso a implementação de CQRS será mostrada não sobre a perspectiva de um framework, mas sim através da implementação de todo o conceito de CQRS from scratch, ou seja, do Zero ao Sucesso, através de um problema de domínio no estilo Booking.com.

Após concluir este curso, você vai ter aprendido as diferenças entre CQS e CQRS, tendo implementado CQRS de forma correta, compreendendo que CQS está relacionado aos padrões aplicados ao código, enquanto que CQRS foca em como a solução da sua arquitetura será definida. Para alcançar tudo isso você vai utilizar o sistema de mensageria mais cobiçado do mercado: Apache Kafka, você também vai implementar Serviços de Background usando a última versão do Aspnet Core: a versão 5.0, incluindo o desenvolvimento de Web APIs de escrita e leitura. Além disso, você também vai aprender a utilizar um banco de dados NoSql mais robustos do mercado e que desde a sua 1° versão trabalha com transações: RavenDB, além de aprender técnicas de modelagem usando Domain Driven Design, construindo uma arquitetura robusta e resiliente.

Esse curso vai te ajudar a alavancar a sua carreira como profissional de tecnologia.

[Clique aqui](https://www.emergingcode.com.br/arquitetura-de-software-cqrs/) para mais detalhes sobre o curso

## Público Alvo
Desenvolvedores Pleno e Senior, Arquitetos de Software, Tech Leads, Team Leads, Tech Managers.

## Pré-Requisitos Desejaveis
- Conhecimento básico de desenvolvimento Web
- Conhecimento básico sobre a linguagem C#
- Conhecimento básico sobre HTTP/REST
- Conhecimento básico de mensageria
- Conhecimento básico de Padrões de Projeto

## Tecnologias utilizadas

- .NET 5.0
- [MonoidSharpDotNet](https://github.com/jr-araujo/MonoidSharpDotNet)
- Background Service
- Apache Kafka
- SQL Server
- RavenDB
- Polly
- Docker
- Docker Compose
- Powershell
- Shell Script

# Como usar o repositório

#### Clonando o repositório
Ao baixar o repositório do projeto, atente-se onde você vai clonar o projeto. Dependendo do nível de profundidade de pastas que você use no momento de clonar o projeto, você pode cair no problema de limitação do número de caracteres que um PATH (caminho de pastas) pode ter no windows. Aconselhamos sempre clonar o projeto em uma pasta mais próxima do driver que você estiver usando (C:, D:, etc.)

#### Branches
Este repositório só possui uma única branch, chamada: **main**, assim que você baixar o repositório, você terá a versão FINAL do projeto. Para reconstruir esse projeto, você precisa acompanhar as vídeo aulas disponibilizadas na plataforma da Hotmart em sua área de membros, e também ficar atento(a) as descrições que existem em alguns vídeos e no grupo do telegram.

#### Automação do ambiente de desenvolvimento
Dentro da pasta [dev-setup](https://github.com/emergingcode/arquitetura-moderna-sw-cqrs-emergingbooking/tree/main/dev-setup) você vai encontrar todos os scripts de automação para criar os containers que serão usados no seu ambiente de desenvolvimento. Mas para esse script rodar 100%, você precisa executar um app linux [Dos2Unix](http://dos2unix.sourceforge.net/) para o arquivo [Entrypoint.sh](https://github.com/emergingcode/arquitetura-moderna-sw-cqrs-emergingbooking/blob/main/dev-setup/entrypoint.sh), que é responsável por criar a base de dados e as tabelas dentro da instância do SQL Server.

Esse procedimento vai converter os caracteres de final de linha do MODO DOS (Windows) para o MODO UNIX (Linux). Esse passo é necessário porque quando o script [run.ps1](https://github.com/emergingcode/arquitetura-moderna-sw-cqrs-emergingbooking/blob/main/dev-setup/run.ps1) é executado, ele chama o docker-compose.yaml e, no passo que monta o SQL Server, o script **entrypoint.sh** é copiado para dentro do container LINUX do SQL Server e é então aplicado contra o SQL Server Linux.

Sem esse passo, a automação não vai instanciar o container do SQL Server conforme esperado.
