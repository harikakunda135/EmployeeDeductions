CREATE TABLE [dbo].[EmployeeDetails](
	[employee_number] [int] identity(1,1),
	[employee_name] [VARCHAR](50) NOT NULL,
	[department_id] [int] NULL,
	[dependent1_name] [VARCHAR](50)  NULL,
	[dependent2_name]  [VARCHAR](50)  NULL,
    [dependent3_name]  [VARCHAR](50)  NULL,
    [dependent4_name]  [VARCHAR](50)  NULL,
	[dependent5_name]  [VARCHAR](50)  NULL,
	[paycheck_salary] [MONEY] NOT NULL,
	[paycheck_deductions] [MONEY] NOT NULL,
	[COMMENTS] [VARCHAR](500)  NULL,
 CONSTRAINT [EmployeeDetails_pk] PRIMARY KEY CLUSTERED 
(
	[employee_number] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
