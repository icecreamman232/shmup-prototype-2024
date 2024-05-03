using MoreMountains.Feedbacks;
using UnityEngine;

public class PlayerHealth : Health
{
    #if UNITY_EDITOR
    [SerializeField] private bool m_NoDamage;
    #endif
    [SerializeField] private HealthEvent m_updateHealthEvent;
    [SerializeField] private GameEventSO m_gameEvent;
    [SerializeField] private MMF_Player m_flickerVFX;

    private void Awake()
    {
        m_gameEvent.AddListener(OnUpdateGameEvent);
    }

    private void OnUpdateGameEvent(GameEvent incomingEvent)
    {
        switch (incomingEvent)
        {
            case GameEvent.RESPAWN_PLAYER:
                m_curHealth = m_maxHealth;
                m_updateHealthEvent.Raise(m_curHealth,m_maxHealth);
                break;
            case GameEvent.TIME_OVER:
                break;
        }
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
    
    public void IncreaseMaxHealth(int addValue)
    {
        m_maxHealth += addValue;
        m_updateHealthEvent.Raise(m_curHealth,m_maxHealth);
    }
}
