USE [kawaifilms3]
GO
/****** Object:  StoredProcedure [dbo].[cadastroMovimento]    Script Date: 06/26/2014 17:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[cadastroMovimento]
    @codigoMovimento nvarchar(50),
    @dataEmissao date,
    @Documento nvarchar(50), 
    @Observacao nvarchar(100),
    @dataVencimento date,
    @ValorOriginal decimal(18, 2),
    @dataPagamento date,
    @ValorFinal decimal(18, 2),
    @Conta nvarchar(50),
    @Pagamento nvarchar(50)   
    
AS 

BEGIN 
     SET NOCOUNT ON 

  INSERT INTO dbo.Movimento
          ( 
			codigoMovimento				,
			dataEmissao					,
			Documento                   ,
			Observacao					,
			dataVencimento				,
			ValorOriginal				,
			dataPagamento				,
			ValorFinal					,			
			codigoConta					,			
			codigoPagamento				
          ) 
     VALUES 
          ( 
			1						,
			@dataEmissao			,
			@Documento				,
			@Observacao				,
			@dataVencimento			,
			@ValorOriginal			,
            @dataPagamento          ,
            @ValorFinal				,
            (Select )
                                        
          ) 

END 
