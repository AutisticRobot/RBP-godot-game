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
        string outstr = "";
        return outstr;
    }
    public static diramaObjIns Decode(string inData)
    {
		if(inData.Length <= 2)
		{
			return null;
		}
		Dictionary outdat = new();
		string inStr = inData;
        int layer = 0;

        foreach(char a in inStr)
        {
            switch(a)
            {
            case'{':
            layer ++;
            break;
            case'}':
            layer--;
            break;
            default:
            break;
            };

        }

        return new(outdat);
    }
}