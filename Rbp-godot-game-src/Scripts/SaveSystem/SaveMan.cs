
using System;
using Godot;

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
        int layer = -1;
        string parStr = "";
        int objcount = 0;
        foreach(char c in inData)//note: this implamentation will naturaly discard the end caps of inData(at least the right one)
        {// the left end cap is stored in decodedData[0]
            parStr += c;

            if(c == '{'){layer++;}
            if(c == '}'){layer--;}

            if(layer == 0)
            {
                decodedData.SetValue(parStr, objcount);
                objcount++;
                parStr = "";
            }
        }

        parStr = (string)decodedData.GetValue(1);

        int metadataend = parStr.Find("{");

        decodedData.SetValue(parStr.Remove(metadataend), 0);//!!!!!!!!!!!!NEEDS TESTING
        decodedData.SetValue(parStr.Substring(metadataend), 1);

        GD.Print(decodedData.GetValue(0));
        GD.Print(decodedData.GetValue(1));
    }
}