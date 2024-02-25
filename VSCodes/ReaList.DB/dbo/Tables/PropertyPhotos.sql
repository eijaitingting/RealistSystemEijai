CREATE TABLE [dbo].[PropertyPhotos] (
    [PropertyPhotosID] INT            IDENTITY (1, 1) NOT NULL,
    [PropertyID]       INT            NULL,
    [MainPhoto]        NVARCHAR (MAX) NULL,
    [SecondPhoto]      NVARCHAR (MAX) NULL,
    [ThirdPhoto]       NVARCHAR (MAX) NULL,
    [FourthPhoto]      NVARCHAR (MAX) NULL,
    [FifthPhoto]       NVARCHAR (MAX) NULL,
    [SixthPhoto]       NVARCHAR (MAX) NULL,
    [SeventhPhoto]     NVARCHAR (MAX) NULL,
    [EightPhoto]       NVARCHAR (MAX) NULL,
    [NinthPhoto]       NVARCHAR (MAX) NULL,
    [TenthPhoto]       NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([PropertyPhotosID] ASC)
);



