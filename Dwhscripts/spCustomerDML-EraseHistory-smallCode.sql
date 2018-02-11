-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <20-Jul-2015>
-- Description:	<Routine to Copy CustomerOBject Data(Dimensions, Fact) into DWH>.
--1- DimCustomers
--2- DimProducts
--3- DimGeography
-- =============================================

--Script for inserting new record into Customer Dimension in DWH.

/*
BEGIN TRAN

IF (@@ERROR <> 0) 
BEGIN
-- Put All code here for execution
Print 'Some Error has been Occured during the Processing of CustomerDML Execution'
ROLLBACK TRAN
End
*/
--delete from [UDW].[dbo].DimStudents 
--DRop Constraints 
--Truncate table [UDW].[dbo].[DimStudents]

USE Accounts
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter Procedure spCustomerDML
AS
BEGIN
-- Code for copying New and Changed Data Rows into DWH.

INSERT INTO [UDW].[dbo].[DimCustomers]
           ([CustomerKeyAlternate]
           ,[First Name]
           ,[Last Name]
           ,[Date of Birth]
           ,[Marital Status]
           ,[Education]
           ,[Gender]
           ,[Age]
           ,[Occupation]
           ,[Designation]
           ,[Organization]
           ,[Email Address]
           ,[Phone Number]
		   )
     -- SELECT DATA FROM Accounts DB TBLS.
select 
       ISNULL(C.CustomerID, -1)
	  ,UPPER(ISNULL(C.[First Name], 'UnKnown'))
	  ,UPPER(ISNULL(C.[Last Name], 'UnKnown'))
	  ,ISNULL (C.[Date of Birth], '1900-01-01')
	  ,ISNULL(C.[Marital Status], 'UnKnown')
	  ,CAST(ISNULL(C.[Education], 'UnKnown') as nvarchar(50)) 
	  ,CAST(ISNULL(C.[Gender], 'UnKnown')as nvarchar(7)) 
	  ,ISNULL(C.[Age], 0)
	  ,ISNULL (C.[Occupation], 'UnKnown')
	  ,ISNULL (C.[Designation], 'UnKnown')
	  ,UPPER(ISNULL (C.[Organization],'UnKnown'))
	  ,ISNULL(C.[Email Address],  'UnKnown')
	  ,ISNULL (C.[Phone Number], 'UnKnown')
	  
		--from [Accounts].[dbo].[CustomerOrders] O
		--Left Join [Accounts].[dbo].[Customers] C ON
		from [Accounts].[dbo].[Customers] C 
		--CAST(O.[FkCustomerId] as int) = CAST(C.[CustomerID] as int)
		Left Join [UDW].[dbo].[DimCustomers] DWC ON
		CAST(C.[CustomerID] as int) = CAST(DWC.[CustomerKeyAlternate] as int)
		Where DWC.[CustomerKey] Is Null

