using Godot;
using System;

public partial class basicHud : Control
{

	[Export] public PlayerShip ship;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(ship.ship.inv != null)
		{
			itterateOverInv(ship.ship.inv);
		}
	}

	private void itterateOverInv(inventory inv)
	{
		int i = -1;
		foreach(Item item in inv)
		{
			i++;
			setLabelCont(i, item.GetName(), item.count);
		}

	}

	private void setLabelCont(int index, string res, int cnt)
	{
		GetChild<Label>(index).Text = res + ": " + cnt;
	}
}
