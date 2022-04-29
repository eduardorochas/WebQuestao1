/****** Object:  Table [dbo].[DepartamentoResponsavel]    Script Date: 29/04/2022 08:02:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DepartamentoResponsavel](
	[CodigoDepartamento] [varchar](15) NOT NULL,
	[NomeResponsavel] [varchar](200) NULL,
	[LoginResponsavel] [varchar](30) NULL,
	[EmailResponsavel] [varchar](50) NULL,
 CONSTRAINT [PK_DepartamentoResponsavel] PRIMARY KEY CLUSTERED 
(
	[CodigoDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO