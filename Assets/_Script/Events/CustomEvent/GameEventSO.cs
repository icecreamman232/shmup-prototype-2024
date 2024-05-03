using System;
using UnityEngine;


public enum GameEvent
{
    RESPAWN_PLAYER,
    TIME_OVER,
}

[CreateAssetMenu(menuName = "JustGame/Game Event")]
public class GameEventSO : ScriptableObject
{
    protected Action<GameEvent> m_listeners;
        
    public void AddListener(Action<GameEvent> addListener)
    {
        m_listeners += addListener;
    }

    public void RemoveListener(Action<GameEvent> removeListener)
    {
        m_listeners -= removeListener;
    }

    public void Raise(GameEvent raise)
    {
        m_listeners?.Invoke(raise);
    }
}
