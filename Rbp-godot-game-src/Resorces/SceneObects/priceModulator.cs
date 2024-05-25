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
        //some code before i figure out enumerables
        for(int i=0;i<=5;i++)
        {
            GD.Print("inv " + i + " = " + shop.inv[i]);
        }


        return shop;
    }

}
