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
}
