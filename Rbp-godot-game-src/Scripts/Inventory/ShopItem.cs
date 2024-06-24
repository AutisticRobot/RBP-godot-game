using Godot;
using System;

public partial class ShopItem : Item
{
    [Export] public int buyPrice;
    [Export] public int SellPrice;
    public ShopItem()
    {
    }
    public ShopItem(int ID, int count)
    {
        this.ID = ID;
        this.count = count;
    }
}
