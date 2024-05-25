using Godot;
using Godot.Collections;
using System;
using System.Collections;

[GlobalClass]
public partial class inventory : Resource, IEnumerable
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
	public int this[string i]
	{
		get
		{
			i = i.ToLower();
			return i switch
			{
				"money" => Money,
				"food" =>Food,
				"rum" =>Rum,
				"linens" =>Linens,
				"spices" =>Spices,
				"jewlery" =>Jewlery,
				_ => 0
			};
		}
		set
		{
			i = i.ToLower();
			switch(i)
			{
                case "money":
					Money = value;
				break;

                case "food":
					Food = value;
				break;

                case "rum":
					Rum = value;
				break;

                case "linens":
					Linens = value;
				break;

                case "spices":
					Spices = value;
				break;

                case "jewlery":
					Jewlery = value;
				break;
				
				default:
				break;
			}
		}
	}

	public Dictionary ToDic()
	{
		Dictionary tmp = new();
		tmp.Add(0,Money);
		tmp.Add(1,Food);
		tmp.Add(2,Rum);
		tmp.Add(3,Linens);
		tmp.Add(4,Spices);
		tmp.Add(5,Jewlery);

		return tmp;
	}

	public void FromDic(Dictionary inDic)
	{

		foreach(var i in inDic)
		{
			this[(int)i.Key] = (int)i.Value;
		}

	}
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
 