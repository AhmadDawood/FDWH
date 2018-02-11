USE [UDW]
GO
/****** Object:  StoredProcedure [dbo].[spFindAllStudentsDegree_ByRollNo_R8]    Script Date: 9/13/2015 12:43:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <Sept 12 2015>
-- Description:	<A Routine to Fetch Individual Students Fees Payment info for R9>
-- =============================================
CREATE PROCEDURE [dbo].[spFindStudentRevenueFact_ByRollNo_R9]
	@StudentIDAltKey as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

Select
	 RevenueKey
    ,[Student_Name] = (S.[First Name] + ' ' + S.[Last Name])
	,[Program_Name] = (P.[Program Name])
	,[City] = (G.City)
	,[Payment_Date] = CAST((D.[Full Date]) as date)
	,[Hour_of_the_Day] = (H.Hour)
	,[FeesVoucherID] = RF.FeesVoucherID
	,[StudentFees] = Rf.StudentFees
	,[LatePayment_Fine] = RF.LateFeesAmount
	,[Net_Amount] = RF.[Net Amount]
 FROM REVENUEFACTS AS RF
           INNER JOIN [UDW].[dbo].[DimStudents] S 
		   ON  CAST(S.StudentKey as int) = CAST(RF.StudentKey as int) 
		   INNER JOIN [UDW].[dbo].[DimPrograms] P 
		   ON  CAST(P.ProgramKey as int) = CAST(RF.ProgramKey as int) 
		   INNER JOIN [UDW].[dbo].[DimGeography] G 
		   ON  CAST(G.GeoKey as int) = CAST(RF.GeoKey as int) 
		   INNER JOIN [UDW].[dbo].[DimDates] D 
		   ON  CAST(D.DateKey as int) = CAST(RF.DateKey as int) 
		   INNER JOIN [UDW].[dbo].[DimHourOFTheDay] H 
		   ON  CAST(H.HourKey as int) = CAST(RF.HourOfTheDayKey as int) 
where S.StudentIDAlternateKey = @StudentIDAltKey
		And S.[StudentKey] !=-1  
END
