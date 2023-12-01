﻿using System.Text.Json.Serialization;

namespace c5m._2d6Dungeon;

public class MagicScroll
{
    public int Id { get; set; }

    [JsonPropertyName("scroll_type")]
    public string ScrollType { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
    public string Orbit { get; set; }

    [JsonPropertyName("dispel_doubles")]
    public string DispelDoubles { get; set; }
    public string Cost { get; set; }
    public string Fail { get; set; }
    public string Modifier { get; set; }
}
