using Godot;
using System;

public partial class PlayerShipInput1 : shipInput
{
    public Ship ship;

    public void start()
    {
    }
    public void update(double delta)
    {
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

    public bool isFireCannon()
    {
		return Input.IsActionPressed("Shoot");
    }


}
