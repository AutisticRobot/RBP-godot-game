using Godot;
using Godot.Collections;
using System;
using System.Data.SqlTypes;

public partial class inventory : Node
{
	[Export]
	public int Money;
	[Export]
	public int Food;
	[Export]
	public int Rum;
	[Export]
	public int Linens;
	[Export]
	public int Spices;
	[Export]
	public int Jewlery;

    [Export]
    public Godot.Collections.Dictionary<string, int> HeldResources = new(){
        ["Money"] = 0,
    };

    
}
