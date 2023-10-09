# OrderManagerSample

O OrderManagerSample é um gerenciador de ordem simples que tem como objetivo somente criar uma ordem e esperar a resposta de sucesso ou falha da criação da ordem.

- Está aplicação deve ser feita em dotnet 6.0  deve funcionar tanto no windows quanto no linux.
- Deve rodar em docker em um container linux.
- para a criação da ordem deve ter um endpoint que recebe um post no seguinte formato:
localhost:1000/v1/create_order
```
  { 
    account: <string>, conta da pessoa
    symbol: <string>, identifica o ativo
    side: COMPRA | VENDA, 
    qty: 100, 
    price: 12,00
  }
```
que deve retornar outro json informando Ok ou Error. O error irá ocorrer se e somente se a quantidade for menor ou igual a zero ou account ou symbol for vazio,
caso contrário retornar OK.
