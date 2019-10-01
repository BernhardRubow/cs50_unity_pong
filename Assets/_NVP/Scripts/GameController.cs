using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class GameController : MonoBehaviour
{
    public string GameState = "Idle";

    public StateMachine stateMachine;


    public static int CURRENTPLAYER = 1;
    public static int PLAYERLEFTSCORE = 0;
    public static int PLAYERRIGHTSCORE = 0;


    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        stateMachine = new StateMachineBuilder()
            .AddGameState(GameStates.Start, new GameStateClasses_Start())
            .AddGameState(GameStates.Serve, new GameStateClasses_Serve())
            .AddGameState(GameStates.Run, new GameStateClasses_Run())
            .AddGameState(GameStates.GameOver, new GameStateClasses_GameOver())
            .SetStartState(GameStates.Start)
            .Build();
        //NvpEventBus.Events(GameEvents.OnPlayerScores).GameEventHandler += OnPlayerScores;
    }

    private void OnDisable()
    {
        stateMachine.Dispose();
    }

    private void Update()
    {
        stateMachine.Update();
        //GameStateUpdate();
    }
}
