using Godot;

public partial class MapHudMan : MenuHandler
{
    [Export] public GameOverObj GOScreen;//Game Over Screen
             public bool playerDead = false;
    
	public new void CloseMenu()
    {
        base.CloseMenu();
        if(curMenu == null && !playerDead)
        {
            GOScreen.Visible = true;
        }
    }

    public void activateGOS()
    {
        playerDead = true;
        GOScreen.Visible = true;
    }
}