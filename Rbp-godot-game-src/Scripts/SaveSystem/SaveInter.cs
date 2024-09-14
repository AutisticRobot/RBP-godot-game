
using System;

public partial interface SaveInter
{
    public void LoadIntoSaveMan(SaveMan man);

    public String ToString();
    public SaveInter FromString(String str);
}