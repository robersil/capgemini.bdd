Funcionalidade: Room
	Testes integrados das funcionalidade relacionadas ao end-point Room

#Esquema do Cenario: Gravar quarto
#	Dado que o endpoint é 'Room/Create'
#	E que o método http é 'POST'
#	E que o andar é 5
#	E que o numero do quarto é 25
#	E que o situacao é A
#	E que o id do tipo do quarto é 19
#	Quando gravar o room
#	Então a resposta será <resposta>
#	Exemplos:
#		| resposta |
#		| 201      |
#
#Esquema do Cenario: Alterar quarto
#	Dado que o endpoint é 'Room/Update'
#	E que o método http é 'PATCH'
#	E que o id é 1
#	E que o situacao é I
#	Quando alterar o quarto
#	Então a resposta será 200
#
#Esquema do Cenario: Obter room
#	Dado que o endpoint é 'Room/GetById'
#	E que o método http é 'GET'
#	E que o id é <id>
#	Quando obter o room
#	Então a resposta será <resposta>
#
#	Exemplos:
#		| id | resposta |
#		| 1  | 200      |
#		| 100 | 404     |
#
#Esquema do Cenario: Obter tipo do quarto
#	Dado que o endpoint é 'Room/GetByTypeRoomId'
#	E que o método http é 'GET'
#	E que o id é 19
#	Quando obter o tipo de quarto
#	Então a resposta será 200