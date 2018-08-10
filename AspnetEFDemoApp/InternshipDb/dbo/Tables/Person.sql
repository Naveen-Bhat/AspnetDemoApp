CREATE TABLE [dbo].[Person] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NULL,
    [AddressId] INT          NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Person_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id])
);

