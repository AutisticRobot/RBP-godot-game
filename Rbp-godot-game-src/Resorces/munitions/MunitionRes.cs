using Godot;
using System;

[GlobalClass]
public partial class MunitionRes : Resource
{
	[Export] public float Gravity = -0.1f;
	[Export] public bool ispaused = true;
	[Export] public float scaleMulti = 1;
	[Export] public float WaterDisFromCam = 100;

	[Export] public float Height = 90;
	[Export] public float VirVel = 0;//virtical velocity

	[Export] public int dammage = 1;
}
