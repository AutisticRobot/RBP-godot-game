
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

    public virtual SaveInter FromString(string str)
    {
        throw new System.NotImplementedException();
    }
    public override string ToString()
    {
        throw new System.NotImplementedException();
    }
}