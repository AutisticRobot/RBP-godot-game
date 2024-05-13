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
		curMenu = defaultMenu;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void BackPress()
	{
		if(Visible)
		{
			if(curMenu.prevMenu != null)
			{
				curMenu.setVisible(false);
				curMenu.prevMenu.setVisible(true);

			}else{
				CloseMenu();

			}
		}else{
			OpenMenu(defaultMenu);
		}

	}
	public void CloseMenu()
	{
		Visible = false;
		LocalScene.CloseMenu();
	}
	public void OpenMenu(MenuObj menu)
	{
		Visible = true;
		LocalScene.OpenMenu(menu);
		curMenu.setVisible(false);
		curMenu = menu;
		curMenu.setVisible(true);

	}

}
