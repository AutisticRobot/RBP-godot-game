using System;
using Godot;
using Godot.Collections;




public class diramaObjIns
{
    public string objTypeID;

    public Vector2 Pos;
    public Dictionary data;
    
    diramaObjIns()
    {
        data = new();
    }
    diramaObjIns(Dictionary data)
    {
        this.data = data;
    }


    public override string ToString()
    {
        return Encode(this);
    }
    public static string Encode(diramaObjIns ins, bool sanitizeInput = true)
    {
        ins.data.Add("ObjTypeID", ins.objTypeID);
        ins.data.Add("ObjPosition", ins.Pos);
        string outstr = Json.Stringify(ins.data);
        return outstr;
    }
    public static diramaObjIns Decode(string inData)
    {
		if(inData.Length <= 2)
		{
			return null;
		}
        
        diramaObjIns outIns = new((Dictionary)Json.ParseString(inData));
        outIns.objTypeID = (String)outIns.data["ObjTypeID"];
        outIns.data.Remove("ObjTypeID");
        outIns.Pos = (Vector2)outIns.data["ObjPosition"];
        outIns.data.Remove("ObjPosition");

        return outIns;
    }
}