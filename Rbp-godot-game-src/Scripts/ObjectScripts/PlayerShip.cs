using Godot;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;

public partial class PlayerShip : Sprite2D
{
	[Export]
	public bool player;
	[Export]
	public bool debug;

	[Export]
	public float brakeSpeed;
	[Export]
	public float Acc;
	[Export]
	public float TurnAcc;
	[Export]
	public float speed;
	[Export]
	public float Minspeed;
	[Export]
	public float Maxspeed;
	[Export]
	public float dir;//in Dagrees

	[Export]
	public inventory inv;


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
			if(-brakeSpeed <= speed && speed <= brakeSpeed){speed = 0;}
			if(speed < 0){brakeSpeed = -brakeSpeed;}
			if(speed == 0){speed += brakeSpeed;}
			speed -= brakeSpeed;
			
		}
		speed = Math.Clamp(speed, Minspeed, Maxspeed);
	}

	public void getLoot(Area2D LBB)
	{
		if(LBB.Name == "Loot")
		{
		LootFloat loot = LBB.GetParent<LootFloat>();

		inv.inv["Money"]   += loot.inv.inv["Money"];
		inv.inv["Food"]    += loot.inv.inv["Food"];
		inv.inv["Rum"]     += loot.inv.inv["Rum"];
		inv.inv["Linens"]  += loot.inv.inv["Linens"];
		inv.inv["Spices"]  += loot.inv.inv["Spices"];
		inv.inv["Jewlery"] += loot.inv.inv["Jewlery"];
		loot.QueueFree();
		}
	}

}
