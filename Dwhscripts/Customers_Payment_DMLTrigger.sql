USE [Accounts]
GO
/****** Object:  Trigger [dbo].[Customers_Payment_DMLTrigger]    Script Date: 7/23/2015 5:38:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[Customers_Payment_DMLTrigger]
   ON  [dbo].[CustomerOrders]
   AFTER  INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		Exec dbo.spLoadCustomer_Dims   --STORE PROCEDURE CALL TO PROCESS ALL Customer Dimensions.
	    Exec dbo.spLoadCustomer_Facts  --Stored Procedure Call to PRocess CustomerFacts.

	print 'Customers_Payment_DMLTrigger Fired Successfully!'
	END
