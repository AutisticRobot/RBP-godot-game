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
}