CREATE TABLE [dbo].[Address] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Address] VARCHAR (500) NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC)
);

