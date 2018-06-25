CREATE TABLE [dbo].[category] (
    [brand_name]       NVARCHAR (25) NOT NULL,
    [brand_description] NVARCHAR (20) NULL,
    [Phone]      NVARCHAR (20) NULL,
    CONSTRAINT [PK_BRAND] PRIMARY KEY CLUSTERED ([brand_name] ASC)
);