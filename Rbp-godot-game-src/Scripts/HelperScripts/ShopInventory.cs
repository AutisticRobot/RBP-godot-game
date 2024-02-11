using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class ShopInventory : Resource
{	
	[Export] public inventory inv;
	[Export] public inventory sell;
	[Export] public inventory buy;


}
