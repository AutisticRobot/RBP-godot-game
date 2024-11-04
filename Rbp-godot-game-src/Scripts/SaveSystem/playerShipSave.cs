
using Godot.Collections;

public class playerShipSave : ShipSave
{
    public string PlayerShipID;
    public PlayerShip player;


    public playerShipSave(PlayerShip inShip, string inID) : base(inShip.ship)
    {
        PlayerShipID = inID;
        player = inShip;
    }
    public override Dictionary ToData()
    {
        Dictionary outDat = base.ToData();
        outDat.Merge
        (new(){
            {"playID",PlayerShipID},
        },true);
        return outDat;
    }
    public override void FromData(Dictionary inDat)
    {
        base.FromData(inDat);

        PlayerShipID = (string)inDat["playID"];

    }
}