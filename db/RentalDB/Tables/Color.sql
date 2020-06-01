﻿CREATE TABLE [dbo].[Color] (
    [ColorId] SMALLINT      IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [Code]    CHAR (7)      NOT NULL,
    CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED ([ColorId] ASC),
    CONSTRAINT [UQ_Color_Code] UNIQUE NONCLUSTERED ([Code] ASC),
    CONSTRAINT [UQ_Color_ColorId] UNIQUE NONCLUSTERED ([ColorId] ASC),
    CONSTRAINT [UQ_Color_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

