-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <16-Jul-2015>
-- Description:	<Routine to Copy StudentOBject Data(Dimensions, Fact) into DWH. This Script Creates Readonly DWH <SCD0> >.
--1- DimStudents
--2- DimPrograms
--3- DimGeography
--4- DimFeesVoucherID
-- =============================================

--Script for inserting new record into Student Dimension in DWH.

CREATE Procedure [dbo].[spLoadStudent_Dims]
AS
BEGIN

INSERT INTO [UDW].[dbo].[DimStudents] 
           ([StudentIDAlternateKey] 
		   ,[First Name]
           ,[Last Name]
           ,[Father Name]
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
           ,UPPER(CAST(ISNULL(B.[Father Name],  'UnKnown') as nvarchar(50)) )
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


			   IF (@@ERROR <> 0) BEGIN
			    PRINT 'Error Occured During Data Transfer to DimStudents!'
		
				RETURN 1
		    	END


--Script for inserting New Rows into DimPrograms

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

			IF (@@ERROR <> 0) BEGIN
		    PRINT 'Error Occured During Data Transfer to DimPrograms!'
		
			RETURN 1
			END

--script to insert New Rows in DimGeography DWH.

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

			IF (@@ERROR <> 0) BEGIN
		    PRINT 'Error Occured During Data Transfer to DimGeoraphy!'
		
			RETURN 1
			END
-------------------------------------------------------------------------------------------------
     
		INSERT INTO [UDW].[dbo].[DimFeeVoucherID]
					([FeeVoucherAltKey])
	
		SELECT ISNULL(F.VoucherID, 1) 
	       FROM [Accounts].[dbo].StudentFeesDetails F 
		   LEFT JOIN [UDW].[dbo].[DimFeeVoucherID] DF
		   ON CAST (DF.FeeVoucherAltKey as int ) = CAST(F.VoucherID  as int)
		   where DF.FeeVoucherAltKey IS NULL


		   IF (@@ERROR <> 0) BEGIN
		    PRINT 'Error Occured During Data Transfer to DimFeeVoucherID!'
		
			RETURN 1
			END

-----------------------------------------------------------------------------

END