-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <21-Jul-2015>
-- Description:	<Routine to Copy CustomerOBject Data Facts into DWH >
--  Read Only DWH Implementation.
--1- [UDW].[Dbo].[RevenueFacts]

-- =============================================


USE [UDW]
GO

-----------------------------  Fetch Fact Load history to Exculde Previously Loaded Rows. -----------------------------
Declare @Start as int

SELECT 
    @Start = DATEDIFF(SECOND,(SELECT MAX(RowLastAccessed) FROM [Accounts].[dbo].[StudentFeesDetails]), 
		(SELECT MAX(FactLastLoaded) FROM dbo.FactLoadHistory Where Fh.[FactObjectName] = 'Customer' and Fh.[Status] = 'Success' ))
	from [udw].[dbo].[FactLoadHistory] Fh
	select @Start = Isnull(@Start, '0')
	--Print @start
--------------------------------------------------------------------------------------------------------------------  

  INSERT INTO [UDW].[dbo].[RevenueFacts]  
  
           ([StudentKey]
           ,[ProgramKey]
           ,[DateKey]
           ,[HourOfTheDayKey]
           ,[GeoKey]
           ,[CustomersKey]
           ,[ProductsKey]
           ,[Unit Price]
           ,[Units Sold]
           ,[Discount Allowed]
           ,[Net Amount]
           ,[StudentFees]
           ,[LateFeesAmount]
		   )
   
    Select 
			49   --Load Default DWPrimarykey 'Unknown' value from DimStudents and DimProgram
	       ,73   -- Same Goes here as above.
		   ,ISNULL(D.DateKey ,-1)  
		   ,ISNULL(H.HourKey ,-1) 
		   ,ISNULL(G.GeoKey, -1)    
		   ,ISNULL(C.CustomerKey, -1)    
		   ,ISNULL(P.ProductKey , -1)    
		   ,ISNULL(O.Amount, 0)
		   ,ISNULL(O.Quantity, 0)
		   ,ISNULL(O.[Discount Allowed], 0)
		   ,ISNULL(((O.Amount * O.Quantity) - O.[Discount Allowed]), 0)        
		   ,0       -- [Accounts].[dbo].[StudentFeesDetails]
		   ,0       -- [Accounts].[dbo].[StudentFeesDetails]
		   
		   FROM [Accounts].[dbo].[CustomerOrders]  O  
		    Inner Join [UDW].[dbo].[DimCustomers] C
		   ON CAST(C.CustomerKeyAlternate as int)  = CAST(O.FkCustomerID as int) 
		   Inner Join [UDW].[dbo].[DimProducts]  P
		   ON CAST(P.ProductKeyAlternate as int)  = CAST(O.[FkSoftProductID]  as int)  
		   Inner join [UDW].[dbo].[DimDates] D     
		   ON CAST(D.[Full Date] as date )   = CAST(O.[Payment Date]  as date)         
		   inner join [UDW].[dbo].[DimHourOFTheDay] H
		   ON CAST(H.HourKey as int) = DateName(Hour,CAST(O.[Payment Date]as datetime) ) 
		   Inner join [UDW].[dbo].[DimGeography]  G
		   ON CAST(G.GeoIDAlternateKey as int)  = CAST(O.FkCustomerID  as int)  
		  
			  Where (O.[FkCustomerID]  )IS not Null
	           And  @Start < 1

			  --------------------------------  Update the FactHistory table  ----------------------------------
			IF @@ROWCOUNT = 0 GOTO ERROR_HANDLER

			INSERT INTO [UDW].[dbo].[FactLoadHistory]
				([FactLastLoaded]
				,[FactObjectName]
				,[Status])
		    VALUES
				(Getdate() -1 
				,'Customer'
				,'Success')
	   
--------------------- The End Customer Part   -----------------------------------------------------------------------
	
			  --Todo List:- Put Triggers in Customer Order Detail table and start coding.
			  --select * from [udw].[dbo].FactLoadHistory
		   --delete from [udw].[dbo].FactLoadHistory
		   --select * from [udw].[dbo].fc
		   --delete from [udw].[dbo].Fc where Customerskey = 69
			  
		   --select * from [UDW].[dbo].[REVENUEFACTS]
		  -- delete from udw.dbo.revenuefacts
		  --truncate table [UDW].[dbo].RevenueFacts
		--  select * from [UDW].[dbo].DimPrograms  
		--  DELETE FROM [UDW].[dbo].DimPrograms    
		-- select * from [udw].[dbo].[dimgeography]

----------------------------------------------- THE END: FACT POPULATED ---------------------------------------------