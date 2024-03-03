using Godot;
using System;
using System.Collections.Generic;

public partial class Global : Node
{
	//Save Options
	public string savePrefix = "user://saves/sav-1/";


	//player ship data
	public float ShipDir;//in dagrees
	public Vector2 ShipPos;
	public inventory playerHull;

	//player doll data
	public Vector2 DollPos;

	//dirAcess
	public DirAccess dir = DirAccess.Open("user://");

}
