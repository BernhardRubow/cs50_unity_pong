using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using nvp.events;

public class KeyboardController : MonoBehaviour
{
    private IActor leftPlayerActor;
    private ICommand leftPlayerCommand;

    private IActor rightPlayerActor;
    private ICommand rightPlayerCommand;

    private MoveDownCommand moveDownCmd;
    private MoveUpCommand moveUpCommand;

    void Start()
    {
        List<ActorController> actors = GameObject.FindObjectsOfType<ActorController>().ToList();
        leftPlayerActor = actors.Single(x => x.name == "PlayerPaddle");
        rightPlayerActor = actors.Single(x => x.name == "AI_Paddle");

        moveUpCommand = new MoveUpCommand();
        moveDownCmd = new MoveDownCommand();
    }

    void Update()
    {
        // left player
        leftPlayerCommand = null;
        if (Input.GetKey(KeyCode.W)) leftPlayerCommand = moveUpCommand;
        if (Input.GetKey(KeyCode.S)) leftPlayerCommand = moveDownCmd;

        rightPlayerCommand = null;
        if (Input.GetKey(KeyCode.UpArrow)) rightPlayerCommand = moveUpCommand;
        if (Input.GetKey(KeyCode.DownArrow)) rightPlayerCommand = moveDownCmd;
    }

    void FixedUpdate()
    {
        leftPlayerCommand?.Execute(leftPlayerActor);
        rightPlayerCommand?.Execute(rightPlayerActor);
        
    }
}