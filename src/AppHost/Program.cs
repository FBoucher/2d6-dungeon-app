var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql")
                   //.WithPhpMyAdmin()
                   .WithLifetime(ContainerLifetime.Persistent);
                
var db2d6 = mysql.AddDatabase("db2d6");

mysql.WithBindMount(GetFullPath("../../database/scripts/schema.sql"), "/docker-entrypoint-initdb.d/1.sql")
     .WithBindMount(GetFullPath("../../database/scripts/data.sql"), "/docker-entrypoint-initdb.d/2.sql");
                        
var dab = builder.AddDataAPIBuilder("dab", [GetFullPath("../../database/dab-config.json")])
                .WithReference(db2d6)
                .WaitFor(db2d6);

builder.AddProject<Projects._2d6_dungeon_web_client>("webapp") 
        .WaitFor(dab)
        .WithReference(dab)
        .WithExternalHttpEndpoints(); 

builder.Build().Run();


static string GetFullPath(string relativePath) =>
    Path.GetFullPath(Path.Combine(Projects.AppHost.ProjectPath, relativePath));