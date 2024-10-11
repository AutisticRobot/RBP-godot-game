using Godot;
using Godot.Collections;
using System;

public partial class PlayerShip : Ship
{
	[Export] public Cursor cursor;
	[Export] public string playerID;

	[Export] public bool debug;

	[Export] public string ShipModelID;
			 public PackedScene ShipModel;
			 public new PlayerShipInput1 input = new();


    public override void _Ready()
    {
    }
    public override void _Process(double delta)
    {
		input.update(delta);
    }
	public override void preLoad()
	{
		save = new playerShipSave(this, playerID);
		global = GetNode<Global>("/root/Global");
		save.LoadIntoSaveMan(global.PlayerSaveMan);
		ShipModel = ResourceLoader.Load<PackedScene>(global.almanac.ShipDir[ShipModelID]);

		input.start();
		input.setShip(this);
		input.cursor = cursor;
		
	}
	/*===========OLD SCRIPT FOR REFERENCE==============
	[Export] public float brakeSpeed;
	[Export] public float Acc;
	[Export] public float TurnAcc;
			 public float speed;
	[Export] public float Minspeed;
	[Export] public float Maxspeed;
	[Export] public float dir;//in Dagrees

	[Export] public MunitionRes ammoData;
	[Export] public float ammoSpeed;
	[Export] public string cannonBallUUID;
	[Export] public float gunCooldown;
	[Export] public float gunState;
	[Export] public Vector2 cannonOffset;

	[Export] public inventory inv;
	[Export] public SceneSave save;
		public Dictionary data;


	private Global global; 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		manager = GetOwner<SceneMan>();

		LoadShipModel();

		//inv ??= new();

		if(player)
		{
			global = GetNode<Global>("/root/Global");
		
			if(global.playerDataFilled == true)
			{
				dir = global.ShipDir;
				Position = global.ShipPos;
				inv = global.playerHull;
				GD.Print("get Inv Global");
		

			}
		}


	}

	// Called every frame. 'delta' is the elapsed time sinc
e the previous frame.
	public override void _Process(double delta)
	{
		//inv ??= new();
		if(!manager.pausedScene)
		{
			Pinput();
        	Vector2 vel = new()
        	{
        	    X = (float)(Math.Sin(dir * (Math.PI / 180)) * speed * delta),
        	    Y = (float)(Math.Cos(dir * (Math.PI / 180)) * speed * delta)
        	};
			//GD.Print(speed);
			Velocity = vel;
			MoveAndSlide();
			gunState -= (float)delta;
		}
		if(player)
		{
			Save();//this should use signals for the sake of expanability and performance; because saving every frame is bad
		}
		global.playerHull = inv;//this should use signals for the sake of expanability and performance; same reason here
			
	}

	public void Save()
	{
		global.ShipDir = dir;
		global.ShipPos = Position;
		global.playerDataFilled = true;

	}

	private void Pinput()
	{/*
		if(Input.IsActionPressed("Accelerate"))
		{
			speed += Acc;
		}
		if(Input.IsActionPressed("Reverse"))
		{
			speed -= Acc;
		}
		if(Input.IsActionPressed("Tccw"))
		{
			dir += TurnAcc;
		}
		if(Input.IsActionPressed("Tcw"))
		{
			dir -= TurnAcc;
		}
		if(Input.IsActionPressed("Brake"))
		{
			if(-brakeSpeed <= speed && speed <= brakeSpeed){speed = 0;}//set speed to 0 when braking at low speeds
			if(speed > 0){speed -= brakeSpeed;}//brake when reversing
			if(speed < 0){speed += brakeSpeed;}//brake when going forwoard
			
		}
		if(Input.IsActionPressed("L-click"))
		{
			MoveTowardCursor();
		}
		speed = Math.Clamp(speed, Minspeed, Maxspeed);
		if(Input.IsActionJustPressed("Shoot"))
		{
			if(gunState <= 0)//cooldown check
			{
				//FireCannons();
			}
		}
	}


	public void MoveTowardCursor()
	{
		Vector2 relTar = (cursor.Position - Position);//.Normalized();

		dir = (float)(Math.Atan2(relTar.X, relTar.Y) * (180/Math.PI));

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



*/
}
