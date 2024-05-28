using Godot;
using Godot.Collections;
using System;
using System.Collections;

[GlobalClass]
public partial class ShopInventory : Resource, IEnumerable
{	
	[Export] public ShopItem[] Items;

	public ShopItem this[int i]
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
		return new ShopItemEnum(Items);
    }


}
