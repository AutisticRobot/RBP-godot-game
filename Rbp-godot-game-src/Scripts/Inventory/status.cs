
using System.Collections.Generic;
using Godot;

public partial class status : Resource
{
    [Export] public List<string> effects;

    [Export] public int health;
    [Export] public float AccModPer;

    public void evalEff()
    {
        
    }
}