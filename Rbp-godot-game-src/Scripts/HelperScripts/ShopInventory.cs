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
