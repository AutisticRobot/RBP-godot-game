
using System;
using Godot.Collections;

public partial interface SaveInter
{
    void LoadIntoSaveMan(SaveMan man);
    void unloadFromSaveMan(SaveMan man);

    string getID();

    Dictionary ToData();
    void FromData(Dictionary inDat);
}