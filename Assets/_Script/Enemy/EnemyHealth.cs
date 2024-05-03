using System.Collections;
using JustGame.Script.Manager;
using JustGame.Scripts.Common;
using JustGame.Scripts.ScriptableEvent;
using MoreMountains.Feedbacks;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private EnemyHealthBar m_healthBar;
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private AnimationParameter m_deathAnim;
    [SerializeField] private ActionEvent m_OnTimeOverEvent;
    [SerializeField] private MMF_Player m_deathSFX;

    private bool m_isInstantKill;
    
    protected override void UpdateHealthUI()
    {
        m_healthBar.UpdateHealthBar(MathHelpers.Remap(m_curHealth,0,m_maxHealth,0,1));
        base.UpdateHealthUI();
    }

    protected override void Start()
    {
        m_OnTimeOverEvent.AddListener(OnTimeOver);
        base.Start();
    }

    private void OnTimeOver()
    {
        m_isInstantKill = true;
        TakeDamage(m_curHealth);
    }
    
    protected override void Kill()
    {
        StartCoroutine(KillRoutine());
    }

    private IEnumerator KillRoutine()
    {
        if (m_isInvulnerable)
        {
            yield break;
        }

        m_isInvulnerable = true;
        m_spriteRenderer.enabled = false;
        m_deathAnim.SetTrigger();
        m_deathSFX.PlayFeedbacks();
        yield return new WaitForSeconds(m_deathAnim.Duration);
        if (!m_isInstantKill)
        {
            OnDeath?.Invoke();
        }
        Destroy(this.gameObject);
    }
}
