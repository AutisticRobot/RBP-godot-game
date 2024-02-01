using Godot;
using Godot.Collections;
using System;
using System.Data.SqlTypes;

public partial class inventory : Node
{
	[Export]
	public Godot.Collections.Dictionary<string, int> inv = new()
    {
		{"Money", 0},
		{"Food", 0},
		{"Rum", 0},
		{"Linens", 0},
		{"Spices", 0},
		{"Jewlery", 0},
	};

    
}
