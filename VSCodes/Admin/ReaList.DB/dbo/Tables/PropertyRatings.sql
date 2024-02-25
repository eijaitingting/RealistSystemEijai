CREATE TABLE [dbo].[PropertyRatings] (
    [PropertyRatingsID]      INT          NOT NULL,
    [PropertyID]             INT          NULL,
    [PRCategoryID]           INT          NULL,
    [TotalPropertyRatingAve] DECIMAL (18) NULL,
    PRIMARY KEY CLUSTERED ([PropertyRatingsID] ASC)
);

