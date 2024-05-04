using Godot;
using System;
using System.Collections.Generic;

public partial class portCaptain : Control
{
    public List<DockSpot> allDocks;
	public override void _Ready()
	{
        allDocks = new();
        allDocks.EnsureCapacity(4);
        Visible = false;

        foreach(Node child in GetChildren())
        {
            GD.Print(child.GetClass());
            if(child.GetType().ToString() == "DockSpot")
            {
                allDocks.Add((DockSpot)GetChild(child.GetIndex()));
            }
        }
	}

    public DockSpot getRandDock()
    {
        int length = allDocks.Count;

        if(length > 0)
        {
        
            GD.Print("Dock found");
            uint randSpot = GD.Randi() % (uint)length;
            GD.Print("Dosck Spot: " + (int)randSpot);
            return (DockSpot)allDocks[(int)randSpot];
        }
        GD.Print("No Docks?");
        return null;
    }
}
