
using Godot;

public partial class NPCDoll : CharacterBody2D
{
	[Export] public Area2D FloorDetec;
             public string[] FloorProertys;
    public string ID;


	public override void _Process(double delta)
    {
        FloorProertys = GetFloorProerties(FloorDetec.GetOverlappingAreas());
    }

    public string[] GetFloorProerties(Godot.Collections.Array<Area2D> inAreas)
    {
        return null;
    }
}