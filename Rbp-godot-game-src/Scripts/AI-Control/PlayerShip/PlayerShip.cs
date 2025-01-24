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

	[Export] public bool debug = true;
	[Export] public bool playerDed = false;
			 public SceneMan manager;
			 public Global global; 

	[Export] public string ShipModelID;
			 public Vector2 curRespawnPoint;
	[Export] public RespawnPoint EditorSpawnPoint;
	[Export] public RespawnPoint DefaultSpawnPoint;


    public override void _PhysicsProcess(double delta)
    {
		if(!playerDed)
		{
			GlobalPosition = ship.GlobalPosition;

			time += delta * speedScale * ship.sailState;
			shipSprite.RotationDegrees = (float)GetShakeAmt(time,widthScale);
			//input.update(delta);
		}
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

		ship.ShipDeath += PlayerDies;
		
		if(debug){debugLoad();}
	}
	public void debugLoad()
	{
		SetSpawn(EditorSpawnPoint);
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

	public double GetShakeAmt(double time, double scale)
	{
		return Math.Sin(time) * scale;
	}

	public void PlayerDies()
	{
		playerDed = true;
	}

	public void SetSpawn(RespawnPoint RP){SetSpawn(RP.Position);}
	public void SetSpawn(Vector2 RP)
	{
		curRespawnPoint = RP;
	}

	public void Respawn()
	{
		try{
			Position = curRespawnPoint;
		}catch{
			Position = DefaultSpawnPoint.Position;
		}
		playerDed = false;
	}

}
