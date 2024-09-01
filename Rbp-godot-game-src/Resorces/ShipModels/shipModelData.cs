using Godot;
using System;

[GlobalClass]
public partial class shipModelData : Resource
{
    [Export] public Texture2D icoSprite;
    [Export] public float spriteScale;
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
    [Export] public float gunCooldown;

    [Export] public Vector2 cannonOffset;


	public Vector2 getCannonOffset(float dir)
	{
		if(dir >= 0)
		{
		return new() 
		{
			X = cannonOffset.X,
			Y = cannonOffset.Y
		};
		}else
		{
		return new() 
		{
			X = -cannonOffset.X,
			Y = -cannonOffset.Y
		};
		}
	}
}
