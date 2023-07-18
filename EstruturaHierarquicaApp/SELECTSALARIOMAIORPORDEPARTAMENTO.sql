

--Select que busca os salarios maiores por departamento

SELECT D.NOME As Departamento, F.Nome as Pessoa, F.SALARIO as Salario
FROM DEPARTAMENTO D
JOIN (
    SELECT DEPTID, MAX(SALARIO) AS MaiorSalario
    FROM FUNCIONARIO
    GROUP BY DEPTID
) T ON D.ID = T.DEPTID
JOIN FUNCIONARIO F ON T.DEPTID = F.DEPTID  AND T.MaiorSalario = F.SALARIO 
order BY F.SALARIO DESC 
