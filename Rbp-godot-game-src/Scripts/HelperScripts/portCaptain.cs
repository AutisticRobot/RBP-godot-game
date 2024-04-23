using Godot;
using System;
using System.Collections.Generic;

public partial class portCaptain : Control
{
    public List<DockSpot> allDocks;
	public override void _Ready()
	{
        Visible = false;

        foreach(Node child in GetChildren())
        {
            if(child.GetType().ToString() == "DockSpot")
            {
                allDocks.Add((DockSpot)child);
            }
        }
	}

    public DockSpot getRandDock()
    {
        int length = allDocks.Count;

        if(length > 0)
        {
            return allDocks[length];
        }
        return null;
    }
}
