USE [UDW]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <Sept 13 2015>
-- Description:	<A Routine to Fetch Revenue Facts by Individual Customer for R10>
-- =============================================
CREATE PROCEDURE [dbo].[spIndividualCustomersPayments_R10]
	@CustomerIDAltKey as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	Select
	 RevenueKey
    ,[Customer_Name] = (C.[First Name] + ' ' + C.[Last Name])
	,[Product_Name] = (P.[Software Product Item])
	,[City] = (G.City)
	,[Payment_Date] = CAST((D.[Full Date]) as date)
	,[Hour_of_the_Day] = (H.Hour)
	,[OrderID] = RF.OrderID
	,[Unit_Sold] = RF.[Units Sold]
	,[Unit_Price] = RF.[Unit Price]
	,[Discount] = RF.[Discount Allowed]
	,[Net_Amount] = RF.[Net Amount]
 FROM REVENUEFACTS AS RF
           INNER JOIN [UDW].[dbo].[DimCustomers] C 
		   ON  CAST(C.CustomerKey as int) = CAST(RF.CustomersKey as int) 
		   INNER JOIN [UDW].[dbo].[DimProducts] P 
		   ON  CAST(P.ProductKey as int) = CAST(RF.ProductsKey as int) 
		   INNER JOIN [UDW].[dbo].[DimGeography] G 
		   ON  CAST(G.GeoKey as int) = CAST(RF.GeoKey as int) 
		   INNER JOIN [UDW].[dbo].[DimDates] D 
		   ON  CAST(D.DateKey as int) = CAST(RF.DateKey as int) 
		   INNER JOIN [UDW].[dbo].[DimHourOFTheDay] H 
		   ON  CAST(H.HourKey as int) = CAST(RF.HourOfTheDayKey as int) 
where C.CustomerKeyAlternate = @CustomerIDAltKey
AND RF.CustomersKey != -1   --Check if Customer Exists or Not

END

