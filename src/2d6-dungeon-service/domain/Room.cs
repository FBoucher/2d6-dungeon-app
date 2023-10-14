namespace c5m._2d6Dungeon;

public class Room
{
        public int id { get; set; }
        public int roll { get; set; }
        public string exits { get; set; } = string.Empty;
        public int level { get; set; }
        public string room_type { get; set; } = string.Empty;
        public bool is_unique { get; set; }
        public string encounter { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
}

public class RoomList{
    public List<Room> value { get; set; } = new List<Room>();
}
