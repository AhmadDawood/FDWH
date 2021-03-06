USE [Finance]
GO
/****** Object:  StoredProcedure [dbo].[spLoadEmployee_Facts]    Script Date: 9/20/2015 11:03:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <26-Jul-2015>
-- Description:	<Routine to Copy Employee Salary (Facts) into DWH. >
--1- ExpenseFacts  

-- =============================================



ALTER Procedure [dbo].[spLoadEmployee_Facts]
AS
BEGIN

BEGIN TRAN F1

INSERT INTO [UDW].[dbo].[ExpenseFacts]
           ([ExpensesTypeKey]
           ,[EmployeeKey]      -- Expense Request Made By Employee.
           ,[PresentJobKey]
		   ,[ExpAuthorityKey]  -- Granted by
           ,[DateKey]
           ,[HourOfTheDayKey]
           ,[GeoKey]
		   ,[SalaryID]
		   ,[ExpenseID]
           ,[Basic Pay]
           ,[Medical Allowance]
           ,[Conveyance Allowance]
           ,[House Rent]
           ,[Provident Fund]
           ,[Tax Amount]
           ,[Net Salary]
           ,[Expense Amount])
     
    Select 
			ISNULL(DE.ExpenseKey, -1) 
	       ,ISNULL(DEmp.EmployeeKey, -1)          -- REQUEST MADE BY EMPLOYEE.
		   ,ISNULL(DP.[EmpInfoKey], -1)
		   ,ISNULL(A.ExpAuthorKey, -1)             --Granted by
		   ,ISNULL(D.DateKey , -1)
		   ,ISNULL(H.HourKey ,-1)  --HourKey 
		   ,ISNULL(G.GeoKey, -1)    --GeoKey
		   ,ISNULL(S.SalaryId,-1)		--SalaryID
		   ,-1		--OtherExpenseID --NA
		   ,ISNULL(CAST(s.[Basic Pay] as money), 0)  --Basic Pay
		   ,ISNULL(CAST(S.[Medical Allowance]  as smallmoney), 0) -- Medical Allowance
		   ,ISNULL(CAST(S.[Conveyance Allowance]   as smallmoney), 0) -- Conveyance Allowance
		   ,ISNULL(CAST(S.[House Rent]  as smallmoney), 0) -- HOUSE RENT
		   ,ISNULL(CAST(S.[Provident Fund]  as smallmoney), 0) -- PROVIDENT FUND
		   ,ISNULL(CAST(S.[Tax Amount]   as int), 0) -- TAX RATE
		   ,ISNULL(CAST(S.[Net Salary] as money), 0) -- NET SALARY.
		   ,0              -- Other Expense Type Amount
		   
		    FROM [Finance].[dbo].[SalaryExpenses]  S
		    LEFT JOIN [UDW].[dbo].[DimExpenseCategory] DE
			ON  CAST(DE.ExpensesAltKey  as int ) = CAST(S.ExpDescID as int )
		    LEFT JOIN [UDW].[dbo].[DimEmployee] DEmp						-- Requesting EmployeeID
		    ON  CAST(DEmp.EmployeeIDAltKey  as int) = CAST(S.EmpID   as int)
			LEFT JOIN [UDW].[dbo].[DimPresentJob] DP 
		    ON  CAST(DP.EmployeeIDAltKey  as int ) = CAST(S.EmpID  as int)  
		    LEFT JOIN [UDW].[dbo].[DimExpenseAuthorisation] A
			ON CAST(A.GrantedByAltKey as int) = CAST(S.AuthorisedByID as int)
		    LEFT JOIN [UDW].[dbo].[DimDates] D     
		    ON CAST(D.[Full Date] as date ) = CAST(S.[Salary Paid On]  as date)
		    LEFT JOIN [UDW].[dbo].[DimHourOFTheDay] H
		    ON  CAST (H.HourKey as int) = DateName(Hour,S.[Salary Paid On] )
			LEFT JOIN [UDW].[dbo].[DimGeography]  G
		    ON  CAST(G.GeoIDAlternateKey  as int) = CAST(S.EmpID  as int)
			LEFT JOIN [UDW].[dbo].ExpenseFacts  EF
		    ON  CAST(EF.SalaryID  as int) = CAST (S.SalaryId  as int)
			
			where EF.SalaryID is null

 IF (@@ERROR <> 0) GOTO ERROR_HANDLER_F1 --IN CASE OF UN-EXPECTED ERROR WE CANCELS THE WHOLE TRANSACTION.

COMMIT TRAN F1

Print 'LoadSalary Facts Executed Successfully!'

RETURN 0



ERROR_HANDLER_F1:

IF (@@ERROR <> 0) BEGIN
	PRINT 'UN-EXPECTED PROBLEMS OCCURED DURING POPULATING Student Revenue FACT TABLE. PROCESS ABORTED!'
	ROLLBACK TRAN F1
	RETURN 1
	END

--------------------- The End Employees Salary Facts Part   --------------------------------------------------
END
