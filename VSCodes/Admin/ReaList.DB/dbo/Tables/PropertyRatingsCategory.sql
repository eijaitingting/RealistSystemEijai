CREATE TABLE [dbo].[PropertyRatingsCategory] (
    [PRCategoryID]            INT            NOT NULL,
    [PRCategoryName]          NVARCHAR (255) NULL,
    [PropertyCategoryRatings] INT            NULL,
    PRIMARY KEY CLUSTERED ([PRCategoryID] ASC)
);

