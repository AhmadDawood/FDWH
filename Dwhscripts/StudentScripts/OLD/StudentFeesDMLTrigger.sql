SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ahmed Dawood>
-- Create date: <03-Jul-2015>
-- Description:	<Trigger to Copy StudentOBject Data(Dimensions, Fact) into DWH>.
-- =============================================

use Accounts
GO
ALTER TRIGGER StudentFeesDMLTrigger
   ON  [Accounts].[dbo].[StudentFeesDetails]
   AFTER  INSERT, UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		Exec spStudentOBJDML  --sTORED PROCEDURE CALL TO PROCESS ALL STUDENT OBJECT DATA.
	print 'After spStudentOBJDML'
	END
GO