using System;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_limit;
    [SerializeField] private DamageHandler m_damageHandler;
    
    private bool m_canUpdate;

    private void Start()
    {
        m_damageHandler.OnHit += OnHitTarget;
    }

    private void OnDestroy()
    {
        m_damageHandler.OnHit -= OnHitTarget;
    }

    private void OnDisable()
    {
        m_canUpdate = false;
    }

    public void SpawnBullet(Vector2 position, int damageUpgrade = 0)
    {
        m_damageHandler.IncreaseDamage(damageUpgrade);
        transform.position = position;
        m_canUpdate = true;
    }

    private void OnHitTarget()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!m_canUpdate) return;
        
        transform.Translate(Vector2.up * (Time.deltaTime * m_moveSpeed));

        if (transform.position.y >= m_limit)
        {
            this.gameObject.SetActive(false);
        }
    }
}
