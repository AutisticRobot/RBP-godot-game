using Godot;
using System;

[GlobalClass]
public partial class SceneSave : Resource
{
	[Export] public string SaveFolder;
	[Export] public string SaveFile;


	public Global global;


	public bool Exists(bool dir)
	{
		string path = global.savePrefix + SaveFolder;
		if(!dir)
		{
			path += SaveFile;
			return FileAccess.FileExists(path);
		}
		return DirAccess.DirExistsAbsolute(path);
	}

	public void Save(Variant data)
	{
		if(!Exists(true))
		{
			global.dir.MakeDirRecursive(global.savePrefix + SaveFolder);
		}
		
		using FileAccess file = FileAccess.Open(global.savePrefix + SaveFolder + SaveFile, FileAccess.ModeFlags.Write);
		file.StoreVar(data);
		GD.Print(global.savePrefix + SaveFolder + SaveFile);
	}
	public Variant Load()
	{
		if(!Exists(false)) return 0;
		using FileAccess file = FileAccess.Open(global.savePrefix + SaveFolder + SaveFile, FileAccess.ModeFlags.Read);
		return file.GetVar();
	}


}
