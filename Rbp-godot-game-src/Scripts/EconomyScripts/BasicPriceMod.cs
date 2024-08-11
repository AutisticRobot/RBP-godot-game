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

    public override ShopInventory Mod(ShopInventory inShop)
    {
        ShopInventory shop = new();
        
        for(int i=0;i<inShop.Count;i++)
        {
            ShopItem item = (ShopItem)inShop.ElementAt(i);
            ShopItem outItem = new()
            {
                ID = item.ID
            };

            GD.Print("inv of " + item.GetName() + " (" + item.ID + ") = " + item.count);
            float varriayPercentage = (GD.Randf() % .1f) - .05f;
            GD.Print("varriation percentage: " + varriayPercentage);

            outItem.count = (int)(item.count * (1 + varriayPercentage));

            varriayPercentage = (GD.Randf() % .5f) - .25f;

            outItem.SellPrice = item.SellPrice + (int)(10 * varriayPercentage);  
            if(outItem.SellPrice <= 0){outItem.SellPrice = 0;}

            varriayPercentage = GD.Randf() % .25f;

            outItem.buyPrice = (int)(item.SellPrice * (1 + varriayPercentage));

            if(outItem.buyPrice <= outItem.SellPrice)
            {
                outItem.buyPrice = outItem.SellPrice + 1;
            }

            shop.add(outItem);
        }


        return shop;
    }
}
