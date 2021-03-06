USE [Finance]
GO
/****** Object:  Trigger [dbo].[Other_Expenses_Trigger]    Script Date: 9/19/2015 6:12:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[Other_Expenses_Trigger]
   ON  [dbo].[OtherExpenses]
   AFTER  INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	    
		--DECLARE @Authorised_Person_ID as int
		--SELECT @Authorised_Person_ID =  inserted.[Granting EmpID]  from inserted
		--Print @Authorised_Person_ID
		--Exec dbo.spLoadGivenEmployee_Dims @Authorised_Person_ID -- INSERTS THE SECOND EMPLOYEE RECORD INTO DWH.
		
		Exec dbo.spLoadOtherExpenses_Dims   --STORE PROCEDURE CALL TO PROCESS OtherExpense Dimensions.
		Exec dbo.spLoadOtherExpenses_Facts  --Stored Procedure Call to PRocess Other Expenses Facts.
		
	print 'Other_Expense_Trigger Fired Successfully!'
	END
