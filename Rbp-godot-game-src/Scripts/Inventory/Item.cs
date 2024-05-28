using Godot;
using System;

[GlobalClass]
public partial class Item : Resource
{
    [Export] public int ID;
    [Export] public int count;
    [Export] public string name;//=======\
    [Export] public Texture2D Icon;//====+====these two need to be put in a global lookup table.
}
