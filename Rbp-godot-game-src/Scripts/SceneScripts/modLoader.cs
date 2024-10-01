using System.Collections.Generic;
using Godot;

public class modLoader
{
    public List<string> modsList = new();
    public static string modsFolder = "user://mods/";

    public void Start()
    {
        LoadMods();
    }

    public void LoadMods()// will not autoload hidden mod folders
    {
        using DirAccess dir = DirAccess.Open(modsFolder);
        if(dir != null)
        {
            dir.ListDirBegin();
            string mod = dir.GetNext();
            while(mod != "")
            {
                if(dir.CurrentIsDir() && mod[0] != '.')
                {
                    openMod(modsFolder + mod);
                }
                mod = dir.GetNext();
            }
        }
        
    }

    public void openMod(string path)
    {
        GD.Print(path);
        using DirAccess dir = DirAccess.Open(path);
        string modID = "";
        if(dir.FileExists("modid.txt"))
        {
            using FileAccess tmp = FileAccess.Open(path + "/modid.txt", FileAccess.ModeFlags.Read);
            modID = tmp.GetAsText();
            modsList.Add(modID);
        }
        GD.Print(modID);
    }
    
}