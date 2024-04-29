using System;
using JustGame.Script.Manager;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private LayerMask m_targetMask;
    [SerializeField] private int m_minDamage;
    [SerializeField] private int m_maxDamage;

    public Action OnHit;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!LayerManager.IsInLayerMask(other.gameObject.layer, m_targetMask))
        {
            return;
        }

        CauseDamage(other.gameObject);
    }

    private void CauseDamage(GameObject target)
    {
        var health = target.GetComponent<Health>();
        if (health == null) return;
        
        var damageCause = Random.Range(m_minDamage, m_maxDamage);
        health.TakeDamage(damageCause);
        OnHit?.Invoke();
    }
}
