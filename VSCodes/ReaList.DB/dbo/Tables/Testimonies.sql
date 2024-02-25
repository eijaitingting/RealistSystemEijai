CREATE TABLE [dbo].[Testimonies] (
    [TestimonyID] INT            IDENTITY (1, 1) NOT NULL,
    [AgentID]     INT            NULL,
    [Testimony]   NVARCHAR (255) NULL,
    [isDisplayed] BIT            NULL,
    [DateCreated] DATETIME2 (7)  NULL,
    CONSTRAINT [PK__Testimon__7FE95210671C9662] PRIMARY KEY CLUSTERED ([TestimonyID] ASC)
);







