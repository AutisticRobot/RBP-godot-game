using Godot;
using Godot.Collections;


public class diramaObjIns
{
    public string objTypeID;

    public Vector2 Pos;
    public Dictionary data;
    


    public override string ToString()
    {
        return null;
    }
    public static string Encode(diramaObjIns ins)
    {
        return ins.ToString();
    }
    public static diramaObjIns Decode(string inData)
    {
        return new();
    }
}