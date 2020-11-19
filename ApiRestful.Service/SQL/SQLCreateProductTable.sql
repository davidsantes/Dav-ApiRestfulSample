USE [XXXX]
GO

--Create the table
/****** Object:  Table [dbo].[Products]    Script Date: 19/11/2020 20:04:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[ProductId] [nvarchar](10) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[ProductDescription] [nvarchar](600) NULL
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--Insert some data
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription]) VALUES (N'Bike69148', N'Bike name 69148', N'This is the best Bike 69148')
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription]) VALUES (N'Food23148', N'Food name 23148', N'This is the best Food 23148')
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription]) VALUES (N'Food36763', N'Food name 36763', N'This is the best Food 36763')
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription]) VALUES (N'Game64527', N'Game name 64527', N'This is the best Game 64527')
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription]) VALUES (N'JDM-123456', N'Jabón de mano', N'Esta es una prueba')
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription]) VALUES (N'ref1', N'Lejía', N'Lejía muy fuerte')
GO