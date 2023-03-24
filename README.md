# Calculadora de Preço Médio
Um sistema para coleta de dados de compra e venda de ativos listados na bolsa de valores brasileira (B3) e cálculo de preço médio dos ativos.

## 📖 Sobre
Esse projeto foi criado com o intuito de auxiliar a declaração de imposto de renda, pois para quem possui ativos listados na bolsa de valores, é necessário declará-los com o valor de custo de aquisição total, ou seja, preço médio de compra X quantidade de ativos.

Esse sistema extrai as informações de compra e venda das notas de negociação de corretoras do grupo XP (XP Investimentos, Rico e Clear), precisando apenas copiar o texto presente nas notas de negociação e colando no front-end do sistema, dessa forma a aplicação extrai as principais informações na negociação como nome do ativo, quantidade, preço de compra, tipo da operação (compra ou venda), tipo do ativo (ação, FII, etc...). Após a extração dos dados, é possível fazer alterações manuais na extração se for necessário, em seguida o sistema armazena essas informações no banco de dados local SQLite.

Com as negociações salvas no banco de dados do sistema, é possível utilizar as funções do sistema para cálcular o preço médio, exibir as informações no datagrid ou inserir manualmente negociações de compra, que pode ser utilizado para inserir a situação de cada ativo na última declaração de IRRF, desta forma o preço médio de cada ativo estará correto para a declaração.

## ⚒️ Tecnologias
- .NET 6.0
- C#
- SQLite
- Entity Framework Core
- WPF

## 🚀 Execução
### Coleta dos Dados
1. Faça o download das notas de negociação na plataforma das corretoras mencionadas.
2. Abra individualmente cada nota de negociação.
3. Para cada nota, copie todo o texto central do arquivo (contém informações como nome do ativo, preço, etc...).
### Inserção dos Dados
1. Cole o texto copiado no textbox, localizado no campo superior esquerdo.
2. Insira a data da operação no campo à direita, onde há o ícone de um calendário.
3. Clique no botão "Calcular"
4. Verifique se as informações estão corretas no datagrid abaixo, é possível realizar alterações no mesmo.
5. Clique no botão "Inserir".
### Inserção Opcional dos Dados
Caso seja necessário inserir negociações de compra, manualmente.
1. Clique no botão "Inserir em Lote"
2. Preencha os campos corretamente.
3. Clique no botão "Inserir".
### Processamento dos Dados
1. Clique no botão "Calcular TUDO".
### Visualização dos Dados Processados
1. Clique no botão "Obter Preços"
2. Observe os valores calculados no datagrid da interface.
