USE [DB_Estoque]
GO

/****** Object:  Table [dbo].[Produtos]    Script Date: 10/08/2020 07:56:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produtos](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Nome] [varchar](100) NULL,
[Quantidade] [int] NULL,
[ValorUnitario] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO