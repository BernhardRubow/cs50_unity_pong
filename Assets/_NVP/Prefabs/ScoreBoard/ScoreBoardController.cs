using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;
using TMPro;

public class ScoreBoardController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] TextMeshProUGUI _startMessage;
    [SerializeField] TextMeshProUGUI _serveMessage;



    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.State_Started_Enter).GameEventHandler += OnState_Started_Entered;
        NvpEventBus.Events(GameEvents.State_Serve_Enter).GameEventHandler += OnState_Serve_Entered;
        
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.State_Started_Enter).GameEventHandler -= OnState_Started_Entered;
        NvpEventBus.Events(GameEvents.State_Serve_Enter).GameEventHandler -= OnState_Serve_Entered;
    }

    // +++ eventhandler +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnState_Started_Entered(object sender, EventArgs e)
    {
        _startMessage.gameObject.SetActive(true);
    }

    private void OnState_Serve_Entered(object sender, EventArgs e)
    {
        _startMessage.gameObject.SetActive(false);
        _serveMessage.gameObject.SetActive(true);
    }
}
