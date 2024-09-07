using Godot;
using System;

public partial class PlayerShipInput1 : shipInput
{
    public Ship ship;

    public void start()
    {
        throw new NotImplementedException();
    }
    public void update(double delta)
    {
        throw new NotImplementedException();
    }

    public void setShip(Ship ship)
    {
        this.ship = ship;
    }

    public float getSailCom()
    {
        return
        Input.GetActionStrength("Accelerate") -
        Input.GetActionStrength("Reverse");
    }

    public float getTurnDir()
    {
        return
        Input.GetActionStrength("Tcw") -
        Input.GetActionStrength("Tccw");
    }
    
    public bool getAncorState()
    {
        return Input.IsActionPressed("Brake");
    }


}
