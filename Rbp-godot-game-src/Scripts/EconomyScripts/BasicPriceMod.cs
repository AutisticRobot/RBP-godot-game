using Godot;
using System;

[GlobalClass]
public partial class BasicPriceMod : ShopModRes
{


    public override void Prep()
    {
        GD.Print("modPrice Preped");

        //some basic testing code
        daysSenceUpdate = DebugCurDay - dayLastUpdate;
    }

    public override ShopInventory Mod(ShopInventory shop)
    {
        foreach(ShopItem item in shop)
        {
            GD.Print("inv of " + item.GetName() + " (" + item.ID + ") = " + item.count);
            float varriayPercentage = (GD.Randf() % .1f) - .05f;
            GD.Print("varriation percentage: " + varriayPercentage);

            item.count = (int)((float)item.count * (1 + varriayPercentage));

            varriayPercentage = (GD.Randf() % .5f) - .25f;

            item.SellPrice += (int)(10 * varriayPercentage);  
            if(item.SellPrice <= 0){item.SellPrice = 0;}

            varriayPercentage = GD.Randf() % .25f;

            item.buyPrice = (int)(item.SellPrice * (1 + varriayPercentage));
        }


        return shop;
    }

}
