using Godot;
using Godot.Collections;

public class ShipSave : SaveInter
{
    public Ship ship;

    public ShipSave(Ship inShip)
    {
        ship = inShip;
    }

    public virtual void LoadIntoSaveMan(SaveMan man)
    {
        man.addToBeSaved(this);
    }

    public virtual Dictionary ToData()
    {
        return new(){
        {"posX", ship.Position.X},
        {"posY", ship.Position.Y},
		{"dir", ship.dir},
		{"speed", ship.speed},
	    {"inv", (string)ship.inv},
    	{"gunState", ship.gunState},
		{"sailState", ship.sailState},
        };
    }
    public virtual void FromData(Dictionary InDat)
    {
        ship.Position = new( (float)InDat["posX"]
                            ,(float)InDat["posY"]);
		ship.dir = (float)InDat["dir"];
		ship.speed = (float)InDat["speed"];
	    ship.inv.FromData((string)InDat["inv"]);
    	ship.gunState = (float)InDat["gunState"];
		ship.sailState = (float)InDat["sailState"];
    }
}