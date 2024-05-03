
using MoreMountains.Feedbacks;
using UnityEngine;

public class PlayerHealth : Health
{
    #if UNITY_EDITOR
    [SerializeField] private bool m_NoDamage;
    #endif
    [SerializeField] private HealthEvent m_updateHealthEvent;
    [SerializeField] private MMF_Player m_flickerVFX;

    protected override void Start()
    {
        base.Start();
        m_updateHealthEvent.Raise(m_curHealth,m_maxHealth);
    }

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
        m_updateHealthEvent.Raise(m_curHealth,m_maxHealth);
        m_flickerVFX.PlayFeedbacks();
        base.UpdateHealthUI();
    }

    public void ResetHealth()
    {
        m_curHealth = m_maxHealth;
    }
    
    public void IncreaseMaxHealth(int addValue)
    {
        m_maxHealth += addValue;
        m_updateHealthEvent.Raise(m_curHealth,m_maxHealth);
    }
}
