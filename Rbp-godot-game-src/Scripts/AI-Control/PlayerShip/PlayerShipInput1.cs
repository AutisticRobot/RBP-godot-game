using Godot;
using System;

public partial class PlayerShipInput1 : shipInput
{
    public Ship ship;
    public Cursor cursor;

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
        if(Input.IsActionPressed("L-click"))
        {
		    return dirTowardTar(cursor.GlobalPosition - ship.GlobalPosition);//.Normalized();
        }
        return
        Input.GetActionStrength("Tccw")-
        Input.GetActionStrength("Tcw");
    }
    
    public bool getAncorState()
    {
        return Input.IsActionPressed("Brake");
    }

    public bool isFireCannon()
    {
		return Input.IsActionPressed("Shoot");
    }
    public Vector2 getCannonTarget()
    {
        return cursor.GlobalPosition - ship.GlobalPosition;
    }

    public float dirTowardTar(Vector2 Target)
    {
		float targetDir = (float)(Math.Atan2(-Target.X, -Target.Y) * (180/Math.PI));
        targetDir += 180;


        targetDir -= ship.dir;

        if(5 > targetDir && targetDir > -5){return 0;}//doesent bother moving, if it would only end up jittering
        if((180 > targetDir && targetDir > 0) || -180 > targetDir){
            return 1;
        }
        return -1;
    }


}
