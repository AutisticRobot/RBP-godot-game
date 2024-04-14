using Godot;
using Godot.Collections;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;

public partial class PlayerShip : Node2D
{
	[Export] public bool player;
	[Export] public bool debug;

	[Export] public float brakeSpeed;
	[Export] public float Acc;
	[Export] public float TurnAcc;
	[Export] public float speed;
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
		dir = -dir + 180;
		if(player)
		{
			global = GetNode<Global>("/root/Global");
			dir = global.ShipDir;
			Position = global.ShipPos;
		}
		if(global.playerHull != null)
		{
			inv = global.playerHull;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Pinput();
        Vector2 vel = new()
        {
            X = ((float)(Math.Sin(dir * (Math.PI / 180)) * speed * delta)),
            Y = ((float)(Math.Cos(dir * (Math.PI / 180)) * speed * delta))
        };
        Position += vel;
		if(player)
		{
			Save();
		}
		global.playerHull = inv;//this should use signals for the sake of expanability and performance;
	}

	public void Save()
	{
		global.ShipDir = dir;
		global.ShipPos = Position;

	}

	private void Pinput()
	{
		if(Input.IsActionPressed("ui_up"))
		{
			speed += Acc;
		}
		if(Input.IsActionPressed("ui_down"))
		{
			speed -= Acc;
		}
		if(Input.IsActionPressed("ui_left"))
		{
			dir += TurnAcc;
		}
		if(Input.IsActionPressed("ui_right"))
		{
			dir -= TurnAcc;
		}
		if(Input.IsActionPressed("Brake"))
		{
			if(-brakeSpeed <= speed && speed <= brakeSpeed){speed = 0;}//set speed to 0 when braking at low speeds
			if(speed > 0){speed -= brakeSpeed;}//brake when reversing
			if(speed < 0){speed += brakeSpeed;}//brake when going forwoard
			
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

}
