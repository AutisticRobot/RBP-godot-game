using Godot;
using System;

public partial interface shipInput
{

    void start();
    void update(double delta);

    void setShip(Ship ship);

    float getDir();
    float getDirStr();
}
