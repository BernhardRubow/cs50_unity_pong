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
        NvpEventBus.Events(GameEvents.State_Started_Entered).GameEventHandler += OnGameStarted;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.State_Started_Entered).GameEventHandler -= OnGameStarted;
    }

    private void OnGameStarted(object sender, EventArgs e)
    {
        _startMessage.gameObject.SetActive(true);
    }
}
