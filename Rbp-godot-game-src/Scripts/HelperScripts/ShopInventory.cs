using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class ShopInventory : Resource
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
	[Export]
	public Godot.Collections.Dictionary<string, int> sell = new()
    {
		{"Money", 0},
		{"Food", 0},
		{"Rum", 0},
		{"Linens", 0},
		{"Spices", 0},
		{"Jewlery", 0},
	};
	[Export]
	public Godot.Collections.Dictionary<string, int> buy = new()
    {
		{"Money", 0},
		{"Food", 0},
		{"Rum", 0},
		{"Linens", 0},
		{"Spices", 0},
		{"Jewlery", 0},
	};


}
