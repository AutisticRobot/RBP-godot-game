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
			return i switch
			{
				0 => Money,
				1 =>Food,
				2 =>Rum,
				3 =>Linens,
				4 =>Spices,
				5 =>Jewlery,
				_ => 0
			};
		}
		set
		{
			switch(i)
			{
                case 0:
					Money = value;
				break;

                case 1:
					Food = value;
				break;

                case 2:
					Rum = value;
				break;

                case 3:
					Linens = value;
				break;

                case 4:
					Spices = value;
				break;

                case 5:
					Jewlery = value;
				break;
				
				default:
				break;
			}
		}
	}
}
 