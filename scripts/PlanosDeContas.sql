SELECT MovimentoGrupo.Grupo, MovimentoGrupoConta.Conta  
	FROM MovimentoGrupoConta INNER JOIN MovimentoGrupo  
	ON MovimentoGrupoConta.codigoGrupo = MovimentoGrupo.codigo order by MovimentoGrupo.Grupo,MovimentoGrupoConta.Conta;
