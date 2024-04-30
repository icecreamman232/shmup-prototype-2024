using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int m_maxHealth;
    [SerializeField] protected int m_curHealth;
    [SerializeField] protected float m_invulnerableDuration;
    protected bool m_isInvulnerable;
    public Action OnDeath;
    
    protected virtual void Start()
    {
        m_curHealth = m_maxHealth;
    }
    
    public virtual void TakeDamage(int damage)
    {
        if (m_isInvulnerable) return;
        m_curHealth -= damage;
        UpdateHealthUI();
        if (m_curHealth <= 0)
        {
            Kill();
            return;
        }
        
        StartCoroutine(OnInvulnerable());
    }

    protected virtual void UpdateHealthUI()
    {
        
    }

    protected virtual void Kill()
    {
        this.gameObject.SetActive(false);
        OnDeath?.Invoke();
    }

    protected virtual IEnumerator OnInvulnerable()
    {
        m_isInvulnerable = true;
        yield return new WaitForSeconds(m_invulnerableDuration);
        m_isInvulnerable = false;
    }
}
