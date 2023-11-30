SELECT 

	Cliente.Nome AS Cliente,

	Cliente.CPF AS CPF,

	Modelo.Nome AS MODELO,

	Aluguel.Aluguel AS PROTOCOLO

FROM
	Veiculo
LEFT JOIN
	Aluguel ON Veiculo.IdVeiculo = Aluguel.IdVeiculo
LEFT JOIN
	Cliente ON Aluguel.IdCliente = Cliente.IdCliente
LEFT JOIN
	Modelo ON Veiculo.IdModelo = Modelo.IdModelo


