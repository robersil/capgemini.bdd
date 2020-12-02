Funcionalidade: TypeRoom
	Testes integrados das funcionalidade relacionadas ao end-point TypeRoom

#Esquema do Cenario: Gravar tipo de quarto
#	Dado que o endpoint é 'TypeRoom/Create'
#	E que o método http é 'POST'
#	E que o descricao é Solt
#	E que o value é 125
#	Quando gravar o tipo de quarto
#	Então a resposta será 201
#
#Esquema do Cenario: Obter tipo de quarto
#	Dado que o endpoint é 'TypeRoom/GetById'
#	E que o método http é 'GET'
#	E que o id é <id>
#	Quando obter o tipo de quarto
#	Então a resposta será <resposta>
#
#	Exemplos:
#		| id | resposta |
#		| 19  | 200      |
#		| 100 | 404     |
#
#
#Esquema do Cenario: Listar tipos de quarto
#	Dado que o endpoint é 'TypeRoom/GetAll'
#	E que o método http é 'GET'
#	Quando obter o tipo de quarto
#	Então a resposta será 200