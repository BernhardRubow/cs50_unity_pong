using nvp.events;
using UnityEngine;

public class GameStateClasses_Start : GameState{

    public override void EnterState()
    {
        // trigger events
        NvpEventBus.Events(GameEvents.OnClearScoreboard).TriggerEvent(this, null);

        this.Update = UpdateState;
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            NvpEventBus.Events(GameEvents.OnTransitionToServeState).TriggerEvent(this, null);

    }

    public override void ExitState()
    {
        
    }

}