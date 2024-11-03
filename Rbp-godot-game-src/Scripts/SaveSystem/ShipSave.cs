
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
        throw new System.NotImplementedException();
    }
    public virtual Dictionary ToData()
    {
        throw new System.NotImplementedException();
    }
}