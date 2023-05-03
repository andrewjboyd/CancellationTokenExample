USE [CancellationTokenDemo]
GO

/****** Object:  StoredProcedure [dbo].[GetWeatherDetails]    Script Date: 4/05/2023 9:04:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetWeatherDetails]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Table TABLE ([Id] INT, [DATE] Date NOT NULL, TemperatureC INT NOT NULL, Summary NVARCHAR(50) NOT NULL)

	INSERT INTO @Table
	VALUES (
		1, '2023-04-21', 30, 'Hot'
	)

	WAITFOR DELAY '00:00:05'

    -- Insert statements for procedure here
	SELECT * FROM @Table
END
GO

