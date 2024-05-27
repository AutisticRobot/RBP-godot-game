using Godot;
using Godot.Collections;
using System;
using System.Collections;
using System.Collections.Generic;

[GlobalClass]
public partial class inventory : Resource, IEnumerable
{
	[Export] public List<Item> Items;

	public Item this[int i]
	{
		get
		{
			return Items[i];
		}
		set
		{
			Items[i] = value;
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
 