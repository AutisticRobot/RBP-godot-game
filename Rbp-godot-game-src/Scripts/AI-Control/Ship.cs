using Godot;
using Godot.Collections;
using System;

public partial class Ship : CharacterBody2D
{
			 public SceneMan manager;
			 public Global global; 
    [Export] public string ID;

	[Export] public shipModelData data;
			 public ShipSave save;
			 public shipInput input;

	[Export] public string ShipModelID;
	[Export] public inventory inv;
			 public float dir;
    		 public float gunState;
			 public float sailState;
			 public float speed;


    public override void _Ready()
    {
    }
    public override void _Process(double delta)
    {
		input.update(delta);
    }
    public override void _PhysicsProcess(double delta)
	{
		if(!manager.pausedScene)
		{
			TurnShip(input.getTurnDir(), delta);
			CommandSail(input.getSailCom(), delta);

			Velocity = calcVel(delta);
			MoveAndSlide();

			speed = GetPositionDelta().Length() * 3600;

		}
	}

	public virtual void preLoad(SceneMan man)
	{
		manager = man;
		global = manager.global;
/*
		save = new(this);

		input.start();
		input.setShip(this);
		*/
	}

	public Vector2 calcVel(double delta)
	{
		if(input.getAncorState())
		{
			speed *= 0.95f;
			//return new Vector2(0,0);
		}

		speed += sailState * data.Acc;//<=======================TODO: ADD WIND/CURRENT CLAC HERE
		speed = Math.Clamp(speed, data.Minspeed, data.Maxspeed);


		Vector2 vel = new()
        	{
        	    X = (float)(Math.Sin(dir * (Math.PI / 180)) * speed * delta),
        	    Y = (float)(Math.Cos(dir * (Math.PI / 180)) * speed * delta)
        	};



		return vel;
	}

	public void TurnShip(float turnStrength, double delta)
	{
		dir += Math.Clamp(turnStrength, -1, 1) * data.TurnAcc * (float)delta;
		dir = (dir + 360) % 360;
	}
	public void CommandSail(float sailTarget, double delta)
	{
		sailState += sailTarget * (float)delta * data.SailAcc;
		sailState = Math.Clamp(sailState, 0, 1);
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
			X = data.cannonOffset.X,
			Y = data.cannonOffset.Y
		};
		}else
		{
		return new() 
		{
			X = -data.cannonOffset.X,
			Y = -data.cannonOffset.Y
		};
		}
	}
	public void pickUpEntered(Area2D area)
	{
		GD.Print(area.Name);
		if(area.Name == "Loot")
		{
			getLoot(area.GetParent<LootFloat>());
		}

	}
	public void getLoot(LootFloat loot)
	{
		loot.inv.flushInItems();

		inv += loot.inv;
		GD.Print(inv.Count);
		GD.Print(loot.inv.Count);


		loot.QueueFree();
	}

	public shipModelData getData()
	{
		return data;
	}

}
