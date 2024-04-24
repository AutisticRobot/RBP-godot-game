using Godot;
using System;
using System.Collections.Generic;

public partial class portCaptain : Control
{
    public List<Node> allDocks;
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
                allDocks.Add(GetChild(child.GetIndex()));
            }
        }
	}

    public DockSpot getRandDock()
    {
        int length = allDocks.Count;

        if(length > 0)
        {
        
            GD.Print("Dock found");
            return (DockSpot)allDocks[length -1];
        }
        GD.Print("No Docks?");
        return null;
    }
}
