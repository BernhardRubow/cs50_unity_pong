using System.Collections.Generic;

public class StateMachineBuilder{
    private StateMachine _stateMachine;

    public StateMachineBuilder(){
        _stateMachine = new StateMachine();
        _stateMachine.gameStates = new Dictionary<GameStates, GameState>();
    }

    public StateMachineBuilder AddGameState(GameStates stateName, GameState stateClass){
        _stateMachine.gameStates.Add(stateName, stateClass);
        return this;
    }

    public StateMachineBuilder SetStartState(GameStates stateName){
        _stateMachine.currentState = stateName;
        _stateMachine.gameStates[stateName].Update = _stateMachine.gameStates[stateName].EnterState;
        return this;
    }

    public StateMachine Build(){
        return _stateMachine;
    }
}