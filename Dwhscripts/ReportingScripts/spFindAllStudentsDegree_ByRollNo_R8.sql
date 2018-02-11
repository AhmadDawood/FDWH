USE [UDW]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <Sept 12 2015>
-- Description:	<A Routine to Fetch All Students Biodata for R8>
-- =============================================
CREATE PROCEDURE [dbo].[spFindAllStudentsDegree_ByRollNo_R8]
	
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
      ,P.[Program Name] as [Program_Name]
	  ,P.Duration
	  ,P.Batch
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
  Inner Join [UDW].[dbo].[DimPrograms] P
  ON P.StudentKeyAlternate = S.StudentIDAlternateKey
  where S.[StudentKey] !=-1
  ORDER BY S.[First Name] ASC
  
END
