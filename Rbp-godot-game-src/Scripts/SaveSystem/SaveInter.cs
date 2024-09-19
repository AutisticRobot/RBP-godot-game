
using System;

public partial interface SaveInter
{
    public void LoadIntoSaveMan(SaveMan man);

    public string ToString();
    public SaveInter FromString(string str);
}