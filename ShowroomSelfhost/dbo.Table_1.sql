CREATE TABLE [dbo].[Vehicle]
(
	[vehicle_id] INT NOT NULL PRIMARY KEY, 
    [vehicle_model] VARCHAR(50) NULL, 
    [vehicle_registration_no] VARCHAR(50) NULL, 
    [vehicle_price] INT NULL, 
    [available] NVARCHAR(50) NULL, 
    [last_modified_date] DATETIME2 NULL, 
    [origin] VARCHAR(50) NULL, 
    [warrenty] VARCHAR(50) NULL, 
    [condition] VARCHAR(50) NULL, 
    [mileage] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([vehicle_id]),
    
)
