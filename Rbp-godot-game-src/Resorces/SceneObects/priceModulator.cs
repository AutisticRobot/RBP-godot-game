using Godot;
using System;

[GlobalClass]
public partial class priceModulator : Resource
{
             public shopObject parShop;
    [Export] public uint dayLastUpdate;
                 public uint daysSenceUpdate;


    public void prep(shopObject shop)
    {
        parShop = shop;
    }

}
