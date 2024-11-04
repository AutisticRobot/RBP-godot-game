
using System.Numerics;
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

    public virtual void FromData(Dictionary InData)
    {
        ship.Position = new( (float)InData["posX"]
                            ,(float)InData["posY"]);
		ship.dir = (float)InData["dir"];
		ship.speed = (float)InData["speed"];
	    ship.inv = (inventory)InData["inv"];
    	ship.gunState = (float)InData["gunState"];
		ship.sailState = (float)InData["sailState"];
    }
    public virtual Dictionary ToData()
    {
        return new(){
        {"posX", ship.Position.X},
        {"posY", ship.Position.Y},
		{"dir", ship.dir},
		{"speed", ship.speed},
	    {"inv", ship.inv},
    	{"gunState", ship.gunState},
		{"sailState", ship.sailState},
        };
    }
}