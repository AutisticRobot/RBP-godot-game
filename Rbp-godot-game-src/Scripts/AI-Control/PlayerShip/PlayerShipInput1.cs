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
		    return dirTowardTar(cursor.Position - ship.Position);//.Normalized();
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

    public float dirTowardTar(Vector2 Target)
    {
		float targetDir = (float)(Math.Atan2(Target.X, Target.Y) * (180/Math.PI));

        //fancy math to reduce comparisons down to only 1
        targetDir -= ship.dir;
        targetDir += 360;
        targetDir %= 360;

        if(targetDir < 180){
            return 1;
        }
        return -1;
    }


}
