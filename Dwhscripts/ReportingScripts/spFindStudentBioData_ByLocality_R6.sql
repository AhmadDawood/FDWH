USE [UDW]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <Sept 12 2015>
-- Description:	<A Routine to Fetch All Students Biodata By Locality for R6>
-- =============================================
ALTER PROCEDURE [dbo].[spFindStudentBioData_ByLocality_R6]
	@City nvarchar(50) = NULL
	,@State nvarchar(30) = NULL 
	,@Country nvarchar(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

SELECT [StudentKey]
      ,s.[StudentIDAlternateKey]
      ,s.[First Name] as [First_Name]
      ,s.[Last Name] as [Last_Name]
      ,s.[Father Name] as [Father_Name]
      ,s.[Date of Birth] as [Date_of_Birth]
      ,G.Address
	  ,G.City
	  ,G.State
	  ,G.Country
	  ,s.[Last Qualification] as [Last_Qualification]
      ,s.[Gender] 
      ,s.[Reg Date] as [Reg_Date]
      ,s.[Reg Status] as [Reg_Status]
      ,s.[Degree Status] as [Degree_Status]
      ,s.[E-Mail] as [EMAIL]
      ,s.[Phone Number] as [Phone_Number]
      ,s.[Row Created] as [Row_Created]
      ,s.[Row Validity] as [Row_Validity]
  FROM [dbo].[DimStudents] S
  Inner Join [UDW].[dbo].[DimGeography] G
  ON G.GeoIDAlternateKey = S.StudentIDAlternateKey
  where    
   (@City IS NULL OR G.City = @City)
    AND ((@State IS NULL) OR (G.State = @State))
	AND ((@Country IS NULL) OR (G.Country = @Country))
  And S.[StudentKey] !=-1
  ORDER BY S.[First Name] ASC
END
