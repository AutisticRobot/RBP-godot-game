using Godot;
using Godot.Collections;
using System;
using System.Collections;
using System.Collections.Generic;

[GlobalClass]
public partial class inventory : Resource, IEnumerable
{
	[Export] public Item[] Items;

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

    public IEnumerator GetEnumerator()
    {
		return new ItemEnum(Items);
    }
}


 