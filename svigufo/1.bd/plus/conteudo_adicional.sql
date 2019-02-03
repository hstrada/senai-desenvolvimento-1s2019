USE SENAI_SVIGUFO;

INSERT INTO TIPOS_EVENTOS VALUES ('TECNOLOGIA'), ('DESIGN'), ('MARKETING');

SELECT * FROM TIPOS_EVENTOS ORDER BY ID ASC;

-- VIEWS
-- VISUALIZACAO
-- https://docs.microsoft.com/pt-br/sql/t-sql/statements/create-view-transact-sql?view=sql-server-2017

CREATE VIEW [RETORNAR_TIPOS_EVENTOS] AS
SELECT ID, TITULO
FROM TIPOS_EVENTOS;

SELECT * FROM RETORNAR_TIPOS_EVENTOS;

-- FUNCTIONS 
-- VISUALIZACAO COM PARAMETROS
-- https://docs.microsoft.com/pt-br/sql/t-sql/statements/create-function-transact-sql?view=sql-server-2017

CREATE FUNCTION RETORNAR_TIPOS_EVENTOS_COM_PARAMETRO(@ID INT)
RETURNS table
AS
RETURN (SELECT ID, TITULO FROM TIPOS_EVENTOS WHERE ID=@ID);

SELECT * FROM RETORNAR_TIPOS_EVENTOS_COM_PARAMETRO(1);

-- PROCEDURE
-- PODE EXECUTAR INSERT E UPDATE
-- https://docs.microsoft.com/pt-br/sql/t-sql/statements/create-procedure-transact-sql?view=sql-server-2017

/* CREATE PROCEDURE NOMEPROCEDURE
@CampoBusca VARCHAR (20)
AS
SELECT COLUNAS
FROM TABELA
WHERE CONDICAO = @CampoBusca */

-- CRIANDO UM PROCEDIMENTO - PROCEDURE

CREATE PROCEDURE BUSCAR_TIPOS_EVENTOS
@IDBUSCADO INT
AS
SELECT ID, TITULO
FROM TIPOS_EVENTOS
WHERE ID = @IDBUSCADO;

EXECUTE BUSCAR_TIPOS_EVENTOS 2;

-- ÍNDICES

/*
    Com um índice não-clusterizado, o banco salvaria os dados de CEP de forma aleatória no disco 
	e armazenaria no índice apenas um ponteiro para o local onde o dado real está.
    Com um índice clusterizado, o banco salvaria os dados de CEP ordenados fisicamente e, 
	sempre que um novo dado for inserido ou atualizado, teremos de arcar com o custo de 
	reescrever os dados no índice para que os mesmos continuem ordenados.
*/

-- https://docs.microsoft.com/pt-br/sql/2014-toc/sql-server-index-design-guide?view=sql-server-2014
-- https://docs.microsoft.com/pt-br/sql/relational-databases/indexes/create-clustered-indexes?view=sql-server-2017