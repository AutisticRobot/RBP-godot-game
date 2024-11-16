using Godot;
using Godot.Collections;
using System;

public partial class PlayerShip : Node2D// : Ship
{
	[Export] public Cursor cursor;
	[Export] public string playerID;
			 public Ship ship;
			 public Sprite2D shipSprite;
			 public double time;//for wobble amt
	[Export] public double widthScale;//for wobble amt
	[Export] public double speedScale;//for wobble amt

	[Export] public bool debug;
			 public SceneMan manager;
			 public Global global; 

	[Export] public string ShipModelID;


    public override void _Process(double delta)
    {
		GlobalPosition = ship.GlobalPosition;

		time += delta * speedScale * ship.sailState;
		shipSprite.RotationDegrees = (float)getShakeAmt(time,widthScale);
		//input.update(delta);
    }
	
	public void preLoad(SceneMan man)
	{
		manager = man;
		global = manager.global;


		ship = LoadShipModel(ShipModelID);
		ship.ID = playerID;

		ship.input = new PlayerShipInput1();

		ship.input.start();
		ship.input.setShip(ship);
		((PlayerShipInput1)ship.input).cursor = cursor;

		ship.save = new playerShipSave(this, playerID);
		ship.save.LoadIntoSaveMan(global.PlayerSaveMan);

		ship.Reparent(man);
		this.Reparent(ship);
		shipSprite = ship.GetChild<Sprite2D>(0);

	}
	
	public Ship LoadShipModel(string ShipID)
	{
		string ShipPath = global.almanac.ShipDir[ShipModelID];

		Ship ShipModel = (Ship)ResourceLoader.Load<PackedScene>(ShipPath).Instantiate();

		//data = (shipModelData)ShipModel.Call(new StringName("getData"));

		//ShipModel.QueueFree();
		ShipModel.Position = new(0,0);

		ShipModel.preLoad(manager);

		AddChild(ShipModel);
		return ShipModel;
		/*
		foreach(Node node in ShipModel.GetChildren())
		{
			ShipModel.RemoveChild(node);
			AddChild(node);

			//node.Reparent(this);
		}
		*/
	}

	public double getShakeAmt(double time, double scale)
	{
		return Math.Sin(time) * scale;
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
