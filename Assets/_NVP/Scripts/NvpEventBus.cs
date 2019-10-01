using System;
using System.Collections.Generic;

namespace nvp.events
{
    public enum GameEvents
    {
        State_Started_Enter,
        LeftPlayerUp,
        LeftPlayerDown,
        RightPlayerUp,
        RightPlayerDown,
        State_Serve_Enter,
        ServeBall,
        PlayerScores,
        ScoresChanged
    }

    public class NvpEventBus
    {
        private static readonly Dictionary<GameEvents, GameEventWrapper> EventHandlers;

        static NvpEventBus()
        {
            EventHandlers = new Dictionary<GameEvents, GameEventWrapper>();
        }

        public static GameEventWrapper Events(GameEvents eventName)
        {
            if (!EventHandlers.ContainsKey(eventName))
                EventHandlers[eventName] = new GameEventWrapper();

            return EventHandlers[eventName];
        }
    }

    public class GameEventWrapper
    {
        public event EventHandler GameEventHandler;

        public void TriggerEvent(object sender, EventArgs eventArgs)
        {
            GameEventHandler?.Invoke(sender, eventArgs);
        }
    }

    // Sample EventArgs
    public class DefaultEventArgs : EventArgs
    {
        public object Value;
    }

    public class StringEventArgs : EventArgs{
        public string Value;
    }

    public class ScoreEventArgs : EventArgs{
        public int scoreLeftPlayer;
        public int scoreRightPlayer;
    }
}