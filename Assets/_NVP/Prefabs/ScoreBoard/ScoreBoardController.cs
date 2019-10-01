using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;
using TMPro;

public class ScoreBoardController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] TextMeshProUGUI _leftPlayerScore;
    [SerializeField] TextMeshProUGUI _rightPlayerScore;
    [SerializeField] TextMeshProUGUI _startMessage;
    [SerializeField] TextMeshProUGUI _serveMessage;
    [SerializeField] TextMeshProUGUI _gameOverMessage;
    [SerializeField] TextMeshProUGUI _gameOverHintMessage;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnClearScoreboard).GameEventHandler += OnClearScoreboard;
        NvpEventBus.Events(GameEvents.OnServeBall).GameEventHandler += OnState_Serve_Entered;
        NvpEventBus.Events(GameEvents.OnLaunchBall).GameEventHandler += OnBallLaunch;
        NvpEventBus.Events(GameEvents.OnGameOver).GameEventHandler += OnGameOver;

        NvpEventBus.Events(GameEvents.OnScoreChanged).GameEventHandler += OnPlayerScores;
        
    }


    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnClearScoreboard).GameEventHandler -= OnClearScoreboard;
        NvpEventBus.Events(GameEvents.OnServeBall).GameEventHandler -= OnState_Serve_Entered;
        NvpEventBus.Events(GameEvents.OnLaunchBall).GameEventHandler -= OnBallLaunch;
        NvpEventBus.Events(GameEvents.OnGameOver).GameEventHandler -= OnGameOver;

        NvpEventBus.Events(GameEvents.OnScoreChanged).GameEventHandler -= OnPlayerScores;
    }




    // +++ eventhandler +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnClearScoreboard(object sender, EventArgs e)
    {
        _startMessage.gameObject.SetActive(true);
        _startMessage.gameObject.SetActive(true);
        _gameOverMessage.gameObject.SetActive(false);
        _gameOverHintMessage.gameObject.SetActive(false);
    }

    private void OnState_Serve_Entered(object sender, EventArgs e)
    {
        _startMessage.gameObject.SetActive(false);
        _serveMessage.gameObject.SetActive(true);
    }

    private void OnPlayerScores(object sender, EventArgs e)
    {
        var scoreEventArgs = (ScoreEventArgs)e;

        _leftPlayerScore.text = scoreEventArgs.scoreLeftPlayer.ToString();
        _rightPlayerScore.text = scoreEventArgs.scoreRightPlayer.ToString();
    }

    private void OnBallLaunch(object sender, EventArgs e)
    {
        _serveMessage.gameObject.SetActive(false);
    }

    private void OnGameOver(object sender, EventArgs e)
    {
       _gameOverMessage.gameObject.SetActive(true);
       _gameOverHintMessage.gameObject.SetActive(true);
    }
}
