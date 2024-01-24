using Godot;
using System;
using System.Collections.Generic;

public partial class Global : Node
{
	// I should look into a better data structure for this;
	// this feels messy;
	Dictionary<string, int> intOptions = new()
	{

	};
	Dictionary<string, string> strOptions = new()
	{

	};

	//player ship data
	public float ShipDir;//in dagrees
	public Vector2 ShipPos;

	//player doll data
	public Vector2 DollPos;
}
