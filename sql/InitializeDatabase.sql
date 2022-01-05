USE master
GO
DROP DATABASE IF EXISTS PersonDB
GO

CREATE DATABASE PersonDB
GO 
USE PersonDB
GO 
----------------------------------------------------------------------------
--- TABLE CREATION
----------------------------------------------------------------------------
CREATE TABLE [dbo].[New-Person](
	[Id] [varchar](50) NOT NULL,
	[FirstName] [varchar](150) NULL,
	[LastName] [varchar](150) NULL,
	[Address] [varchar](250) NULL,
	[DateOfBirth] [datetime] NULL,
	[Email] [varchar](150) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_New-Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[New-Person] ADD  CONSTRAINT [DF_New-Person_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[New-Person] ADD  CONSTRAINT [DF_New-Person_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO


CREATE TABLE [dbo].[Person_SocialMedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [varchar](50) NULL,
	[SocialMediaType] [varchar](150) NULL,
	[Link] [varchar](250) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Inventory](
	[ProductId] [INT] NOT NULL,
	[QuantityOnHand] [INT] NOT NULL
) ON [PRIMARY]
GO

----------------------------------------------------------------------------
--- SEED Data
----------------------------------------------------------------------------

INSERT INTO [dbo].[New-Person]([Id],[FirstName],[LastName],[Address],[DateOfBirth],[Email],[PhoneNumber],[CreatedDate],[ModifiedDate])VALUES
           ('AF37B23C-6497-4AF1-BBED-FEA8E2B044FE','First Name','LastName','Address','2020-05-15','Email@email.com','PhoneNumber','2020-05-15','2020-05-15')
GO

----------------------------------------------------------------------------
--- DB USER CREATION
----------------------------------------------------------------------------
USE master;
GO
CREATE LOGIN [cr_dbuser] WITH PASSWORD=N'Sql1nContainersR0cks!', CHECK_EXPIRATION=OFF, CHECK_POLICY=ON;
GO
USE PersonDB;
GO
CREATE USER [cr_dbuser] FOR LOGIN [cr_dbuser];
GO
EXEC sp_addrolemember N'db_owner', [cr_dbuser];
GO
