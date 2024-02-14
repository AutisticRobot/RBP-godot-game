using Godot;
using System;

[GlobalClass]
public partial class SceneSave : Node
{
	[Export] public string SaveFolder;
	[Export] public string SaveFile;


	public FileAccess File;
	public Global global;



	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
		//TODO learn the ReadWrite and WriteRead states;
		File = FileAccess.Open(global.savePrefix + SaveFolder + SaveFile, FileAccess.ModeFlags.ReadWrite);
	}

	public override void _Process(double delta)
	{
	}

	//save/load Functions
	public void Load()
	{
		// load data from file
	}
	public void Save()
	{
		//save data to file
	}
}
