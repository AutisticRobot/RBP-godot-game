using Godot;
using Godot.Collections;

[GlobalClass]
public partial class MenuHandler : Control
{
	[Export] public SceneMan LocalScene;
	[Export] public MenuObj defaultMenu;
	[Export] public Array<MenuObj> MenusList;
			 public MenuObj curMenu;

    public override void _Ready()
    {
		Visible = false;
		//curMenu = defaultMenu;
    }

	public override void _Process(double delta)
	{
	}

	public void BackPress()
	{
		if(Visible)
		{
			if(curMenu.prevMenu != null)
			{
				changeToMenu(curMenu.prevMenu);

			}else{
				CloseMenu();

			}
		}else{
			OpenMenu(defaultMenu);
		}

	}
	public void changeToMenu(MenuObj menu)
	{
		CloseMenu();
		OpenMenu(menu);
	}
	public void CloseMenu()
	{
		if(curMenu != null)
		{
			Visible = false;
			curMenu.setVisible(false);
			LocalScene.CloseMenu();
			curMenu = null;
		}
	}
	public void OpenMenu(MenuObj menu)
	{
		Visible = true;
		curMenu = menu;
		LocalScene.OpenMenu(menu);
		curMenu.setVisible(true);

	}

	public void shutDown()
	{
		if(curMenu != null)
		{
			curMenu.shutdown();
		}

	}

}
