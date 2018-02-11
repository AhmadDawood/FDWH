USE [UDW]
GO


INSERT INTO [dbo].[RevenueFacts] 
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
		   ,ISNULL(C.CustomerKey, -1)            -- No Corresponding Value Avaialable from DimCustomers
		   ,ISNULL(P.ProductKey , -1)               -- No Corresponding Value Available from DimProducts
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
		 
		      Left Join [UDW].[dbo].[DimCustomers] C
		      ON C.CustomerKey = SD.RollNumber                      --DimCustomers (Problem :- NoAltkeyAvailable for StudentObject)
		      Left Join [UDW].[dbo].[DimProducts]  P
		      ON CAST(P.ProductKeyAlternate as int)  = CAST(SD.RollNumber as int)  --DimCustomers (Problem :- NoAltkeyAvailable for StudentObject)
		      Left Join [UDW].[dbo].[RevenueFacts] R
		      ON R.RevenueKey = R.RevenueKey 
		      --ON R.RevenueKey != SD.RollNumber 
		      Where (SD.RollNumber )IS Not Null
		      And (R.RevenueKey ) IS Null
		   -----------------------------------------------------------------------
  INSERT INTO [dbo].[RevenueFacts] 
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
			S.StudentIDAlternateKey 
	       ,P.ProductKeyAlternate 
		   ,ISNULL(D.DateKey ,-1)  --Datekey       -DateAlternatekey is -1 for 'NA'
		   ,ISNULL(H.HourKey ,-1)  --HourKey Problem
		   ,ISNULL(G.GeoKey, -1)    --GeoKey
		   ,ISNULL(C.CustomerKey, -1)            -- No Corresponding Value Avaialable from DimCustomers
		   ,ISNULL(P.ProductKey , -1)               -- No Corresponding Value Available from DimProducts
		   ,O.Amount                 --  No Corresponding field in from Accounts SoftwareRevenue Table
		   ,O.Quantity                 --  No Corresponding field in from Accounts SoftwareRevenue Table
		   ,O.[Discount Allowed]                 --  No Corresponding field in from Accounts SoftwareRevenue Table
		   ,ISNULL(((O.Amount * O.Quantity) - O.[Discount Allowed]), 0)        -- --  Calculate the Field.
		   ,0       -- [Accounts].[dbo].[StudentFeesDetails]
		   ,0    -- [Accounts].[dbo].[StudentFeesDetails]
		   
		   FROM [Accounts].[dbo].[CustomerOrders]  O   
		   Inner Join [UDW].[dbo].[DimCustomers] C
		   ON CAST(C.CustomerKeyAlternate as int)  = CAST(O.FkCustomerID as int)                   --DimCustomers (Problem :- NoAltkeyAvailable for StudentObject)
		   Inner Join [UDW].[dbo].[DimProducts]  P
		   ON CAST(P.ProductKeyAlternate as int)  = CAST(O.[FkSoftProductID]  as int)  --DimCustomers (Problem :- NoAltkeyAvailable for StudentObject)
		   Inner join [UDW].[dbo].[DimDates] D     
		   ON CAST(D.[Full Date] as date )   = CAST(O.[Payment Date]  as date)          --DimDates Join
		   inner join [UDW].[dbo].[DimHourOFTheDay] H
		   ON H.HourKey = DateName(Hour,O.[Payment Date]) --DimHouroftheday
			Inner join [UDW].[dbo].[DimGeography]  G
		   ON CAST(G.GeoIDAlternateKey as int)  = CAST(O.FkCustomerID  as int)         --DimGeography (Problem: AltKeyForShared Objects, Students, Customers, Employees)
		 
		      Left join [UDW].[dbo].[DimStudents] S 
		      ON CAST(S.StudentIDAlternateKey as int)  = CAST(O.FkCustomerID as int) --DimStudents Join
		      Left join [UDW].[dbo].[DimPrograms] PG
		      ON CAST(PG.StudentKeyAlternate as int)   = CAST(O.FkCustomerID  as int)    --DimPrograms Join
		      Left Join [UDW].[dbo].[RevenueFacts] R
		      ON R.RevenueKey = R.RevenueKey 
		      --ON R.RevenueKey != SD.RollNumber 
		      Where (O.[FkCustomerID]  )IS not Null
	          And (R.RevenueKey ) IS  Null

		      --------------------------------------------------
			  --Todo List:- Put Triggers in Customer Order Detail table and start coding.

		   --select * from [UDW].[dbo].RevenueFacts  
		  -- delete from [UDW].[dbo].RevenueFacts  
		  --truncate table [UDW].[dbo].RevenueFacts
		--  select * from [UDW].[dbo].DimPrograms   

GO
