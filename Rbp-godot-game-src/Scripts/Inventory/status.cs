
using System.Collections.Generic;
using Godot;

[GlobalClass]
public partial class status : Resource
{
             public List<string> effects;

    [Export] public int health;
    [Export] public float AccModPer;

    public void evalEff()
    {
        
    }
}