using System;

namespace c5m._2d6Dungeon.domain;

public class Table2D6
{
	public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public int TableId { get; set; }
    public string[]? Headers { get; set; }
    public List<string[]>? Rows { get; set; }
}
