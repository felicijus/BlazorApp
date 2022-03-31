USE [BlazorApp]
GO

/****** Objekt: Table [dbo].[WeatherForecasts] Skriptdatum: 26.03.2022 21:21:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[WeatherForecasts];


GO
CREATE TABLE [dbo].[WeatherForecasts] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Date]         DATETIME2 (7)  NOT NULL,
    [TemperatureC] INT            NOT NULL,
    [Summary]      NVARCHAR (MAX) NULL,
    [IsEditing]    BIT            NOT NULL
);

