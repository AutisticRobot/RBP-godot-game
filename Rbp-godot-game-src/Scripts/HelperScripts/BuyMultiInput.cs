using Godot;
using System;

public partial class BuyMultiInput : LineEdit
{
	[Export] public ShopMenu shop;
	[Export] public Label CurrentCountDisplay;
	[Export] public string dipPrefix;
	[Export] public string dipAffix;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void onTextEnter(string inString)
	{
		int buyMulti = inString.ToInt();

		CurrentCountDisplay.Text = dipPrefix + buyMulti.ToString() + dipAffix;

		shop.buyMulti = buyMulti;

	}
}
