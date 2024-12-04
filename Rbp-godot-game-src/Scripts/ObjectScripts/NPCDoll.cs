
using System.Collections.Generic;
using Godot;

public partial class NPCDoll : CharacterBody2D
{
	[Export] public Area2D FloorDetec;
             public List<string> FloorProertys;
    public string ID;


	public override void _Process(double delta)
    {
        FloorProertys = GetFloorProerties(FloorDetec.GetOverlappingAreas());
    }

    public List<string> GetFloorProerties(Godot.Collections.Array<Area2D> inAreas)
    {
        List<string> output = new();
        foreach(Area2D floor in inAreas)
        {
            if(floor.HasMeta(new("prop")))
            {
                output.Add((string)floor.GetMeta("prop"));
            }
        }
        return output;
    }
}