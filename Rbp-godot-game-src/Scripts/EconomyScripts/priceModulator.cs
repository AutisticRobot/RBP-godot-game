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
        foreach(ShopItem item in shop)
        {
            GD.Print("inv of " + item.GetName() + " (" + item.ID + ") = " + item.count);
            float varriayPercentage = (GD.Randf() % .1f) - .05f;
            GD.Print("varriation percentage: " + varriayPercentage);
            item.count = (int)((float)item.count * (1 + varriayPercentage));
        }


        return shop;
    }

}
