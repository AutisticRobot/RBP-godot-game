using Godot;
using System;

[GlobalClass]
public partial class shipModelData : Resource
{
    [Export] public Texture2D icoSprite;
	[Export] public float brakeSpeed;
	[Export] public float Acc;
	[Export] public float TurnAcc;
	[Export] public float Minspeed;
	[Export] public float Maxspeed;
    [Export] public int maxHealth;
    [Export] public int maxWeight;
    [Export] public int maxVolume;
    [Export] public inventory LoadWeight;
    [Export] public inventory LoadVolume;
}