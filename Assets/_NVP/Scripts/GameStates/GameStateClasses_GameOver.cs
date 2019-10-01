using nvp.events;
using UnityEngine;

public class GameStateClasses_GameOver : GameState
{
    public override void EnterState()
    {
        var ea = new ScoreEventArgs
        {
            scoreLeftPlayer = GameController.PLAYERLEFTSCORE,
            scoreRightPlayer = GameController.PLAYERRIGHTSCORE
        };
        NvpEventBus.Events(GameEvents.OnGameOver).TriggerEvent(this, ea);
    }

    public override void UpdateState()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            NvpEventBus.Events(GameEvents.OnTransitionToGameOver).TriggerEvent(this,null);
    }

    public override void ExitState()
    {

    }
}