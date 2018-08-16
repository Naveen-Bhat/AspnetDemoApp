CREATE TABLE [dbo].[AbpUserTokens] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [LoginProvider] NVARCHAR (MAX) NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [TenantId]      INT            NULL,
    [UserId]        BIGINT         NOT NULL,
    [Value]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AbpUserTokens] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AbpUserTokens_AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AbpUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AbpUserTokens_UserId]
    ON [dbo].[AbpUserTokens]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AbpUserTokens_TenantId_UserId]
    ON [dbo].[AbpUserTokens]([TenantId] ASC, [UserId] ASC);

