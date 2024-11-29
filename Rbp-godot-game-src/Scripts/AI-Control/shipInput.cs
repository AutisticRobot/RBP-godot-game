using Godot;
using System;

public partial interface shipInput
{

    void start(){return;}
    void update(double delta){return;}

    void setShip(Ship ship);

    float getTurnDir();
    float getSailCom();
    bool getAncorState();
    bool isFireCannon();
    Vector2 getCannonTarget();
}
