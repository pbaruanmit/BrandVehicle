CREATE TABLE [dbo].[Brand] (
    [brand_name]       NVARCHAR (25) NOT NULL,
    [brand_description] NVARCHAR (20) NULL,
    CONSTRAINT [PK_ARTIST] PRIMARY KEY CLUSTERED ([brand_name] ASC)
);

drop TABLE [dbo].[Brand]