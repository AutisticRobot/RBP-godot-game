using System.Collections.Generic;
using Godot;

public class modLoader
{
    public Godot.Collections.Dictionary modsList = new();
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
            modsList.Add(modID, path);
        }
        GD.Print(modID);
    }

    public List<Resource> tryOpenFolder(string path, string fileExt, int layer = 0, int maxLayer = 5)// layer for recursion limiting
    {
        List<Resource> outList = new();

        using DirAccess dir = DirAccess.Open(path);
        if(dir != null)
        {
            dir.ListDirBegin();
            string file = dir.GetNext();
            while(file != "")
            {
                if(dir.CurrentIsDir() && layer <= maxLayer)// recursive file searching
                {
                    outList.AddRange(tryOpenFolder(file, fileExt, layer + 1, maxLayer));
                }else if(file.GetExtension() == fileExt)// file load to output
                {
                    outList.Add(ResourceLoader.Load(file));
                }
                file = dir.GetNext();
            }
        }
        return outList;
    }
    
}