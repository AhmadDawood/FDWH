--Script for inserting new / changed record into DimPrograms

INSERT INTO [UDW].[dbo].[DimPrograms]
           ([StudentKeyAlternate]
           ,[Program Name]
           ,[Duration]
           ,[Batch])

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
