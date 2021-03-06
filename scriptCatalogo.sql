USE [Catalogo]
GO
/****** Object:  User [catalogo_user]    Script Date: 29/7/2021 11:09:35 ******/
CREATE USER [catalogo_user] FOR LOGIN [catalogo_user] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [catalogo_user]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 29/7/2021 11:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user] [nvarchar](500) NULL,
	[password] [nvarchar](500) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imagen]    Script Date: 29/7/2021 11:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imagen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ruta] [nvarchar](4000) NULL,
	[idProductos] [int] NULL,
 CONSTRAINT [PK_Imagen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 29/7/2021 11:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](500) NULL,
	[descripcion] [nvarchar](4000) NULL,
	[precio] [decimal](18, 5) NULL,
	[imagenCaratula] [nvarchar](4000) NULL,
	[fecha] [datetime] NULL,
 CONSTRAINT [PK_Lacteos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [user], [password]) VALUES (2, N'granjaporcon', N'BdENOBRj3/MD4TPTe6QrmHjJcBQQm9EvwdD2PUDk8hm8t/CuRaEFERnL03UfDPMmXkWB4FGY+FH+JFMkEGuZOA==')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
