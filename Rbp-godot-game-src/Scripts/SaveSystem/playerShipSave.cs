
public class playerShipSave : ShipSave
{
    public string PlayerShipID;


    public playerShipSave(Ship inShip, string inID) : base(inShip)
    {
        PlayerShipID = inID;
    }
}