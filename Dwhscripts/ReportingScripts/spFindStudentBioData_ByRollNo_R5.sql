USE [UDW]
GO
/****** Object:  StoredProcedure [dbo].[spAllRevenueFactsByCustomers_R3]    Script Date: 9/12/2015 12:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <Sept 12 2015>
-- Description:	<A Routine to Fetch All Students Biodata for R4>
-- =============================================
CREATE PROCEDURE [dbo].[spFindStudentBioData_ByRollNo_R5]
	@StudentIDAltKey as int
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
  where S.StudentIDAlternateKey = @StudentIDAltKey
  And S.[StudentKey] !=-1
  ORDER BY S.[First Name] ASC
  


--where RF.CustomersKey != -1   --Check if Customer Exists or Not
--ORDER BY RF.CustomersKey Asc
END
