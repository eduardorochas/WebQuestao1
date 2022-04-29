-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.SP_MANTEM_DEPARTAMENTO_RESP
	-- Add the parameters for the stored procedure here
	@CodigoDepartamento varchar(15),
	@NomeResponsavel varchar(200),
	@LoginResponsavel varchar(30),
	@EmailResponsavel varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	   

	IF NOT EXISTS (SELECT CodigoDepartamento FROM dbo.DEPARTAMENTORESPONSAVEL WHERE CodigoDepartamento = @CodigoDepartamento)
	BEGIN
		INSERT INTO DEPARTAMENTORESPONSAVEL VALUES (@CodigoDepartamento,@NomeResponsavel,@LoginResponsavel ,@EmailResponsavel);
	END
	ELSE
	BEGIN
		UPDATE DEPARTAMENTORESPONSAVEL SET
		NomeResponsavel = @NomeResponsavel, 		
		LoginResponsavel = @LoginResponsavel ,
		EmailResponsavel = @EmailResponsavel
		WHERE @CodigoDepartamento = @CodigoDepartamento;

	END

END
GO
