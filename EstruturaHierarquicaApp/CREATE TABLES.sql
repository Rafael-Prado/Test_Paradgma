
CREATE TABLE DEPARTAMENTO (
    ID int,
    NOME varchar(255),
    PRIMARY KEY (ID),
    
);

CREATE TABLE FUNCIONARIO (
    ID int,
    NOME varchar(255),
    SALARIO DECIMAL(18,2),
    DEPTID int
    PRIMARY KEY (ID),
    CONSTRAINT FK_Departamento FOREIGN KEY (DEPTID)
        REFERENCES Departamento (ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
    
);