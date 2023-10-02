/*
SELECT Nome,CNH from PESSOAS ORDER BY Nome DESC;

SELECT 
	PESSOAS.Nome,
	PESSOAS.CNH,
	Email.Endereco,
	Telefone.Numero 
FROM 
	PESSOAS,
	Email,
	Telefone 
WHERE
	PESSOAS.IdPessoa = Email.IdPessoa
	AND PESSOAS.IdPessoa = Telefone.IdPessoa
ORDER BY Nome DESC;
*/


SELECT * FROM PESSOAS LEFT JOIN Email ON PESSOAS.IdPessoa = Email.IdPessoa 
LEFT JOIN Telefone ON PESSOAS.IdPessoa = Telefone.IdPessoa;