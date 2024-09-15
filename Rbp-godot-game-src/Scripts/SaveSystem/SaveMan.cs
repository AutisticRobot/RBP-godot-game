
using System;

public partial class SaveMan
{
    public Array saveObjs;
    public Array decodedData;

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

    public string Encode(bool doSafetyCheck = false)
    {
        string outData = "{";
        bool firstObj = true;
        foreach(SaveInter obj in saveObjs)
        {
            String strObj = obj.ToString();
            if(doSafetyCheck)
            {

            }

            if(!firstObj)
            {
                outData += ",";
            }else{
                firstObj = !firstObj;
            }

            outData += strObj;

        }
        return outData + "}";
    }
    public void Decode(string inData)
    {

    }
}