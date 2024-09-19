
public class ShipSave : SaveInter
{
    public Ship ship;

    public void LoadIntoSaveMan(SaveMan man)
    {
        man.addToBeSaved(this);
    }

    public SaveInter FromString(string str)
    {
        throw new System.NotImplementedException();
    }
    public string ToString()
    {
        throw new System.NotImplementedException();
    }
}