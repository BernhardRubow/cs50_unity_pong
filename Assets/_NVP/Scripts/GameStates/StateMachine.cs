using System;
using System.Collections.Generic;
using nvp.events;

public class StateMachine : System.IDisposable {

    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public GameStates currentState = GameStates.Start;
    public Dictionary<GameStates, GameState> gameStates;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public StateMachine()
    {
        NvpEventBus.Events(GameEvents.OnTransitionToServeState).GameEventHandler += OnTransitionToServeState;
        NvpEventBus.Events(GameEvents.OnTransitionToRunState).GameEventHandler += OnTransitionToRunState;
        NvpEventBus.Events(GameEvents.OnTransitionToGameOver).GameEventHandler += OnTransitionToGameOverState;
    }


    public void Dispose()
    {
        NvpEventBus.Events(GameEvents.OnTransitionToServeState).GameEventHandler -= OnTransitionToServeState;
        NvpEventBus.Events(GameEvents.OnTransitionToRunState).GameEventHandler -= OnTransitionToRunState;
        NvpEventBus.Events(GameEvents.OnTransitionToGameOver).GameEventHandler -= OnTransitionToGameOverState;
    }

    public void Update()
    {
        gameStates[currentState].Update();
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnTransitionToRunState(object sender, EventArgs e)
    {
        DoStateTransition(currentState, GameStates.Run);
    }

    private void OnTransitionToServeState(object sender, EventArgs e)
    {
        DoStateTransition(currentState, GameStates.Serve);
    }

    private void OnTransitionToGameOverState(object sender, EventArgs e)
    {
        DoStateTransition(currentState, GameStates.GameOver);
    }




    // +++ private class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void DoStateTransition(GameStates from, GameStates to)
    {
        gameStates[from].ExitState();
        currentState = to;
        gameStates[to].EnterState();
    }
}