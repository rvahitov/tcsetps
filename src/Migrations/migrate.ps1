param(
[String]
$Connection="Data Source=testsrv;Initial Catalog=Correct.PapperStorage; Integrated Security=True"
)
dotnet fm migrate -p SqlServer -c "$Connection" -a "Correct.Storage.Migrations.dll"