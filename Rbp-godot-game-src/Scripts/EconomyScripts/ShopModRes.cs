using Godot;
using System;

[GlobalClass]
public partial class ShopModRes : Resource
{
    [Export] public uint dayLastUpdate;
    [Export] public uint DebugCurDay;
                 public uint daysSenceUpdate;

    public virtual void Prep()
    {}
    
    public virtual ShopInventory Mod(ShopInventory inShop)
    {
        return (ShopInventory)inShop.Duplicate(true);
    }
}
