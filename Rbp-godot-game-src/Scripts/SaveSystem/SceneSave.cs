using Godot;
using System;

[GlobalClass]
public partial class SceneSave : Resource
{
	[Export] public string SaveFolder;
	[Export] public string SaveFile;


	public Global global;


	public void Save(Variant data)
	{
		using FileAccess file = FileAccess.Open(SaveFolder + SaveFile, FileAccess.ModeFlags.Write);
		file.StoreVar(data);
	}
	public Variant Load()
	{
		using FileAccess file = FileAccess.Open(SaveFolder + SaveFile, FileAccess.ModeFlags.Read);
		return file.GetVar();
	}


}
