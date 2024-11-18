using System;
using System.Collections.Generic;
using Godot;

public class IDCord
{
    private List<string> allIDs = new();
    private RandomNumberGenerator rand = new();


    public void add(string ID)
    {
        allIDs.Add(ID);
    }
    public void remove(string ID)
    {
        allIDs.Remove(ID);
    }

    public string getNew()
    {
        string outID = rand.Randi().ToString();
        while(IDExists(outID))
        {
            outID = rand.Randi().ToString();
        }
        allIDs.Add(outID);
        return outID;
    }
    public bool IDExists(string ID)
    {
        return allIDs.Contains(ID);
    }
}