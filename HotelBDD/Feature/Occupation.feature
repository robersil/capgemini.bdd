Funcionalidade: Occupation
	Testes integrados das funcionalidade relacionadas ao end-point Occupation

Esquema do Cenario: Gravar occupation
	Dado que o endpoint é 'Occupation/Create'
	E que o método http é 'POST'
	E que o quantidade diaria é 3
	E que o data é 02-12-2020
	E que o id do cliente é 1
	E que o id do id do quarto é 1
	Quando gravar o operacao
	Então a resposta será 201