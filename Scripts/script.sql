/****** Object:  Database [AngWebAPIBD]    Script Date: 05/07/2021 23:07:40 ******/
drop database [AngWebAPIBD]
create database [AngWebAPIBD]
use [AngWebAPIBD]
CREATE TABLE [dbo].[Pessoa](
	[PessoaId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[CPF] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Telefone] [nvarchar](max) NULL,
	[Sexo] [nvarchar](max) NULL,
	[DataNascimento] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[PessoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [AngWebAPIBD] SET  READ_WRITE 
GO





