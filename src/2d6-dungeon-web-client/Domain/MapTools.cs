using Microsoft.JSInterop;

namespace c5m._2d6Dungeon.web.Domain;

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

        await js.InvokeVoidAsync("DrawRoom", gidX, gidY, currentRoom.Width, currentRoom.Height, currentRoom.YouAreHere);

        await DrawDoors(js, currentRoom);
    }

    public static async Task DrawDoors(IJSRuntime js, MappedRoom currentRoom)
    {
        foreach (var door in currentRoom.Exits!)
        {
            string orientation = GetDoorOrientation(door.Key);
            int x = 0;
            int y = 0;
            bool isMain = false;

            switch (door.Key)
            {
                case Direction.North:
                    x = currentRoom.CoordX + door.Value.PositionOnWall;
                    y = currentRoom.CoordY;
                    break;
                case Direction.East:
                    x = currentRoom.CoordX + currentRoom.Width;
                    y = currentRoom.CoordY + door.Value.PositionOnWall;
                    break;
                case Direction.South:
                    x = currentRoom.CoordX + door.Value.PositionOnWall;
                    y = currentRoom.CoordY + currentRoom.Height;
                    isMain = currentRoom.IsLobby;
                    break;
                case Direction.West:
                    x = currentRoom.CoordX;
                    y = currentRoom.CoordY + door.Value.PositionOnWall;
                    break;
            }

            await js.InvokeVoidAsync("DrawDoor", x, y, orientation, isMain);
        }


    }

    private static string GetDoorOrientation(Direction onWall)
    {
        if (onWall == Direction.South || onWall == Direction.North)
        {
            return "H";
        }
        return "V";
    }

}
