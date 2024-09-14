
using System;

public partial class SaveMan
{
    public Array saveObjs;

    public bool addToBeSaved(SaveInter save)
    {
        try
        {
            saveObjs.SetValue(save, saveObjs.Length);
            return true;
        }catch{

        }
        return false;
    }
}