using Godot;
using System;

[GlobalClass]
public partial class cannonData : Resource
{
    [Export] internal string cannonBallUUID;
    [Export] internal MunitionRes ammoData;
    [Export] internal float ammoSpeed;
}