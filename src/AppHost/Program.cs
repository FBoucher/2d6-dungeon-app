var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("sqlsvr2d6")
                   //.WithPhpMyAdmin()
                   .WithLifetime(ContainerLifetime.Persistent);
                
var db2d6 = mysql.AddDatabase("db2d6");

// mysql.WithBindMount(source: "../../database/scripts/schema.sql", target: "/docker-entrypoint-initdb.d/1.sql")
//      .WithBindMount(source: "../../database/scripts/data.sql",  target: "/docker-entrypoint-initdb.d/2.sql");

mysql.WithBindMount(source: "../../database/scripts", target: "/docker-entrypoint-initdb.d");


var dab = builder.AddDataAPIBuilder("dab", ["../../database/dab-config.json"])
                .WithReference(db2d6)
                .WaitFor(db2d6);

builder.AddProject<Projects._2d6_dungeon_web_client>("webapp") 
        .WaitFor(dab)
        .WithReference(dab)
        .WithExternalHttpEndpoints(); 

builder.Build().Run();


// static string GetFullPath(string relativePath) =>
//     Path.GetFullPath(Path.Combine(Projects.AppHost.ProjectPath, relativePath));