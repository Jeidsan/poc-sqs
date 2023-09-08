# POC SQS

Este projeto tem por objetivo avaliar a viabilidade de consumo e processamento de eventos de consentimentos gerados pelo motor de consentimentos da empresa X no contexto do Open Finance Brasil.

## Tipos de Eventos

Os tipos de evento qiue nos interessa são os seguintes:

- openbanking-consents-state: para consentimentos onde a empresa Y atua como detentora de conta;
- openbanking-pisp-received: para os consentimentos onde a empresa Y atua como iniciadora de transação de pagamentos;

Além disso, podem ocorrer eventos dos seguintes tipos:

- openbanking-consents-validate
- openbanking-tpp-consents-received
- openbanking-tpp-payment-received


## Eventos

Dentro dos tipos de eventos listados acima, podem ocorrer os seguintes eventos:

- CREATED
- AUTHORISATION_FAILED
- AUTHORISATION_COMPLETED
- AUTHORISATION_REVOKED
- AUTHORISATION_CONSUMED
- CONSENT_UPDATED
- CONSENT_TIMEOUT_EXPIRED
- CONSENT_OVERDUE
- APPROVERS_STATUS_UPDATED
- VALIDATION
- NOT_ACCEPTED
- EXPIRED
- EXPIRING
- CONSUMED_REVOKED
- AUTHORISED_TIMEOUT_EXPIRED

## Estrutura do projeto

### SQS.Model

Trata-se de uma biblioteca contendo as classes compartilhadas entre os demais projetos da solução.

### SQS.Producer

Trata-se de uma API que permite registrar eventos numa fila SQS pré-configurada;

### SQS.Consumer

Trata-se de um worker que monitora e consome os eventos da fila SQS e registra-os numa interface textual.

### Payloads

Trata-se de uma pasta contendo modelos para vários eventos de interesse para o processo da empresa Y.

## Execução do projeto

Para criar eventos na fila SQS:

1. Inserir os dados da fila SQS no arquivo appSettings.json do Producer;
2. Executar o Producer (`dotnet run --project= .\SQS.Producer\SQS.Producer.csproj --urls=https://localhost:5000`);
3. Copiar o conteúdo de algum evento na pasta Payloads;
4. Executar um POST para https://localhost:5000, passando o conteúdo copiado como payload;

Para consumir os eventos da fila:

1. Inserir os dados da fila SQS no arquivo appSettings.json do Consumer;
2. Executar o Consumer (`dotnet run --project= .\SQS.Consumer\SQS.Consumer.csproj`)