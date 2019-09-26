using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class KeyboardController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // left player
        if (Input.GetKey(KeyCode.W)) NvpEventBus.Events(GameEvents.LeftPlayerUp).TriggerEvent(this, null);
        if (Input.GetKey(KeyCode.S)) NvpEventBus.Events(GameEvents.LeftPlayerDown).TriggerEvent(this, null);


        if (Input.GetKey(KeyCode.UpArrow)) NvpEventBus.Events(GameEvents.RightPlayerUp).TriggerEvent(this, null);
        if (Input.GetKey(KeyCode.DownArrow)) NvpEventBus.Events(GameEvents.RightPlayerDown).TriggerEvent(this, null);

        
    }
}
