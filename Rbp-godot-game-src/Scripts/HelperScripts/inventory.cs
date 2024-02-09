using Godot;
using Godot.Collections;
using System;
using System.Data.SqlTypes;

[GlobalClass]
public partial class inventory : Resource
{
	#region RESOURCES
	[Export] public int Money;
	[Export] public int Food;
	[Export] public int Rum;
	[Export] public int Linens;
	[Export] public int Spices;
	[Export] public int Jewlery;
	#endregion

	public int this[int i]
	{
		get
		{
			return 0;
		}
		set
		{
			
		}
	}
}
 