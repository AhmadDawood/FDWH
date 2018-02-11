--script to insert / Changed Rows in DimGeography DWH.

INSERT INTO [UDW].[dbo].[DimGeography]
           ([GeoIDAlternateKey]
		   ,[City]
           ,[State]
           ,[Country]
           ,[Address])
		        
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

			from Registration.dbo.Student_BioData Bloc
			left join [UDW].[dbo].DimGeography  g on
			CAST(g.GeoIDAlternateKey as int) = CAST(Bloc.[Roll Number] as int)
			where g.GeoIDAlternateKey  IS NULL

		--Script to update changed rows.
		update g
		set 
		     g.GeoIDAlternateKey =ISNULL(Bloc.[Roll Number], 0) 
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