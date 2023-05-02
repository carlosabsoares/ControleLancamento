A API ControleLancamento foi contruida da seguinte forma:

	* net 6;
	* Sqlite;
	* EntityFramework;
	* CRQS ;
	* Xunit;
	
Para a execução do serviço, basta executa-lo, pois irá aplicar a criação do banco de dados autimaticamente
	Temos 2 controller:
	
	LancamentoController ( onde será efetuado as operações de lançamento ), com os métodos:
		* /v1/Lancamento/getAll - Obtem todos os lançamentos efetuados;
		* /v1/Lancamento - Cadastra um lançamento. O Json deve ser esse:
			{
			  "valor": 0, 
			  "tipoOperacao": 1
			} 
			onde o valor é o valor monetário e o tipoOperacao é o tipo de operação realizada ( 1 - Débito e 2 - Crédito )
		* ​/v1​/Lancamento​/{id} - Deleta um lançamento. Ao deletar o lançamento, o registro anterior será ajustado;
		
	ConsolidadoController ( onde será retornado as informações consolidadas por dia ), com os métodos:
		* /v1/Consolidado/getAll - Retorna todos os consolidado por data
		* /v1/Consolidado/getByData - Retorna o consolidado por uma data em expecífico.
	