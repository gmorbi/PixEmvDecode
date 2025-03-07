#  Decode para EMV (Copia e Cola) do PIX

#  Campos Importantes do PIX
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

#  Exemplo de EMV Pix Copia e Cola:
00020126580014BR.GOV.BCB.PIX0136123e4567-e12b-12d1-a456-426655440000520400005303986540510.005802BR5913Fulano de Tal6008BRASILIA62070503***6304

#  Exemplo de saída do Decode:

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

#  Dicas Extras
#  Validação:

Verifique se o campo 00 é igual a 01 (versão do payload).

Confira se o campo 53 é 986 (moeda BRL).

#  Tratamento de Erros:

Adicione validações para garantir que o payload esteja no formato correto.

Use TryParse para evitar erros ao converter tamanhos ou valores.

#  Extensibilidade:

Se precisar de mais campos, basta adicionar novos IDs ao parser.
