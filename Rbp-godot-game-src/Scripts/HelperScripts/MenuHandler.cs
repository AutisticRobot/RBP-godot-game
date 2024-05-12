using Godot;
using System;

[GlobalClass]
public partial class MenuHandler : Control
{
	[Export] public SceneMan LocalScene;
	[Export] public MenuObj defaultMenu;
			 public MenuObj curMenu;

    public override void _Ready()
    {
		Visible = false;
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
		curMenu.setVisible(false);
		curMenu = menu;
		curMenu.setVisible(true);

	}

}
