using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class GameController : MonoBehaviour
{
    public string GameState = "Idle";
    public System.Action GameStateUpdate;


    public int currentPlayer = 1;


    private void Start()
    {
        GameStateUpdate = Start_Enter;
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void Update()
    {
        GameStateUpdate();
    }

    // +++ start state ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Start_Enter()
    {
        GameState = "Start";
        NvpEventBus.Events(GameEvents.State_Started_Enter).TriggerEvent(this, null);
        GameStateUpdate = Start_Update;
    }

    private void Start_Update()
    {
        if (Input.anyKeyDown)
        {
            Start_LeaveTo(Run_Enter);
        }
    }

    private void Start_LeaveTo(Action nextStateEnterAction)
    {
        GameStateUpdate = nextStateEnterAction;
    }

    // +++ run state +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Run_Enter()
    {
        GameStateUpdate = Run_Update;
    }

    private void Run_Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStateUpdate = Serve_Enter;
        }
    }

    

    // +++ serve state ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Serve_Enter()
    {
        GameState = "Serve";

        NvpEventBus.Events(GameEvents.State_Serve_Enter).TriggerEvent(
            this,
            new DefaultEventArgs()
            {
                Value = currentPlayer
            });

        GameStateUpdate = Serve_Update;
    }

    private void Serve_Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NvpEventBus.Events(GameEvents.ServeBall).TriggerEvent(
                this,
                new DefaultEventArgs()
                {
                    Value = currentPlayer
                });
        }
    }
     
    
}
