using Godot;
using System;

public partial class Item : Resource
{
    [Export] public string name;
    [Export] public int ID;// I cant decide weather to use string name or int ID for easy finding in higher levels
    [Export] public int count;
    [Export] public Texture2D Icon;
}
