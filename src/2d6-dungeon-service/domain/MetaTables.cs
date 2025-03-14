using System;

namespace c5m._2d6Dungeon.domain;

public class MetaTables
{
	public int Id { get; set; }
	public string Code { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string Columns_name { get; set; } = string.Empty;
	public string Columns_label { get; set; } = string.Empty;
}

public class MetaTablesList
{
    public List<MetaTables> Value { get; set; } = new List<MetaTables>();
}

