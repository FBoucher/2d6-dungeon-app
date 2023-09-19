# 2d6 Dungeon-app


## Making of notes

To create the `dab-config.MySql.json` file I needed to create the folder first, and execute this command.

```
dab init --database-type mysql --connection-string "Server=localhost;Database=2d6db;User ID=frank;Password=myPassword;" --host-mode "Development" --cors-origin "http://localhost:5000" 
```

> Note: I needed to remove ` --authenticate-devmode-requests false` it was causing an error.

Adding some entities

```
dab add Room --source Rooms --source.key-fields RoomID --permissions "anonymous:create,read,update,delete"
```

```
dab add BodySearch --source BodySearch --source.key-fields BodySearchID --permissions "admin:*"
```

> QQ: how to set anonymous: Read and admin:*

```
dab start 
```


then 

```
http://localhost:5000/api/Room
```

To add a new Room 

POST http://localhost:5000/api/Room

{
	"Roll": 14,
	"Exits": "Random",
	"Level": 1,
	"RoomType": "Mason's workshop",
	"isUnique": true,
	"Encounter": "Roll a D6. 1-4= an artisan is here. You must fight them. If you survive roll on TCT1",
	"Description": "Large blocks of stone scatter the space, iron..."
}




docker run -it -v "C:\dev\github\fboucher\2d6-dungeon-app\src\:/App/configs" -p 5000:5000 mcr.microsoft.com/azure-databases/data-api-builder:latest --ConfigFileName ./configs/dab-config.json