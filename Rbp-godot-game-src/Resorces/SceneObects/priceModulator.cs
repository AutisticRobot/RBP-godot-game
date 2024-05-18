using Godot;
using System;

[GlobalClass]
public partial class priceModulator : Node
{
    [Export] public uint dayLastUpdate;
    [Export] public uint DebugCurDay;
                 public uint daysSenceUpdate;


    public override void _Ready()
    {
        GD.Print("modPrice Preped");

        //some basic testing code
        daysSenceUpdate = DebugCurDay - dayLastUpdate;
    }

    public ShopInventory simpleMod(ShopInventory shop)
    {
        shop.sell.Food += (int)daysSenceUpdate;
        GD.Print("food Price:" + shop.sell.Food);


        return shop;
    }

}
