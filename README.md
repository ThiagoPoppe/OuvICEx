# OuvICEx - Ouvidoria do Instituto de Ciências Exatas

## Membros e papéis
- Ana Flavia de Miranda Silva [FrontEnd Developer]
- Fernando Tonucci de Cerqueira Oliveira [FullStack Developer]
- Giovanna Louzi Bellonia [FullStack Developer]
- Thiago Martin Poppe [BackEnd Developer]	

---

## Funcional (objetivo do sistema, principais features, etc)
### Objetivo do Sistema
- Trata-se de um sistema web de ouvidoria para denúncias e reclamações aberto aos alunos do ICEx.

### Principais features
- **Clientes:** os clientes do sistema podem:
    1. Acessar um histórico de todas as postagens, e outras representações como gráficos e estatísticas;
    2. Postar sugestões, reclamações e/ou denúncias anônimas ou públicas;
    3. Informar o departamento alvo do seu comentário.
- **Administradores:** os administradores podem:
    1. Gerenciar as postagens;
    2. Atualizar a situação dos envios (marcar como resolvido ou não).

### Tecnologias
- FrontEnd:
	- HTML
	- CSS
	- Bootstrap
	- Angular ou JavaScript
- Backend:
    - C# ou Java
- Banco de Dados:
    - MySQL
- Deployment:
    - Heroku
---

## Backlog do produto
- Como usuário do sistema, eu gostaria de poder me cadastrar e logar no sistema.
- Como usuário do sistema, eu gostaria de fazer postagens, sendo cadastrado no sistema ou não, e informar o departamento alvo do meu comentário;
- Como usuário do sistema, eu gostaria de no momento de envio de denúncias escolher se ela poderá ser vista de forma pública ou não;
- Como usuário logado no sistema, eu gostaria de visualizar as postagens feitas por mim;
- Como administrador do sistema, eu gostaria de poder atualizar a situação dos envios;
- Como administrador do sistema, eu gostaria de poder selecionar quais postagens serão publicadas.
- Como usuário do sistema, eu gostaria de ser capaz de ler e filtrar as postagens feitas;
- Como administrador do sistema, eu gostaria de poder encaminhar postagens do tipo denúncia para o departamento alvo da postagem;

## Backlog da sprint
- Tarefas técnicas:
    - Preparar o ambiente de desenvolvimento da API (código inicial) [Thiago + Giovanna]
    - Preparar o ambiente de desenvolvimento do front (código inicial) [Fernando + Ana]
    - Discutir e criar esquema do banco de dados [Giovanna + Fernando]

- Como usuário do sistema, eu gostaria de poder me cadastrar e logar no sistema.
 Tarefas:
    - Criar estrutura do banco de dados que permita o cadastro de usuários; [Giovanna]
    - Criar rotas de cadastro e login; [Giovanna]
    - Criar páginas de cadastro e login; [Giovanna]

- Como usuário do sistema, eu gostaria de fazer postagens, sendo cadastrado no sistema ou não, e informar o departamento alvo do meu comentário.
 Tarefas:
    - Criar estrutura do banco de dados para armazenar os envios; [Thiago]
    - Criar página com um formulário funcional para os envios que permita atrelar a postagem ao usuário logado se ele assim o desejar; [Ana e Thiago]
    - Criar rota para envios de sugestôes, reclamações, denúncias ou elogios; [Ana e Thiago]

- Como usuário do sistema, eu gostaria de no momento de envio de denúncias escolher se ela poderá ser vista de forma pública ou não.
 Tarefas:
    - Criar um campo booleano no formulário para o caso de postagens dos tipos reclamação ou denúncia que permita selecionar se ela será pública. [Ana]
    - Adicionar campo booleano no banco de dados e no objeto de postagens existentes na API. [Thiago]

- Como usuário logado no sistema, eu gostaria de visualizar as postagens feitas por mim.
 Tarefas:
    - Criar página para exposição das postagens feitas pelo usuário logado no sistema, permitindo que ele visualize também o status da postagem. [Fernando]
    - Criar rota que retorna todas as postagens do usuário logado. [Fernando]

## Backlog futuro
- Como administrador do sistema, eu gostaria de poder atualizar a situação dos envios.
 Tarefas:
    - Criar a página de login do administrador;
    - Criar a página do administrador, que estará conectado ao banco de dados contendo as postagens;
    - Adicionar botão que marca as postagens como resolvidas ou não
    - Criar filtros específicos por data, departamento (denunciado e usuário), tipo e status da postagem

- Como administrador do sistema, eu gostaria de poder selecionar quais postagens serão publicadas.
 Tarefas:
    - Criar um botão que torna uma postagem pública, esse botão só deverá estar disponível nas postagens na qual o usuário assim o permitiu.

- Como usuário do sistema, eu gostaria de ser capaz de ler e filtrar as postagens feitas.
 Tarefas:
    - Criar a página para exposição dos comentários.
    - Criar filtros específicos por data, departamento (denunciado e usuário), tipo e status da postagem.

- Como administrador do sistema, eu gostaria de poder encaminhar postagens do tipo denúncia para o departamento alvo da postagem.
 Tarefas:
    - Criar estrutura do banco de dados que relaciona o departamento e o email para qual postagens do tipo denúncia devem ser encaminhadas;
    - Criar página para que o administrador cadastre, edite e remova departamentos e seus emails para envio de denúncias;
    - Adicionar botão que encaminha automaticamente a postagem a qual ele está associado para o departamento alvo do comentário.
