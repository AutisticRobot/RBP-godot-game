using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class ShopInventory : Resource
{	
	[Export] public inventory inv  = new();
	[Export] public inventory sell = new();
	[Export] public inventory buy  = new();


	public Dictionary ToDic()
	{
		Dictionary data = new();

		data["inv"] = inv.ToDic();
		data["sell"] = sell.ToDic();
		data["buy"] = buy.ToDic();

		return data;
	}
	public void FromDic(Dictionary inDic)
	{
		inv.FromDic((Dictionary)inDic["inv"]);
		sell.FromDic((Dictionary)inDic["sell"]);
		buy.FromDic((Dictionary)inDic["buy"]);
	}

}
