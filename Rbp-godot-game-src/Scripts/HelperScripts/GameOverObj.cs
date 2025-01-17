using Godot;

public partial class GameOverObj : MenuObj
{
    [Signal] public delegate void RespawnEventHandler();
    public void RespawnPress()
    {
        EmitSignal(SignalName.Respawn);
    }

}