--------------------------------------------------------------------------------
-- Code For Synchronising Changes into DimCustomers.

   Update DWC
		
		Set 
		
		  DWC.[CustomerKeyAlternate] = ISNULL(OC.[CustomerID], -1)
		 ,DWC.[First Name] = UPPER(ISNULL(OC.[First Name], 'Unknown'))
		 ,DWC.[Last Name] = UPPER(ISNULL(OC.[Last Name] , 'UnKnown'))
		 ,DWC.[Date of Birth] = ISNULL(OC.[Date of Birth], '1900-01-01')
		 ,DWC.[Marital Status] = ISNULL(OC.[Marital Status], 'Unknown')
		 ,DWC.[Education] =  ISNULL(OC.[Education], 'Unknown')
		 ,DWC.[Gender] = ISNULL(OC.[Gender] , 'Unknown')   
		 ,DWC.[Age]  = ISNULL(OC.[Age], 0)
		 ,DWC.[Occupation] = ISNULL(OC.[Occupation] , 'Unknown')
		 ,DWC.[Designation] = ISNULL(OC.[Designation] , 'Unknown')
		 ,DWC.[Organization] = ISNULL(OC.[Organization], 'Unknown')
		 ,DWC.[Email Address] = ISNULL(OC.[Email Address], 'Unknown')
		 ,DWC.[Phone Number] = ISNULL(OC.[Phone Number] , 'Unknown')

	    from [udw].[dbo].DimCustomers DWC
		Inner Join [Accounts].[dbo].[Customers] OC
		ON CAST(DWC.CustomerKeyAlternate as int ) = CAST(OC.CustomerID as int )

		--Select * from [udw].[dbo].DimCustomers 
		--select * from [Accounts].[dbo].Customers  
					
			where
			( 
			 (DWC.[CustomerKeyAlternate]   != CAST(OC.CustomerID as int ))
		     or (DWC.[First Name] != CAST(OC.[First Name]as nvarchar))
             or (DWC.[Last Name] !=  CAST (OC.[Last Name] as nvarchar))
			 or (DWC.[Date of Birth] != CAST(OC.[Date of Birth] as date ))
			 or (DWC.[Marital Status] != CAST(OC.[Marital Status] as nvarchar))
			 or (DWC.Education  != CAST(OC.[Education] as nvarchar ))
			 or (DWC.[Gender] !=  CAST(OC.[Gender] as nvarchar ))
			 or (DWC.[Age] != CAST(OC.[Age] as int ))
			 or (DWC.[Occupation] != CAST(OC.[Occupation] as nvarchar ))
			 or (DWC.[Designation] != CAST(OC.[Designation]as nvarchar  ))
			 or (DWC.[Organization] != CAST(OC.[Organization]as nvarchar)) 
			 or (DWC.[Email Address] !=  CAST(OC.[Email Address] as nvarchar ))
		     or (DWC.[Phone Number] != CAST(OC.[Phone Number] as nvarchar ))
			)
			--select * from [Accounts].[dbo].Customers 
			--select * from [udw].[dbo].DimCustomers  
-------------------------------------------------------------------------------
--Extraction of New or Changed Rows into DimProducts 
-------------------------------------------------------------------------------
INSERT INTO [UDW].[dbo].[DimProducts]
           ([ProductKeyAlternate]
           ,[Software Product Item]
           ,[License Type]
           ,[Product Description]
           ,[Category]
           ,[Product Features]
           ,[PlatForm]
           ,[Media]
           ,[Version]
           ,[Weight]
           )
SELECT 
		[ProductKeyAlternate] = ISNULL(I.[ProductID] , 0)
	   ,[Software Product Item] = ISNULL(CAST(I.[Software Product Item] as nvarchar(50)),'Unknown')
       ,[License Type] =  ISNULL(CAST(I.[License Type] as nvarchar(10)),'Unknown')
       ,[Product Description] = ISNULL(CAST(I.[Product Description] as nvarchar(255)),'Unknown')
       ,[Product Features] =  ISNULL(CAST(I.[Product Features] as nvarchar(255)),'Unknown')
       ,[Category] = ISNULL(CAST(I.[Category] as nvarchar(50)),'Unknown')
       ,[PlatForm] = ISNULL(CAST(I.[Platform] as nvarchar(50)), 'Unknown')
       ,[Media] = ISNULL(CAST(I.[Media] as nvarchar(50)), 'Unknown')
       ,[Version] = ISNULL(CAST(I.[Version] as nvarchar(10)), 'Unknown')
       ,[Weight] = ISNULL(CAST(I.[Weight] as nvarchar(10)), 'Unknown')
  
  FROM [Accounts].[dbo].[SoftwareItems] I
  Left Join [UDW].[dbo].[DimProducts]  P ON
  CAST(P.ProductKeyAlternate as int)  = CAST(I.ProductID as int)
  Where P.ProductKey IS NULL

