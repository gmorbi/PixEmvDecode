#  Decode para EMV (Copia e Cola) do PIX

Essa implementação tem como finalidade exemplificar como pode ser lido e decodificado o EMV, dessa forma você pode usar na sua aplicação da maneira mais simples possível.

O BR Code é o padrão usado para geração de QR Codes no Brasil. Adota o padrão EMV para uso de QR Codes em sistemas de pagamento (EMV-QRCPS).  

O padrão EMV trabalha com dois fluxos distintos: o QR Code apresentado pelo recebedor (MerchantPresented Mode - MPM) e o QR Code apresentado pelo pagador (Consumer Presented Mode - CPM)

O BR Code trata apenas do primeiro.  
O QR Code Pix, na qualidade de mecanismo para envio ou disponibilização prévia de informações para fins de iniciação de um Pix, seguirá o padrão do BR Code, nos termos do Manual do BR Code  

[Documentação do Bacen](https://www.bcb.gov.br/content/estabilidadefinanceira/pix/Regulamento_Pix/II_ManualdePadroesparaIniciacaodoPix.pdf).

##  Campos Importantes do PIX
Aqui estão alguns dos campos mais relevantes que você pode extrair:

00: Versão do payload (sempre 01).

26: Contém a chave PIX (subcampo 01) e o GUI do PIX (subcampo 00).

52: Código do merchant (sempre 0000).

53: Moeda (sempre 986 para BRL).

54: Valor da transação (opcional).

58: Código do país (sempre BR).

59: Nome do beneficiário.

60: Cidade do beneficiário.

62: Informações adicionais (como referência da transação).

##  Exemplo de EMV Pix Copia e Cola:
00020126580014BR.GOV.BCB.PIX0136123e4567-e12b-12d1-a456-426655440000520400005303986540510.005802BR5913Fulano de Tal6008BRASILIA62070503***6304

##  Exemplo de saída do Decode:

Dados do PIX:  
00: 01  
26: 580014BR.GOV.BCB.PIX0136123e4567-e12b-12d1-a456-426655440000  
52: 0000  
53: 986  
54: 10.00  
58: BR  
59: Fulano de Tal  
60: BRASILIA  
62: 0503***  
63: 04  

Chave PIX: 123e4567-e12b-12d1-a456-426655440000  
Valor: 10.00  
Beneficiário: Fulano de Tal  
Cidade: BRASILIA

##  Dicas Extras
###  Validação:

Verifique se o campo 00 é igual a 01 (versão do payload).

Confira se o campo 53 é 986 (moeda BRL).

###  Tratamento de Erros:

Adicione validações para garantir que o payload esteja no formato correto.

Use TryParse para evitar erros ao converter tamanhos ou valores.

###  Extensibilidade:

Se precisar de mais campos, basta adicionar novos IDs ao parser.
