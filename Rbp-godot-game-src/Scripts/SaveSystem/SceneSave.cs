using Godot;
using System;

[GlobalClass]
public partial class SceneSave : Resource
{
	[Export] public string SaveFolder;
	[Export] public string SaveFile;


	public FileAccess File;
	public Global global;

// this function defently need to be reworked
public void OpenFile()
{
	File = FileAccess.Open(global.savePrefix + SaveFolder + SaveFile, FileAccess.ModeFlags.ReadWrite);
}

}
