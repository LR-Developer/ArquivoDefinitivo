﻿ALTER PROCEDURE PR_INS_AD
(
	@NM_ALUNO VARCHAR(100),
	@NR_RA VARCHAR(20)
)
AS
BEGIN

IF (SELECT TOP 1 (NR_PRONTUARIO) FROM TB_AD ORDER BY NR_PRONTUARIO DESC) IS NULL
	BEGIN
		INSERT INTO TB_AD
			(
			NR_PRONTUARIO,
			NM_ALUNO,
			NR_RA,
			NR_CAIXA
			)
		VALUES
			(
			1,
			@NM_ALUNO,
			@NR_RA,
			1
			)
	END

	ELSE
	BEGIN
INSERT INTO TB_AD
	(
	NR_PRONTUARIO,
	NM_ALUNO,
	NR_RA,
	NR_CAIXA
	)
VALUES
	(
	CASE	WHEN (SELECT TOP 1 (NR_PRONTUARIO) FROM TB_AD ORDER BY CD_ID DESC) = 5
			THEN 1
			ELSE (SELECT TOP 1 (NR_PRONTUARIO) FROM TB_AD ORDER BY CD_ID DESC) + 1
	END,
	@NM_ALUNO,
	@NR_RA,
	CASE	WHEN (SELECT TOP 1 (NR_PRONTUARIO) FROM TB_AD ORDER BY CD_ID DESC) = 5
			THEN (SELECT MAX (NR_CAIXA) FROM TB_AD) + 1
			ELSE (SELECT MAX (NR_CAIXA) FROM TB_AD)
	END
	)
	
END
END

EXEC PR_INS_AD @NM_ALUNO = 'ABDO MAGEID KURDI', @NR_RA = '2 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABEL DA SILVA PAPA', @NR_RA = '3 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABEL OLIMPIO DA SILVA', @NR_RA = '4 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABEL TITO BRAGA DE OLIVEIRA', @NR_RA = '5 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABELAR ANTONIO LUIZ', @NR_RA = '6 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABIGAEL FELIPE DA SILVA', @NR_RA = '7 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABIGAIL SANT''''ANNA DE CARVALHO', @NR_RA = '8 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABIGAIL AVILAZ BARRETO ', @NR_RA = '9 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABNEL ALLERSDORFER', @NR_RA = '10 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABNER SALOMÃO MARINHO CAMPELO', @NR_RA = '11 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABNER TEIXEIRA RAMOS', @NR_RA = '12 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABRAÃO ANTONIO SILVA DOS SANTOS', @NR_RA = '13 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABRAÃO MAGALHÃES CARNEIRO', @NR_RA = '14 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ABRAHÃO FELICIANO DE MELO', @NR_RA = '15 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ACAUAN DA SILVA OLIVEIRA', @NR_RA = '16 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ACISIO ANTONIO DA SILVA ', @NR_RA = '17 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ACONÁRIA SONARIA DA SILVA PEREIRA ', @NR_RA = '18 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADA DOS SANTOS SILVA', @NR_RA = '19 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADA ELLEN ALVES DE SOUZA', @NR_RA = '20 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAILDO SILVA GUERRA', @NR_RA = '21 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAILTON CARVALHO BRITO', @NR_RA = '22 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAILTON DE SOUZA MORENO', @NR_RA = '23 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAILTON FELISBERTO DA CONCEIÇÃO', @NR_RA = '24 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAILTON MINERVINO DE ALMEIDA', @NR_RA = '25 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAILTON SOARES SILVA', @NR_RA = '26 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAIR NUNES RAMOS', @NR_RA = '27 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAIR SILVA ABREU', @NR_RA = '28 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALBERON SOARES GOMES', @NR_RA = '29 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALBERTO BEZERRA DE SALES', @NR_RA = '30 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALBERTO DAVI BONO', @NR_RA = '31 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALBERTO DE JESUS', @NR_RA = '32 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALBERTO FERREIRA DOS SANTOS ', @NR_RA = '33 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALBERTO SOUZA RIBEIRO ', @NR_RA = '34 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALBERTO SUCHOJ ROCHA ', @NR_RA = '35 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALBERTO YUNYKI MYAHARA', @NR_RA = '36 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALGISO DE ARAUJO', @NR_RA = '37 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALGIZA ALVES SOARES ', @NR_RA = '38 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALGIZA VIEIRA DE ALMEIDA ', @NR_RA = '39 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADALTON CARDOSO MUNIZ DE OLIVEIRA', @NR_RA = '40 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAMIS JOSE DA SILVA ', @NR_RA = '41 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAMO MOURA ', @NR_RA = '42 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADÃO CAETANO DA SILVA ', @NR_RA = '43 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADARLENE MENDES ', @NR_RA = '44 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAUBERTO SOARES GOMES ', @NR_RA = '45 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAURI FLOR DA SILVA ', @NR_RA = '46 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAUTO CESAR RUFINO MEDEIROS', @NR_RA = '47 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAUTO DO NASCIMENTO MELLO', @NR_RA = '48 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAUTO DOS SANTOS CASTELARI ', @NR_RA = '49 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAUTO INEZ', @NR_RA = '50 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADAUTO RODRIGUES DA CUNHA', @NR_RA = '51 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADILÉIA SOARES SIMÕES ', @NR_RA = '52 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADLA SANTOS NASCIMENTO ', @NR_RA = '53 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADNA MENEZES DO LAVRADOR', @NR_RA = '54 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADINALDO DOS SANTOS OLIVEIRA ', @NR_RA = '55 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADILIO WILHAN DA SILVA', @NR_RA = '56 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADEILDA FREITAS RAMOS', @NR_RA = '57 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADELAIDE BENEDITA CARVALHO', @NR_RA = '58 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADELSON AMARO DA SILVA', @NR_RA = '59 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADEMILDA DA SILVA ALMEIDA', @NR_RA = '60 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADEMILSON AQUINO  DE OLIVEIRA', @NR_RA = '61 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADEMILSON ARAGÃO FERNANDES ', @NR_RA = '62 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADEMILSON CÂNDIDO', @NR_RA = '63 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADEMILSON DOS REIS', @NR_RA = '64 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADEMILSON LUIZ  DOS SANTOS', @NR_RA = '65 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADEMILSON MIGUEL ARCANJO', @NR_RA = '66 ' ;
EXEC PR_INS_AD @NM_ALUNO = 'ADEMILSON PIASSA DE LIMA', @NR_RA = '67 ' ;





SELECT * FROM TB_AD
SELECT TOP 1 (NR_PRONTUARIO) FROM TB_ARQUIVO_DEFINITIVO ORDER BY CD_ID DESC

TRUNCATE TABLE TB_AD
