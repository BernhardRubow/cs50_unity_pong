using nvp.events;
using UnityEngine;

public class GameStateClasses_Serve : GameState
{
    public override void EnterState()
    {
        var ea = new DefaultEventArgs
        {
            Value = GameController.CURRENTPLAYER
        };

        NvpEventBus.Events(GameEvents.OnServeBall).TriggerEvent(this, ea);
        Update = UpdateState;
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NvpEventBus.Events(GameEvents.OnTransitionToRunState).TriggerEvent(this, null);
        }
    }

    public override void ExitState()
    {
        var ea = new DefaultEventArgs
        {
            Value = GameController.CURRENTPLAYER
        };

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NvpEventBus.Events(GameEvents.OnLaunchBall).TriggerEvent(this, ea);
        }
    }
}