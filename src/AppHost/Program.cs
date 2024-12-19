var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql")
                   //.WithPhpMyAdmin()
                   .WithLifetime(ContainerLifetime.Persistent);
                
var db2d6 = mysql.AddDatabase("db2d6");

mysql.WithBindMount("../../database/scripts/schema.sql", "/docker-entrypoint-initdb.d/1.sql")
     .WithBindMount("../../database/scripts/data.sql", "/docker-entrypoint-initdb.d/2.sql");
                        
var dab = builder.AddDataAPIBuilder("dab", ["../../database/dab-config.json"])
                .WithReference(db2d6)
                .WaitFor(db2d6);

builder.AddProject<Projects._2d6_dungeon_web_client>("webapp") 
        .WaitFor(dab)
        .WithReference(dab); 

builder.Build().Run();
