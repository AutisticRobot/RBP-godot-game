using Godot;
using System;

[GlobalClass]
public partial class ShopItem : Item
{
    [Export] public int buyPrice;
    [Export] public int SellPrice;
    public ShopItem()
    {
    }
    public ShopItem(int ID, int count, int buy, int sell)
    {
        this.ID = ID;
        this.count = count;
        buyPrice = buy;
        SellPrice = sell;
    }

    static public implicit operator string(ShopItem item)
    {
        return "(" + item.ID + "," + item.count + "," + item.buyPrice + "," + item.SellPrice + ")";
    }
    static public explicit operator ShopItem(string inString)
    {
        //GD.Print("string to irem: " + inString);
        string outstr = inString.Substr(1,inString.Length-2);
        string[] dataArr = outstr.Split(",");


        return new(dataArr[0].ToInt(),dataArr[1].ToInt(),dataArr[2].ToInt(),dataArr[3].ToInt());
        
    }
}
