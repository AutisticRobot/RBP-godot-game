using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class SceneSave : Resource
{
	[Export] public string SaveFolder;
	[Export] public string SaveFile;


	public Global global;
	public Dictionary Data;


	public string Path()
	{
		return global.savePrefix + SaveFolder;
	}

	public bool Exists(bool checkDir = false)
	{
		string path = global.savePrefix + SaveFolder;
		if(!checkDir)
		{
			path += SaveFile;
			return FileAccess.FileExists(path);
		}
		return DirAccess.DirExistsAbsolute(path);
	}

	
	public void Save()// default function (default prameter dosent work on variants)
	{
		Save(Data);
	}
	public void Save(Variant inData)
	{
		if(!Exists(true))
		{
			global.dir.MakeDirRecursive(global.savePrefix + SaveFolder);
		}
		
		using FileAccess file = FileAccess.Open(global.savePrefix + SaveFolder + SaveFile, FileAccess.ModeFlags.Write);
		file.StoreVar(inData);
		GD.Print(global.savePrefix + SaveFolder + SaveFile);
	}
	public Dictionary Load()
	{
		if(!Exists(false)) return null;
		using FileAccess file = FileAccess.Open(global.savePrefix + SaveFolder + SaveFile, FileAccess.ModeFlags.Read);


		Data = (Dictionary)file.GetVar();
		return Data;
	}


}