-------------------------------------------------------------------------------
	Update P
		 set 	     
		     [ProductKeyAlternate] = ISNULL(I.[ProductID] , 0)
		    ,[Software Product Item] = ISNULL(CAST(I.[Software Product Item] as nvarchar(50)),'Unknown')
	        ,[License Type] =  ISNULL(CAST(I.[License Type] as nvarchar(10)),'Unknown')
			,[Product Description] = ISNULL(CAST(I.[Product Description] as nvarchar(255)),'Unknown')
			,[Product Features] =  ISNULL(CAST(I.[Product Features] as nvarchar(255)),'Unknown')
			,[Category] = ISNULL(CAST(I.[Category] as nvarchar(50)),'Unknown')
			,[PlatForm] = ISNULL(CAST(I.[Platform] as nvarchar(50)), 'Unknown')
			,[Media] = ISNULL(CAST(I.[Media] as nvarchar(50)), 'Unknown')
			,[Version] = ISNULL(CAST(I.[Version] as nvarchar(10)), 'Unknown')
			,[Weight] = ISNULL(CAST(I.[Weight] as nvarchar(10)), 'Unknown')

			from [UDW].[dbo].[DimProducts] P
			inner join [Accounts].[dbo].[SoftwareItems] I on  
			  CAST(P.ProductKeyAlternate  as int) = CAST(I.[ProductID]  as int)
			Where
			 (
   			    P.[ProductKeyAlternate] != CAST(I.[ProductID] as int)
		    or (P.[Software Product Item] != CAST(I.[Software Product Item] as nvarchar(50)))
	        or (P.[License Type] !=   CAST(I.[License Type] as nvarchar(10)))
			or (P.[Product Description] != CAST(I.[Product Description] as nvarchar(255)))
			or (P.[Product Features] !=  CAST(I.[Product Features] as nvarchar(255)))
			or (P.[Category] != CAST(I.[Category] as nvarchar(50)))
			or (P.[PlatForm] != CAST(I.[Platform] as nvarchar(50)))
			or (P.[Media] != CAST(I.[Media] as nvarchar(50)))
			or (P.[Version] != CAST(I.[Version] as nvarchar(10)))
			or (P.[Weight] != CAST(I.[Weight] as nvarchar(10)))
			)
------------------------------------------------------------------------------
-- Extraction of New or Changed Rows into DimGeography.

--script to insert / Changed Rows in DimGeography DWH.

INSERT INTO [UDW].[dbo].[DimGeography]
           ([GeoIDAlternateKey]
		   ,[City]
           ,[State]
           ,[Country]
           ,[Address])
		        
	 Select 
			 ISNULL(C.[CustomerID], 0) 
	        ,CASE ISNULL(C.[City], 'UnKnown')
			 when 'KHI' then 'KARACHI'
			 when 'Karachi' then 'KARACHI'
			 When 'LHR' then 'LAHORE'
			 when 'Lahore' then 'LAHORE'
			 When 'FSD' then 'FAISALABAD'
			 When 'Faisalabad' then 'FAISALABAD'
			 When 'ISB' then 'ISLAMABAD'
			 When 'Islamabad' then 'ISLAMABAD'
			 When 'PSW' then 'PESHAWAR'
			 When 'Peshawar' then 'PESHAWAR'
			 When 'Qty' then 'Quetta'
			 When 'Quetta' then 'QUETTA'
			 When 'MLT' then 'MULTAN'
			 When 'Multan' then 'MULTAN'
			 ELSE
			  UPPER(C.[City] )
			 END
	        ,CASE ISNULL(C.[State],'UnKnown')
			When 'Punjab' then 'PUNJAB'
			when 'Sindh' then 'SINDH'
			when 'Balochistan' then 'BALOCHISTAN'
			when 'Sarhad' then 'KHYBER PAKTHUNKWHA'
			when 'KPK' then 'KHYBER PAKTHUNKWHA'
			when 'Azad Kashmir' then 'AZAD KASHMIR'
			when 'Gilgit-Baltistan' then 'GILGIT-BALTISTAN'
			when 'FATA' then 'FEDERALLY ADMINISTERED TRIBAL AREAS'
			when 'Islamabad' then 'ISLAMABAD CAPITAL TERRITORY'
			else
			 'UnKnown'
			End
		    ,CASE ISNULL(C.[Country], 'UnKnown')
			when 'Pak' then 'PAKISTAN'
			when 'Pakistan' then 'PAKISTAN'
			else
			 UPPER (C.[Country])
			End
			,UPPER(ISNULL(C.[Address], 'UnKnown'))

			from [Accounts].[dbo].[Customers] C 
			left join [UDW].[dbo].DimGeography  G on
			CAST(G.GeoIDAlternateKey as int) = CAST(C.[CustomerID]  as int)
			where G.GeoIDAlternateKey  IS NULL

--			select * from [udw].[dbo].DimGeography 



------------------------------------------------------------------------------
--Script for inserting new / changed record into DimProducts
print 'spCustomerDML Executed Successfully'
--select * from [UDW].[dbo].DimCustomers  
--select * from [Accounts].[dbo].Customers  
--delete from [UDW].[dbo].DimCustomers  
--select * from [UDW].[dbo].DimProducts
--delete from [UDW].[dbo].DimPRoducts 

RETURN 0
END
GO

Exec spCustomerDML 