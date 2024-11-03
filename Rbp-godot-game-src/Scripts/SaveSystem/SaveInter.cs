
using System;
using Godot.Collections;

public partial interface SaveInter
{
    public void LoadIntoSaveMan(SaveMan man);

    public Dictionary ToData();
    public void FromData(Dictionary str);
}