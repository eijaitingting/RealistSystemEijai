CREATE TABLE [dbo].[PropertyRatingsCategory] (
    [PRCategoryID]            INT            IDENTITY (1, 1) NOT NULL,
    [PRCategoryName]          NVARCHAR (255) NULL,
    [PropertyCategoryRatings] INT            NULL,
    PRIMARY KEY CLUSTERED ([PRCategoryID] ASC)
);

