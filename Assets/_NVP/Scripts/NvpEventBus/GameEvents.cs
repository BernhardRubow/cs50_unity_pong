namespace nvp.events
{
    public enum GameEvents
    {
        // in game evens
        OnClearScoreboard,
        LeftPlayerUp,
        LeftPlayerDown,
        RightPlayerUp,
        RightPlayerDown,
        OnServeBall,
        OnLaunchBall,
        OnPlayerScores,
        OnScoreChanged,
        OnGameOver,

        // transition events
        OnTransitionToRunState,
        OnTransitionToServeState,
        OnTransitionToGameOver,
    }
}