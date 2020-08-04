
CREATE TABLE [dbo].[TypePayrollDetails](
	[payroll_type_id] [int] identity(1,1),
	[employee_category] [char](50) NOT NULL,
	[yearly_paychecks] [int] NOT NULL,
	[salary_per_paycheck] [MONEY] NOT NULL,
	[employee_yearly_deductions] [MONEY] NOT NULL,
	[dependent_yearly_deductions] [MONEY] NOT NULL,
 CONSTRAINT [TypePayrollDetails_pk] PRIMARY KEY CLUSTERED 
(
	[payroll_type_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[TypePayrollDetails]
           ([employee_category]
           ,[yearly_paychecks]
		   ,[salary_per_paycheck]
           ,[employee_yearly_deductions]
		   ,[dependent_yearly_deductions])
     VALUES
           ('Default'
		   ,26
           ,2000
		   ,1000
		   ,500)
GO
