
using JustGame.Scripts.ScriptableEvent;
using MoreMountains.Feedbacks;
using UnityEngine;

public class PlayerHealth : Health
{
    #if UNITY_EDITOR
    [SerializeField] private bool m_NoDamage;
    #endif
    [SerializeField] private IntEvent m_updateHealthEvent;
    [SerializeField] private MMF_Player m_flickerVFX;

    public override void TakeDamage(int damage)
    {
#if UNITY_EDITOR
        if (m_NoDamage)
        {
            return;
        }
#endif
        base.TakeDamage(damage);
    }

    protected override void UpdateHealthUI()
    {
        m_updateHealthEvent.Raise(m_curHealth);
        m_flickerVFX.PlayFeedbacks();
        base.UpdateHealthUI();
    }
}
