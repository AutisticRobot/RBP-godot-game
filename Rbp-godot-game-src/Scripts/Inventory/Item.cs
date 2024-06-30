using Godot;
using System;
using System.Globalization;

[GlobalClass]
public partial class Item : Resource
{
    [Export] public int ID;
    [Export] public int count;
    // for adding a icon/texture, use a (not yet made) get texture script to grab a texture from the textures folder.

    public Item()
    {
    }
    public Item(int ID, int count)
    {
        this.ID = ID;
        this.count = count;
    }

    public string GetName()
    {
        return GetName(ID);
    }

    static public string GetName(int ID)
    {
        return ID switch
        {
            0 => "money",
            1 => "food",
            2 => "rum",
            3 => "spice",
            4 => "fabric",
            5 => "jewlery",
            _ => null,
        };
    }

    static public implicit operator string(Item item)
    {
        return "(" + item.ID + "," + item.count + ")";
    }
    static public explicit operator Item(string inString)
    {
        //GD.Print("string to irem: " + inString);
        string outstr = inString.Substr(1,inString.Length-2);

        int midPointIndex = outstr.Find(",");

        int outID    = outstr.Left(midPointIndex).ToInt();
        int outCount = outstr.Right(midPointIndex+1).ToInt();

        return new(outID, outCount);
        
    }
}
