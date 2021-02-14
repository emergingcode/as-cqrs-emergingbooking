#addin nuget:?package=Cake.SqlServer&loaddependencies=true

var dbName = "EmergingBooking";
var connectionString = @"Server=localhost,1433;User=sa;Password=EmergingB00king@2019;";
var databaseName = $@"Database={dbName};";
var target = Argument("target", "Default");

Task("Uninstall-FluentMigrator-Cli")
    .ContinueOnError()
    .Does(() => {
        DotNetCoreTool("tool uninstall -g FluentMigrator.DotNet.Cli");
    });
    
Task("Install-FluentMigrator-Cli")
    .ContinueOnError()
    .Does(() => {
        DotNetCoreTool("tool install -g FluentMigrator.DotNet.Cli");
    });    

Task("Apply-Migrations")
    .Does(() => {
        DotNetCoreTool("fm migrate -p sqlserver -c '" + connectionString + databaseName + "' -a './bin/Debug/netstandard2.0/EmergingBooking.Migrations.dll'");
    });

Task("Create-Database")
    .Does(() => {
        CreateDatabaseIfNotExists(connectionString, dbName);
    });

 Task("Build-Migrations-Project")
    .Does(() =>
    {
         MSBuild("./EmergingBooking.Migrations.csproj", configurator => 
            configurator
                .SetConfiguration("Debug")
                .SetVerbosity(Verbosity.Minimal)
                .UseToolVersion(MSBuildToolVersion.VS2017)
                .SetMSBuildPlatform(MSBuildPlatform.Automatic));
    });

Task("Default")
    .IsDependentOn("Build-Migrations-Project")
    .IsDependentOn("Create-Database")
    .IsDependentOn("Uninstall-FluentMigrator-Cli")
    .IsDependentOn("Install-FluentMigrator-Cli")
    .IsDependentOn("Apply-Migrations");
    
RunTarget(target);