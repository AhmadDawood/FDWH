USE [Accounts]
GO
/****** Object:  Trigger [dbo].[Student_Payment_DMLTrigger]    Script Date: 7/23/2015 10:17:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[Student_Payment_Trigger]
   ON  [dbo].[StudentFeesDetails]
   AFTER  INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		Exec dbo.sploadStudent_Dims   --STORE PROCEDURE CALL TO PROCESS ALL Customer Dimensions.
	    Exec dbo.spLoadStudent_Facts  --Stored Procedure Call to PRocess CustomerFacts.

	print 'Customers_Payment_DMLTrigger Fired Successfully!'
	END
