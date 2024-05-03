using System;
using UnityEngine;


[CreateAssetMenu(menuName = "JustGame/Health Event")]
public class HealthEvent : ScriptableObject
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

    public void Raise(int curHealth, int maxHealth)
    {
        m_listeners?.Invoke(curHealth, maxHealth);
    }
}
