using System;
using JustGame.Scripts.ScriptableEvent;
using UnityEngine;

//Manage xp earned in the run
public class PlayerRunExp : MonoBehaviour
{
    [SerializeField] private int m_expEarned;
    [SerializeField] private IntEvent m_xpEarnEvent;

    private void Start()
    {
        m_xpEarnEvent.AddListener(OnEarnXP);
    }

    private void OnDestroy()
    {
        m_xpEarnEvent.RemoveListener(OnEarnXP);
    }

    private void OnEarnXP(int xp)
    {
        m_expEarned += xp;
    }
}
