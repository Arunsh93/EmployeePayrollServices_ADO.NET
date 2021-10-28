CREATE PROCEDURE [dbo].[SpAddEmployeeDetails]
(
	@EmpName varchar(20),
	@BasicPay float,
	@StartDate Date,
	@Gender varchar(5),
	@PhoneNumber varchar(15),
	@Department varchar(10),
	@Address varchar(20),
	@Deduction float,
	@TaxablePay float,
	@IncomeTax float,
	@NetPay float
)
AS
	Insert into Employee_Payroll values (@EmpName, @BasicPay, @StartDate, @Gender, @PhoneNumber,
										 @Department, @Address, @Deduction, @TaxablePay, @IncomeTax, @NetPay);
GO
