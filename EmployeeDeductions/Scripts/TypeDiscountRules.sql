
CREATE TABLE [dbo].[TypeDiscountRules](
	[discount_type_id] [int] identity(1,1),
	[discount_rule] [char](50) NOT NULL,
	[discount_description] [char](200) NOT NULL,
	[discount] numeric(4,4) NOT NULL
 CONSTRAINT [TypeDiscountRules_pk] PRIMARY KEY CLUSTERED 
(
	[discount_type_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[TypeDiscountRules]
           ([discount_rule]
           ,[discount_description]
		   ,[discount])
     VALUES
           ('A'
		   ,'Anyone whose name starts with "A" gets a 10% discount'
           ,0.10)
GO