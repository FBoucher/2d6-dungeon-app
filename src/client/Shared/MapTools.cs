using Microsoft.JSInterop;

namespace c5m._2d6Dungeon.web;

public static class MapTools
{

    public static async Task RefreshCanvas(IJSRuntime js) 
    { 
        await js.InvokeVoidAsync("onResize");
    }

    public static async Task DrawRoom(IJSRuntime js, MappedRoom currentRoom)
    {
        int gidX = (currentRoom.CoordX);
        int gidY = (currentRoom.CoordY);

        await js.InvokeVoidAsync("DrawRoom", gidX, gidY, currentRoom.Width, currentRoom.Height);

        await DrawDoors(js, currentRoom);
    }

    public static async Task DrawDoors(IJSRuntime js, MappedRoom currentRoom)
    {
        foreach (var door in currentRoom.Exits)
        {
            string orientation = GetDoorOrientation(door.onWall);
            int x = 0;
            int y = 0;
            bool isMain = false;

            switch (door.onWall)
            {
                case "N":
                    x = currentRoom.CoordX + door.PositionOnWall;
                    y = currentRoom.CoordY;
                    break;
                case "E":
                    x = currentRoom.CoordX + currentRoom.Width;
                    y = currentRoom.CoordY + door.PositionOnWall;
                    break;
                case "S":
                    x = currentRoom.CoordX + door.PositionOnWall;
                    y = currentRoom.CoordY + currentRoom.Height;
                    isMain = currentRoom.IsLobby;
                    break;
                case "W":
                    x = currentRoom.CoordX;
                    y = currentRoom.CoordY + door.PositionOnWall;
                    break;
            }

            await js.InvokeVoidAsync("DrawDoor", x, y, orientation, isMain);
        }


    }

    private static string GetDoorOrientation(string onWall)
    {
        if (onWall == "S" || onWall == "N")
        {
            return "H";
        }
        return "V";
    }

}
