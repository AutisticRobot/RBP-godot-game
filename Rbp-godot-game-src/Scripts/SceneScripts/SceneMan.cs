using Godot;

[GlobalClass]
public partial class SceneMan : Node2D
{
	[Export] public SceneSave saveF;
	[Export] public bool pausedScene;

	public Global global;
	// Called when the node enters the scene tree for the first time.
	public void ScenePrep()
	{
		if(saveF == null){GD.Print("saveFile resource not set in " + Name);}
		global = GetNode<Global>("/root/Global");
		saveF.global = global;
		global.curSceneMan = this;
	}

	public virtual void _CloseScenePrep() {}
	public virtual void CloseMenu() {}//<-------------\
	public virtual void OpenMenu(MenuObj menu) {}//<--+----- These are only for preping scene for opening menu. THEY ARE CALLED BY THE MENUHANDLER
	
}
