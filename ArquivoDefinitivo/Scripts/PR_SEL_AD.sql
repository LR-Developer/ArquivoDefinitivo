﻿ALTER PROCEDURE PR_SEL_AD
(
	@NM_ALUNO VARCHAR (100)
)
AS
BEGIN

SELECT
	NR_PRONTUARIO AS Prontuário,
	NM_ALUNO AS Aluno,
	NR_RA AS RA,
	NR_CAIXA AS Caixa
FROM
	TB_AD
WHERE
	NM_ALUNO LIKE '%' + @NM_ALUNO + '%'
	COLLATE LATIN1_GENERAL_CI_AI
END

EXEC PR_SEL_AD
@NM_ALUNO = 'luis'