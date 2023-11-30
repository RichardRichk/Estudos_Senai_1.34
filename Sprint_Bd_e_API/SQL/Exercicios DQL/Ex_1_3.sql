USE Ex_1_3

SELECT 
	
	Atendimentos.Descricao AS Atendimento,

	Veterinario.Nome AS Veterinario,
	Veterinario.CRMV AS CRMV,

	Pet.Nome AS Nome,

	TipoPet.Descricao AS Tipo,

	Raca.Descricao AS Raca,

	Dono.Nome AS Dono,

	Clinica.Endereco AS "Local"


FROM
	Atendimentos
LEFT JOIN
	Veterinario ON Atendimentos.IdVeterinario = Veterinario.IdVeterinario
LEFT JOIN 
	Pet ON Atendimentos.IdPet = Pet.IdPet
LEFT JOIN 
	TipoPet ON Pet.IdTipoPet = TipoPet.IdTipoPet
LEFT JOIN
	Raca ON Pet.IdRaca = Raca.IdRaca
LEFT JOIN 
	Dono ON Pet.IdDono = Dono.IdDono
LEFT JOIN
	Clinica ON Veterinario.IdClinica = Clinica.IdClinica;

--------------------------------------------------------------------------------------------------------------

SELECT 
	
	Raca.Descricao

FROM 
	Raca
WHERE
	Raca.Descricao LIKE 'S%'

-------------------------------------------------------------------------------------

SELECT 
	
	Raca.Descricao

FROM 
	Raca
WHERE
	Raca.Descricao LIKE '%o'


