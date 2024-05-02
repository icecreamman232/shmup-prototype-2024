
using JustGame.Scripts.ScriptableEvent;
using UnityEngine;

public class EnemyXP : MonoBehaviour
{
    [SerializeField] private int m_xp;
    [SerializeField] private IntEvent m_xpEarnEvent;
    [SerializeField] private Health m_health;

    private void Start()
    {
        m_health.OnDeath += DropXP;
    }

    private void DropXP()
    {
        m_xpEarnEvent.Raise(m_xp);
        m_health.OnDeath -= DropXP;
    }
}
