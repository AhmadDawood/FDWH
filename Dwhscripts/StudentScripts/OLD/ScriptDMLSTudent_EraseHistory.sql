-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <16-Jul-2015>
-- Description:	<Routine to Copy StudentOBject Data(Dimensions, Fact) into DWH. This Script Does not Preserve History in DWH>.
--             SCD Type 1 <Erase History> Script.
--1- DimStudents
--2- DimPrograms
--3- DimGeography
-- =============================================

--Script for inserting new record into Student Dimension in DWH.

/*
BEGIN TRAN

IF (@@ERROR <> 0) 
BEGIN
-- Put All code here for execution
Print 'Some Error has been Occured during the Processing of StudentOBJDML Execution'
ROLLBACK TRAN
End
*/
--delete from [UDW].[dbo].DimStudents 
--DRop Constraints 
--Truncate table [UDW].[dbo].[DimStudents]

INSERT INTO [UDW].[dbo].[DimStudents] 
           ([StudentIDAlternateKey] 
		   ,[First Name]
           ,[Last Name]
           ,[Date of Birth]
           ,[Last Qualification]
           ,[Gender]
           ,[Reg Date]
           ,[Reg Status]
           ,[Degree Status]     
		   ,[E-MAIL]
		   ,[PHONE NUMBER]
		   ,[Row Created]
		   ,[Row Validity]
           )
     -- SELECT DATA FROM REGISTRATION DB TBLS.
	 
select 
            CAST(ISNULL(B.[Roll Number], 0) AS int)
           ,UPPER(CAST(ISNULL(B.[First Name], 'UnKnown') as nvarchar(25)) )
           ,UPPER(CAST(ISNULL(B.[Last Name], 'UnKnown') as nvarchar(25)) )
           ,CAST(ISNULL(B.[Date of Birth], '1900-01-01') as date)
           ,CASE CAST(ISNULL(B.[Highest Education], 'UnKnown') as nvarchar(50))  --eDUCATION
		    When 'F.S.C' then 'FSC'
			When 'fsc' then 'FSC'
			When 'Fsc' then 'FSC'
			When 'F.A' then 'FA'
			When 'fa' then 'FA'
			When 'icom' then 'ICOM'
			When 'I-com' then 'ICOM'
			when 'dcom' then 'DCOM'
			when 'D com' then 'DCOM'
			when 'B.A' then 'BA'
			When 'ba' then 'BA'
			when 'Ba' then 'BA'
			when 'Bsc' then 'BSC'
			when 'B.S.C' then 'BSC'
			when 'B.Com' then 'BCOM'
			when 'B.B.A' then 'BBA'
			when 'Bsc Hons' then 'BSC HONS'
			when 'BsIT' then 'BSIT'
			when 'M.A' then 'MA'
			when 'M.com' then 'MCOM'
			when 'M.s.c' then 'MSC'
			when 'M.c.s' then 'MCS'
			else
			 UPPER(B.[Highest Education] )
			End 
		   ,CASE CAST(ISNULL(B.[Gender], 'UnKnown') as nvarchar(6))
			 When 'male' then 'MALE'
			 When 'female' then 'FEMALE'
			 else
			  UPPER(B.[Gender])
			 END
           ,CAST(ISNULL(e.[Reg Date], '1900-01-01') as date)  
           ,CASE CAST(ISNULL(e.[Reg Status], 'UnKnown') as nvarchar(15))
		    When 'active' then 'ACTIVE'
			When 'Active' then 'ACTIVE'
			When 'unactive' then 'In-Active'
			When 'nonactive' then 'In-Active'
			When 'unknown' then 'UnKnown'
			else
			 'UnKnown'
			End
           ,CASE CAST(ISNULL(e.[Degree Status], 'UnKnown') as nvarchar(15))
		     When 'incomplete' then 'IN-COMPLETE'
			 When 'In-Complete' then 'IN-COMPLETE'
			 When 'Complete' then 'COMPLETE'
			 When 'complete' then 'COMPLETE'
			 When 'unknown' then 'UnKnown'
			 else
			  'UnKnown'
			 End
		   ,CAST(ISNULL(B.Email, 'UnKnown') as nvarchar(50))
		   ,CAST(ISNULL(b.[Phone Number], 'UnKnown') as nvarchar(50))
		   ,CAST(GetDate() as smalldatetime ) -- Row Created In Which DateTime.
		   ,CAST('2020-01-01' as smalldatetime ) -- Row Expired ON.

           from [Registration].[dbo].[Student_BioData] B  
           left join Registration.dbo.Student_Enrollment e on 
			 CAST(B.[Roll Number] as int) = CAST(e.[Roll Number] as int)
			 left join UDW.dbo.DimStudents s on
			   CAST(b.[Roll Number] as int)  = CAST(s.[StudentIDAlternateKey] as int)
               where s.[StudentIDAlternateKey] is null
			
			select * from UDW.dbo.DimStudents  
