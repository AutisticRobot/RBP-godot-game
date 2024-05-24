using Godot;
using Godot.Collections;
using System;

public partial class PlayerShip : Node2D
{
			 public SceneMan manager;
	[Export] public Cursor cursor;

	[Export] public bool player;
	[Export] public bool debug;

	[Export] public float brakeSpeed;
	[Export] public float Acc;
	[Export] public float TurnAcc;
			 public float speed;
	[Export] public float Minspeed;
	[Export] public float Maxspeed;
	[Export] public float dir;//in Dagrees

	[Export] public inventory inv;
	[Export] public SceneSave save;
		public Dictionary data;


	private Global global; 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		manager = GetOwner<SceneMan>();
		if(player)
		{
			global = GetNode<Global>("/root/Global");
		
			if(global.playerDataFilled == true)
			{
				dir = global.ShipDir;
				Position = global.ShipPos;
				inv = global.playerHull;
				GD.Print("get Inv Global" + inv.Money);

			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(!manager.pausedScene)
		{
			Pinput();
        	Vector2 vel = new()
        	{
        	    X = ((float)(Math.Sin(dir * (Math.PI / 180)) * speed * delta)),
        	    Y = ((float)(Math.Cos(dir * (Math.PI / 180)) * speed * delta))
        	};
        	Position += vel;
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
	{
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
	}

	public void getLoot(Area2D LBB)
	{
		if(LBB.Name == "Loot")
		{
		LootFloat loot = LBB.GetParent<LootFloat>();

		inv["Money"]   += loot.inv["Money"];
		inv["Food"]    += loot.inv["Food"];
		inv["Rum"]     += loot.inv["Rum"];
		inv["Linens"]  += loot.inv["Linens"];
		inv["Spices"]  += loot.inv["Spices"];
		inv["Jewlery"] += loot.inv["Jewlery"];
		loot.QueueFree();
		}
	}

	public void MoveTowardCursor()
	{
		Vector2 relTar = (cursor.Position - Position);//.Normalized();

		dir = (float)(Math.Atan2(relTar.X, relTar.Y) * (180/Math.PI));

	}

}
