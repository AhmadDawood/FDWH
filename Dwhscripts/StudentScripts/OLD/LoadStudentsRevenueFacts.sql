USE [UDW]
GO
-----------------------------  Fetch Fact Load history to Exculde Previously Loaded Rows. -----------------------------
-----  Code Need to be modified for its validity ------------------------------
Declare @Start as int
Declare @FObject as nvarchar(50)
Declare @IsSuccess as nvarchar(50)

SELECT 
    @Start = DATEDIFF(SECOND,(SELECT MAX(RowLastAccessed) FROM [Accounts].[dbo].[StudentFeesDetails]), 
			  (SELECT MAX(FactLastLoaded) FROM dbo.FactLoadHistory )),
	@FObject = fh.[FactObjectName],
	@IsSuccess = fh.[status]
	from [udw].[dbo].[FactLoadHistory] fh
--	print @IsSuccess
--	Print @Fobject

-----------------------------------------------------------------------------------------------------------------------
INSERT INTO [UDW].[dbo].[fc] 
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
			ISNULL(S.StudentKey , -1) 
	       ,ISNULL(PG.ProgramKey, -1)
		   ,ISNULL(D.DateKey ,-1)  --Datekey       -DateAlternatekey is -1 for 'NA'
		   ,ISNULL(H.HourKey ,-1)  --HourKey Problem
		   ,ISNULL(G.GeoKey, -1)    --GeoKey
		   ,-1--ISNULL(C.CustomerKey, -1)            -- No Corresponding Value Avaialable from DimCustomers
		   ,-1--ISNULL(P.ProductKey , -1)               -- No Corresponding Value Available from DimProducts
		   ,0                --  No Corresponding field in from Accounts SoftwareRevenue Table
		   ,0                --  No Corresponding field in from Accounts SoftwareRevenue Table
		   ,0                --  No Corresponding field in from Accounts SoftwareRevenue Table
		   ,ISNULL(SD.Amount + SD.LateFees, 0)        -- --  Calculate the Field.
		   ,ISNULL(SD.Amount, 0)       -- [Accounts].[dbo].[StudentFeesDetails]
		   ,ISNULL(SD.LateFees, 0)    -- [Accounts].[dbo].[StudentFeesDetails]
		   
		   FROM [Accounts].[dbo].StudentFeesDetails SD   
		    Inner join [UDW].[dbo].[DimStudents] S 
		   ON CAST(S.StudentIDAlternateKey as int)  = CAST(SD.RollNumber as int) --DimStudents Join
		    Inner join [UDW].[dbo].[DimPrograms] PG
		   ON CAST(PG.StudentKeyAlternate as int) = CAST(SD.RollNumber as int)    --DimPrograms Join
		   Inner join [UDW].[dbo].[DimDates] D     
		   ON CAST(D.[Full Date] as date )   = CAST(SD.[Payment Date] as date)          --DimDates Join
		    inner join [UDW].[dbo].[DimHourOFTheDay] H
		   ON H.HourKey = DateName(Hour,SD.[Payment Date]) --DimHouroftheday
			Inner join [UDW].[dbo].[DimGeography]  G
		   ON CAST(G.GeoIDAlternateKey as int)  = CAST(SD.RollNumber as int)         --DimGeography (Problem: AltKeyForShared Objects, Students, Customers, Employees)
		 
		      --Left Join [UDW].[dbo].[DimCustomers] C
		      --ON C.CustomerKey = SD.RollNumber                      --DimCustomers (Problem :- NoAltkeyAvailable for StudentObject)
		      --Left Join [UDW].[dbo].[DimProducts]  P
		      --ON CAST(P.ProductKeyAlternate as int)  = CAST(SD.RollNumber as int)  --DimCustomers (Problem :- NoAltkeyAvailable for StudentObject)
		      
			  --lEFT Join [UDW].[dbo].[fc] R
		      --ON R.[RevenueKey] = R.[RevenueKey]
		      --Where R.[RevenueKey] Is Null
			  
			  Where (Sd.[RollNumber]  )IS not Null
	          --And (R.RevenueKey ) IS  Null
			  And @Start  < 1
			  And @FObject != 'Student'
			  And @IsSuccess != 'Success'

			  --------------------------------  Update the FactHistory table  ----------------------------------

INSERT INTO [dbo].[FactLoadHistory]
           ([FactLastLoaded]
           ,[FactObjectName]
           ,[Status])
     VALUES
           (Getdate()
           ,'Student'
           ,'Success')
		   --select * from [udw].[dbo].FactLoadHistory
		   --delete from [udw].[dbo].FactLoadHistory
		   --select * from [udw].[dbo].fc
		   --delete from [udw].[dbo].Fc
--------------------- The End Student Part   -----------------------------------------------------------------------
GO
