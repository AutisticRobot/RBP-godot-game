
using System.Collections.Generic;
using Godot;
using Godot.Collections;

public partial class SaveMan
{
    public System.Collections.Generic.Dictionary<string,SaveInter> saveObjs = new();
    
    public Dictionary decodedData;
    public string metaData = "hi";

    public bool addToBeSaved(SaveInter save)
    {
        try
        {
            saveObjs.Add(save.getID(),save);
            return true;
        }catch{
            GD.PushError("Failed to add obj to save man");

        }
        return false;
    }
    public bool RemoveToBeSaved(string ID)
    {
        try
        {
            if(saveObjs.ContainsKey(ID))
            {
                saveObjs.Remove(ID);
            }
            return true;
        }catch{
            GD.PushError("Failed to add obj to save man");

        }
        return false;
    }

    public string Encode()//bool doSafetyCheck = false)
    {
        Dictionary saveDat = new(){{"meta",metaData}};//preadds the matadata

        foreach (KeyValuePair<string,SaveInter> item in saveObjs)
        {
            saveDat.Add(item.Key, item.Value.ToData());
        }

        return Json.Stringify(saveDat);
        /* //Commenting out because it feels like a waste to delete
        string outData = "{" + metaData;
        bool firstObj = true;
        foreach(SaveInter obj in saveObjs)
        {
            String strObj = obj.ToString();
            if(doSafetyCheck)
            {
                int depth = 0;
                foreach(char c in strObj)
                {
                    if(c == '{'){depth++;}
                    if(c == '}'){depth--;}

                    if(depth < 0)
                    {
                        throw new System.FormatException();
                    }
                }

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
        */
    }
    public void Decode(string inData)
    {
        decodedData = (Dictionary)Json.ParseString(inData);
        metaData = (string)decodedData["meta"];
        decodedData.Remove(metaData);
        GD.Print("savedat: " + decodedData.ToString());

        /* //Commenting out because it feels like a waste to delete
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
        */
    }
}