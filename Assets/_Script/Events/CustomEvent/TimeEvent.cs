using System;
using UnityEngine;

[CreateAssetMenu(menuName = "JustGame/Time Event")]
public class TimeEvent : ScriptableObject
{
    protected Action<int, int> m_listeners;
        
    public void AddListener(Action<int,int> addListener)
    {
        m_listeners += addListener;
    }

    public void RemoveListener(Action<int,int> removeListener)
    {
        m_listeners -= removeListener;
    }

    public void Raise(int minute, int seconds)
    {
        m_listeners?.Invoke(minute, seconds);
    }
}
