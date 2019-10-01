using System;
using nvp.events;

public class GameStateClasses_Run : GameState
{
    public override void EnterState()
    {
        NvpEventBus.Events(GameEvents.OnPlayerScores).GameEventHandler += OnPlayerScores;
        this.Update = UpdateState;
    }

    public override void UpdateState()
    {
        // do nothing special
    }

    public override void ExitState()
    {
        NvpEventBus.Events(GameEvents.OnPlayerScores).GameEventHandler -= OnPlayerScores;
    }

    // +++ Event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private void OnPlayerScores(object sender, EventArgs e)
    {
        var ea = (StringEventArgs)e;

        if (ea.Value == "left")
        {
            GameController.PLAYERLEFTSCORE++;
        }
        else if (ea.Value == "right")
        {
            GameController.PLAYERRIGHTSCORE++;
        }

        var eventArgs = new ScoreEventArgs
        {
            scoreLeftPlayer = GameController.PLAYERLEFTSCORE,
            scoreRightPlayer = GameController.PLAYERRIGHTSCORE
        };

        // trigger in game event
        NvpEventBus.Events(GameEvents.OnScoreChanged).TriggerEvent(this, eventArgs);

        // trigger State transition
        if (GameController.PLAYERLEFTSCORE < 11 && GameController.PLAYERRIGHTSCORE < 11)
            NvpEventBus.Events(GameEvents.OnTransitionToServeState).TriggerEvent(this, null);
        else
            NvpEventBus.Events(GameEvents.OnTransitionToGameOver).TriggerEvent(this, null);
    }

    
}