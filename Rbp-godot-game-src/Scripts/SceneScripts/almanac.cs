using System;
using Godot;
using Godot.Collections;

public class almanac
{
    public Dictionary<string, Resource> ShipDir = new();
	public Dictionary<string, string> SceneDir = new() {
		{"rbp:mainmenu", "res://Scenes/Playspaces/MainMenu.tscn"},
		{"rbp:options","res://Scenes/Playspaces/options_screen.tscn"},
		{"rbp:dirama","res://Scenes/Playspaces/Direamas/PlayerDierama.tscn"},
		{"rbp:oceanmap1","res://Scenes/Playspaces/OceanMaps/GrayBoxArcopelago/OceanMap.tscn"},
	};
}