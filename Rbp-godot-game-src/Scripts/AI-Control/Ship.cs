using Godot;
using System;

public partial class Ship : CharacterBody2D
{

	[Export] public shipModelData data;
	[Export] public shipInput input;

			 public float dir;
    private object gunState;

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

		Vector2 offset = data.getCannonOffset(dir);

		shot.Position = new()
        {
            X = (float)Math.Sin(dir * (Math.PI / 180)) + Position.X + offset.X,
            Y = (float)Math.Cos(dir * (Math.PI / 180)) + Position.Y + offset.Y 
        };

		GetParent().AddChild(shot);
		gunState = data.gunCooldown;

	}


	public void LoadShipModel()
	{
		Node model = ShipModel.Instantiate();
		AddChild(model);
		foreach(Node node in model.GetChildren())
		{
			node.Owner = this;
			node.Reparent(this);
		}
		model.QueueFree();
	}


}
