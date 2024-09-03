using Godot;
using Godot.Collections;
using System;

public partial class Ship : CharacterBody2D
{
			 public SceneMan manager;
			 private Global global; 

	[Export] public inventory inv;
	[Export] public SceneSave save;
		public Dictionary saveData;

	[Export] public shipModelData data;
	[Export] public shipInput input;

    [Export] public Vector2 cannonOffset;
			 public float dir;
    private object gunState;


    public override void _Ready()
    {
		global = GetNode<Global>("/root/Global");
		input.ship = this;
    }
    public override void _Process(double delta)
    {
		input.update();
    }
    public override void _PhysicsProcess(double delta)
	{
	}


	public void FireCannons(cannonData cannon)
	{
		GD.Print("shot dir: " + dir);

		string ShotPath = ResourceUid.GetIdPath(ResourceUid.TextToId(cannon.cannonBallUUID));

		CannonBall shot = (CannonBall)ResourceLoader.Load<PackedScene>(ShotPath).Instantiate();

		shot.Specs = (MunitionRes)cannon.ammoData.Duplicate(true);
		shot.Dir = dir;
		shot.Speed = cannon.ammoSpeed;

		Vector2 offset = getCannonOffset(dir);

		shot.Position = new()
        {
            X = (float)Math.Sin(dir * (Math.PI / 180)) + Position.X + offset.X,
            Y = (float)Math.Cos(dir * (Math.PI / 180)) + Position.Y + offset.Y 
        };

		GetParent().AddChild(shot);
		gunState = data.gunCooldown;

	}

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
	public void getLoot(Area2D LBB)
	{

		if(LBB.Name == "Loot")
		{
		LootFloat loot = LBB.GetParent<LootFloat>();

		loot.inv.flushInItems();

		inv += loot.inv;
		GD.Print(inv.Count);
		GD.Print(loot.inv.Count);


		loot.QueueFree();
		}
	}

}
