USE [Accounts]
GO
/****** Object:  StoredProcedure [dbo].[spLoadCustomer_Facts]    Script Date: 8/13/2015 12:12:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <24-Jul-2015>
-- Description:	<Routine to Copy CustomerOBject Data(Fact) into DWH. >
--1- RevenueFacts  

-- =============================================

ALTER Procedure [dbo].[spLoadCustomer_Facts]
AS
BEGIN

-----  Start of Fact Table Insert Procedure.

BEGIN TRAN F1  -- POPULATE FACT TABLE NOW.


  INSERT INTO [UDW].[dbo].[RevenueFacts]  
  
           ([StudentKey]
           ,[ProgramKey]
           ,[DateKey]
           ,[HourOfTheDayKey]
           ,[GeoKey]
           ,[CustomersKey]
           ,[ProductsKey]
           ,[OrderID] 
		   ,[FeesVoucherID] 
		   ,[Unit Price]
           ,[Units Sold]
           ,[Discount Allowed]
           ,[Net Amount]
           ,[StudentFees]
           ,[LateFeesAmount]
		   )
  
    Select 
			-1   --Load Default DWPrimarykey 'Unknown' value from DimStudents and DimProgram
	       ,-1   -- Same Goes here as above.
		   ,ISNULL(D.DateKey ,-1)  
		   ,ISNULL(H.HourKey ,-1) 
		   ,ISNULL(G.GeoKey, -1)    
		   ,ISNULL(C.CustomerKey, -1)    
		   ,ISNULL(P.ProductKey , -1)    
		   ,ISNULL(O.OrderID , -1)
		   ,-1     --No Fees Voucher For Customers.
		   ,ISNULL(O.Amount, 0)
		   ,ISNULL(O.Quantity, 0)
		   ,ISNULL(O.[Discount Allowed], 0)
		   ,ISNULL(((O.Amount * O.Quantity) - O.[Discount Allowed]), 0)        
		   ,0       -- [Accounts].[dbo].[StudentFeesDetails]
		   ,0       -- [Accounts].[dbo].[StudentFeesDetails]
		   
		   FROM [Accounts].[dbo].[CustomerOrders]  O  
		    LEFT Join [UDW].[dbo].[DimCustomers] C
		   ON  CAST(O.FkCustomerID as int) = CAST(C.CustomerKeyAlternate as int)
		   LEFT Join [UDW].[dbo].[DimProducts]  P
		   ON  CAST(O.[FkSoftProductID]  as int)  = CAST(P.ProductKeyAlternate as int) 
		   LEFT join [UDW].[dbo].[DimDates] D     
		   ON  CAST(O.[Payment Date]  as date) = CAST(D.[Full Date] as date )   
		   LEFT join [UDW].[dbo].[DimHourOFTheDay] H
		   ON DateName(Hour,CAST(O.[Payment Date]as datetime)) = CAST(H.HourKey as int) 
		   LEFT join [UDW].[dbo].[DimGeography]  G
		   ON  CAST(O.FkCustomerID  as int) = CAST(G.GeoIDAlternateKey as int) 
		   LEFT JOIN [UDW].[DBO].RevenueFacts RF
		    ON  CAST (O.OrderID as int) = CAST(RF.OrderID as int)
			 WHERE RF.OrderID  IS NULL
			 					    
----------------------------------------------- THE END: FACT POPULATED ---------------------------------------------

IF (@@ERROR <> 0) GOTO ERROR_HANDLER_F1 --IN CASE OF UN-EXPECTED ERROR WE CANCELS THE WHOLE TRANSACTION.

COMMIT TRAN F1

Print 'LoadCustomerFacts Executed Successfully'

RETURN 0



ERROR_HANDLER_F1:
IF (@@ERROR <> 0) BEGIN
	PRINT 'UN-EXPECTED PROBLEMS OCCURED DURING POPULATING REVENUEFACT TABLES. PROCESS ABORTED!'
	ROLLBACK TRAN F1
	RETURN 1
	END


END
 
