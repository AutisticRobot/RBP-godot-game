using Godot;
using System;

[GlobalClass]
public partial class priceModulator : Node
{
    [Export] public shopObject parShop;
    [Export] public uint dayLastUpdate;
    [Export] public uint DebugCurDay;
                 public uint daysSenceUpdate;


    public override void _Ready()
    {
        GD.Print("modPrice Preped");

        //some basic testing code
        daysSenceUpdate = DebugCurDay - dayLastUpdate;
    }

    public void simpleMod()
    {
        parShop.inv.sell.Food += (int)daysSenceUpdate;
        GD.Print("food Price:" + parShop.inv.sell.Food);
    }

}
