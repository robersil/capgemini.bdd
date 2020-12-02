Funcionalidade: Client
	Testes integrados das funcionalidade relacionadas ao end-point Client

#Esquema do Cenario: Gravar client
#	Dado que o endpoint é 'Client/Create'
#	E que o método http é 'POST'
#	E que o nome é Roberta
#	E que o cpf é 39672927894
#	E que o hash é d1s5a6d1s5a61ds
#	Quando gravar o cliente
#	Então a resposta será 201
#
#
#Esquema do Cenario: Obter client
#	Dado que o endpoint é 'Client/GetById'
#	E que o método http é 'GET'
#	E que o id é <id>
#	Quando obter o cliente
#	Então a resposta será <resposta>
#
#	Exemplos:
#		| id | resposta |
#		| 1  | 200      |
#		| 100 | 404      |
#	
