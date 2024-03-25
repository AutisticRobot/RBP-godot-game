using Godot;
using System;

public partial class shipModelData : Resource
{
    [Export] public Texture2D icoSprite;
    [Export] public int maxHealth;
    [Export] public int maxSpeed;
    [Export] public inventory maxLoad;
}
