$contextname = 'EmployeeDetailsContext'
$outputDirectory = 'Models'
$contextfilepath = "EmployeeDeductions\$OutputDirectory\EmployeeDetailsContext.cs"
#$databaseUserName = Read-Host -Prompt 'Database User Name'
#$databaseUserPassword = Read-Host -Prompt 'Database User Password' -AsSecureString
#$plaintextPassword = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($databaseUserPassword)) 
$azureConnectionString = "Server=tcp:harikapayrollmanagement.database.windows.net,1433;Database=PayrollManagement;User ID=harika;Password=Pintu@135;Encrypt=True;TrustServerCertificate=False;"
Scaffold-DbContext $azureConnectionString Microsoft.EntityFrameworkCore.SqlServer `
	-OutputDir $OutputDirectory `
	-Tables EmployeeDetails,TypeDiscountRules,TypePayrollDetails `
	-Context $contextname `
	-UseDatabaseNames `
	-Project 'EmployeeDeductions' `
	-StartupProject 'EmployeeDeductions' `
	-Force

#Replace the default OnConfiguration that has a fixed Connection String with a simple constructor
$contextfile = Get-Content $contextfilepath -Raw
#$newcontextfile = $contextfile -Replace 'protected.*OnConfiguring(((?!}).|[\r\n])*)}[^}]*\}', "public $contextname(DbContextOptions<$contextname> options) : base(options) { }"
$newcontextfile = $contextfile -Replace 'protected.*OnConfiguring(((?!}).|[\r\n])*)}[^}]*\}', ""
Set-Content $contextfilepath $newcontextfile

