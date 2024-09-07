using Godot;
using System;

public partial interface shipInput
{

    void start();
    void update(double delta);

    void setShip(Ship ship);

    float getTurnDir();
    float getSailCom();
    bool getAncorState();
}
