using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string GameState = "Idle";
    public System.Action GameStateUpdate;


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
        GameStateUpdate = Start_Update;
    }

    private void Start_Update()
    {
        if (Input.anyKeyDown)
        {
            GameStateUpdate = Run_Enter;
        }
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
        GameStateUpdate = Serve_Update;
    }

    private void Serve_Update()
    {
        
    }
}