-- Script for Updating DimStudents Field in  Rows.

	update s
		set 
		    s.[StudentIDAlternateKey]  = CAST(ISNULL(B.[Roll Number],0) AS int)
		    ,s.[First Name] = UPPER(CAST(ISNULL(B.[First Name], 'UnKnown') as nvarchar(25)))
            ,s.[Last Name] = UPPER(CAST(ISNULL(B.[Last Name], 'UnKnown') as nvarchar(25)) )
			,s.[Date of Birth] = CAST(ISNULL(B.[Date of Birth], '1900-01-01') as date)
			,s.[Gender] =CASE  CAST(ISNULL(B.[Gender], 'UnKnown') as nvarchar(6))
			 When 'male' then 'MALE'
			 When 'female' then 'FEMALE'
			 END
			,s.[Last Qualification] = CASE CAST(ISNULL(b.[Highest Education] , 'UnKnown') as nvarchar )  --eDUCATION
			When 'F.S.C' then 'FSC'
			When 'fsc' then 'FSC'
			When 'Fsc' then 'FSC'
			When 'F.A' then 'FA'
			When 'fa' then 'FA'
			When 'icom' then 'ICOM'
			When 'I-com' then 'ICOM'
			when 'dcom' then 'DCOM'
			when 'D com' then 'DCOM'
			when 'B.A' then 'BA'
			When 'ba' then 'BA'
			when 'Ba' then 'BA'
			when 'Bsc' then 'BSC'
			when 'B.S.C' then 'BSC'
			when 'B.Com' then 'BCOM'
			when 'B.B.A' then 'BBA'
			when 'Bsc Hons' then 'BSC HONS'
			when 'BsIT' then 'BSIT'
			when 'M.A' then 'MA'
			when 'M.com' then 'MCOM'
			when 'M.s.c' then 'MSC'
			when 'M.c.s' then 'MCS'
			else
			 UPPER(B.[Highest Education] )
			End 
			,s.[Reg Date] = CAST(ISNULL(e.[Reg Date], '1900-01-01') as date)
			,s.[Reg Status] = CASE CAST(ISNULL(e.[Reg Status], 'UnKnown') as nvarchar(15))
			 When 'active' then 'ACTIVE'
			 When 'Active' then 'ACTIVE'
			 When 'unactive' then 'In-Active'
			 When 'nonactive' then 'In-Active'
			 When 'unknown' then 'UnKnown'
			 else
			  'UnKnown'
			 End
			,s.[Degree Status] = CASE CAST(ISNULL(e.[Degree Status], 'UnKnown') as nvarchar(15))
			 When 'incomplete' then 'IN-COMPLETE'
			 When 'In-Complete' then 'IN-COMPLETE'
			 When 'Complete' then 'COMPLETE'
			 When 'complete' then 'COMPLETE'
			 When 'unknown' then 'UnKnown'
			 else
			  'UnKnown'
			 End
			,s.[E-mail] =  CAST(ISNULL(B.Email, 'UnKnown') as nvarchar(50))
		    ,s.[Phone Number] = CAST(ISNULL(b.[Phone Number], 'UnKnown') as nvarchar(50))
            ,s.[Row Created] =  CAST(GetDate() as smalldatetime ) -- Row Created In Which DateTime.
    	    ,s.[Row Validity] = CAST('2020-01-01' as smalldatetime ) -- Row Expired ON.

			from [UDW].[dbo].DimStudents s
			inner join [Registration].[dbo].Student_BioData b on  
			 CAST(s.[StudentIDAlternateKey] as int)   = CAST(b.[Roll Number] as int)
			inner join [Registration].[dbo].Student_Enrollment e on
			  CAST(s.[StudentIDAlternateKey] as int)  = CAST(e.[Roll Number] as int)
			where
			( 
			( s.[StudentIDAlternateKey]  != CAST(ISNULL(B.[Roll Number],0) AS int))
			or (s.[First Name] != CAST(ISNULL(B.[First Name], 'UnKnown') as nvarchar(25)))
			or (s.[Last Name] != CAST(ISNULL(B.[Last Name], 'UnKnown') as nvarchar(25)))
			or s.[Date of Birth] != CAST(ISNULL(B.[Date of Birth], '1900-01-01') as date)
			or (s.[Gender] !=  CAST(ISNULL(B.[Gender], 'UnKnown') as nvarchar(6)))
			or (s.[Last Qualification] != CAST(ISNULL(b.[Highest Education] , 'UnKnown') as nvarchar(50))) --eDUCATION 
			or (s.[Reg Date] != CAST(ISNULL(e.[Reg Date], '1900-01-01') as date) )
			or (s.[Reg Status] != CAST(ISNULL(e.[Reg Status], 'UnKnown') as nvarchar(15)) )
			or (s.[Degree Status] != CAST(ISNULL(e.[Degree Status], 'UnKnown') as nvarchar(15)))
			or (s.[E-mail] !=  CAST(ISNULL(B.Email, 'UnKnown') as nvarchar(50)))
		    or (s.[Phone Number] != CAST(ISNULL(b.[Phone Number], 'UnKnown') as nvarchar(50)))
			--or (s.[Row Created] =  CAST(GetDate() as smalldatetime ) -- Row Created In Which DateTime.
    	    --or (s.[Row Validity] = CAST('2020-01-01' as smalldatetime ) -- Row Expired ON.

			)
			
			--select * from UDW.dbo.DimStudents  
			--delete from UDW.dbo.DimStudents 

--Script for inserting new / changed record into DimPrograms

INSERT INTO [UDW].[dbo].[DimPrograms]
           ([StudentKeyAlternate]
           ,[Program Name]
           ,[Duration]
           ,[Batch]
		   ,[Row Created]
		   ,[Row Validity]
		   )

     -- SELECT DATA FROM REGISTRATION DB TBLS.
select 
           
		     [StudentKeyAlternate] = CAST(ISNULL(e.[Roll Number], 0) AS INT)
		    ,[Program Name] = case CAST(e.[Degree EnrolledIN] AS nvarchar(50)) 
			When 'F.S.C' then 'FSC'
			When 'fsc' then 'FSC'
			When 'Fsc' then 'FSC'
			When 'F.A' then 'FA'
			When 'fa' then 'FA'
			When 'icom' then 'ICOM'
			When 'I-com' then 'ICOM'
			when 'dcom' then 'DCOM'
			when 'D com' then 'DCOM'
			when 'B.A' then 'BA'
			When 'ba' then 'BA'
			when 'Ba' then 'BA'
			when 'Bsc' then 'BSC'
			when 'B.S.C' then 'BSC'
			when 'B.Com' then 'BCOM'
			when 'B.B.A' then 'BBA'
			when 'Bsc Hons' then 'BSC HONS'
			when 'BsIT' then 'BSIT'
			when 'M.A' then 'MA'
			when 'M.com' then 'MCOM'
			when 'M.s.c' then 'MSC'
			when 'M.c.s' then 'MCS'
			when 'mcom' then 'MCOM'
			when 'mscs' then 'MSCS'
			else
			 UPPER(e.[Degree EnrolledIN])
			End
		    ,[Duration] = CAST(ISNULL(e.Duration, 'UnKnown') as nvarchar(15)) 
            ,[Batch] = CAST(ISNULL(e.Batch, 'UnKnown') as nvarchar(10)) 
            ,CAST(GetDate() as smalldatetime ) -- Row Created In Which DateTime.
    		,CAST('2020-01-01' as smalldatetime ) -- Row Expired ON.

           from Registration.dbo.Student_Enrollment e  
		    left join [UDW].[dbo].DimPrograms p on
			CAST(e.[Roll Number] as int) = CAST(p.StudentKeyAlternate as int) --it is student id
			where p.StudentKeyAlternate IS NULL

-- Script for Updating Fields in a Rows.

	update p
		set 
		    p.StudentKeyAlternate = CAST(ISNULL(e.[Roll Number], 0) as int) 
		    ,[Program Name] = case CAST(e.[Degree EnrolledIN] AS nvarchar(50)) 
			When 'F.S.C' then 'FSC'
			When 'fsc' then 'FSC'
			When 'Fsc' then 'FSC'
			When 'F.A' then 'FA'
			When 'fa' then 'FA'
			When 'icom' then 'ICOM'
			When 'I-com' then 'ICOM'
			when 'dcom' then 'DCOM'
			when 'D com' then 'DCOM'
			when 'B.A' then 'BA'
			When 'ba' then 'BA'
			when 'Ba' then 'BA'
			when 'Bsc' then 'BSC'
			when 'B.S.C' then 'BSC'
			when 'B.Com' then 'BCOM'
			when 'B.B.A' then 'BBA'
			when 'Bsc Hons' then 'BSC HONS'
			when 'BsIT' then 'BSIT'
			when 'M.A' then 'MA'
			when 'M.com' then 'MCOM'
			when 'M.s.c' then 'MSC'
			when 'M.c.s' then 'MCS'
			when 'mcom' then 'MCOM'
			when 'mscs' then 'MSCS'
			else
			 UPPER(e.[Degree EnrolledIN])
			End
		    ,p.Duration = CAST(ISNULL(e.Duration, 'UnKnown') as nvarchar(15)) 
			,p.Batch = CAST(ISNULL(e.Batch, 'UnKnown') as nvarchar(10))
			,p.[Row Created] =  CAST(GetDate() as smalldatetime ) -- Row Created In Which DateTime.
    	    ,p.[Row Validity] = CAST('2020-01-01' as smalldatetime ) -- Row Expired ON.

			from [UDW].[dbo].DimPrograms p
			inner join [Registration].[dbo].Student_Enrollment e on  
			  p.StudentKeyAlternate  = e.[Roll Number]
			where
			(
			   (p.[StudentkeyAlternate]  != CAST((e.[Roll Number]) as int))
			or (p.[Program Name] != e.[Degree EnrolledIN] )
			or (p.Duration != CAST(e.Duration as nvarchar(15)))
			or (p.Batch  != CAST(e.Batch  as nvarchar(10)))
			)

			--select * from UDW.dbo.DimPrograms
			--select * from [Registration].[dbo].Student_Enrollment  
			--delete from [UDW].[dbo].DimPrograms  
-----------------------------------------------------------------------------------------------------------------

--script to insert / Changed Rows in DimGeography DWH.

INSERT INTO [UDW].[dbo].[DimGeography]
           ([GeoIDAlternateKey]
		   ,[City]
           ,[State]
           ,[Country]
           ,[Address]
		   ,[Row Created]
		   ,[Row Validity]
		   )
		        
	 Select 
			 ISNULL(Bloc.[Roll Number], 0) 
	        ,CASE ISNULL(Bloc.[City], 'UnKnown')
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
			  UPPER(Bloc.City )
			 END
	        ,CASE ISNULL(Bloc.[State],'UnKnown')
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
		    ,CASE ISNULL(Bloc.[Country], 'UnKnown')
			when 'Pak' then 'PAKISTAN'
			when 'Pakistan' then 'PAKISTAN'
			else
			 UPPER (Bloc.[Country])
			End
			,UPPER(ISNULL(Bloc.[Address], 'UnKnown'))
			,CAST(GetDate() as smalldatetime ) -- Row Created In Which DateTime.
		    ,CAST('2020-01-01' as smalldatetime ) -- Row Expired ON.

			from Registration.dbo.Student_BioData Bloc
			left join [UDW].[dbo].DimGeography  g on
			CAST(g.GeoIDAlternateKey as int) = CAST(Bloc.[Roll Number] as int)
			where g.GeoIDAlternateKey  IS NULL

		--Script to update changed rows.
	update g
		set 
		     g.GeoIDAlternateKey =ISNULL(Bloc.[Roll Number], -1) 
		    ,g.[City] = CASE ISNULL(Bloc.[City], 'UnKnown')
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
			  UPPER(Bloc.City )
			 END
            ,g.[State] = CASE ISNULL(Bloc.[State],'UnKnown')
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
            ,g.[Country] = CASE ISNULL(Bloc.[Country], 'UnKnown')
			when 'Pak' then 'PAKISTAN'
			when 'Pakistan' then 'PAKISTAN'
			else
			 UPPER (Bloc.[Country])
			End
            ,g.[Address] = UPPER(ISNULL(Bloc.[Address], 'UnKnown'))
			,g.[Row Created] =  CAST(GetDate() as smalldatetime ) -- Row Created In Which DateTime.
    	    ,g.[Row Validity] = CAST('2020-01-01' as smalldatetime ) -- Row Expired ON.

			from [UDW].[dbo].DimGeography  g 
			inner join [Registration].[dbo].Student_BioData Bloc on  
			  CAST(g.GeoIDAlternateKey as int) = CAST(Bloc.[Roll Number] as int)
			where
			( 
			(g.GeoIDAlternateKey  != Bloc.[Roll Number])
			or (g.City != CAST(Bloc.City as nvarchar(50)))
			or (g.State != CAST(Bloc.State as nvarchar(50)))
			or (g.Country != CAST(Bloc.Country as nvarchar(50)))
			or (g.Address != CAST(Bloc.Address as nvarchar(50)))
			)
			--SELECT * FROM UDW.DBO.DimGeography 
			--DELETE FROM  UDW.DBO.DimGeography 
---------------------------------------------------------------------------------------------------------------



--COMMIT TRAN
