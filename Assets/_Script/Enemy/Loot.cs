using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Loot : MonoBehaviour
{
    [SerializeField] private GameObject m_coinPrefab;
    [SerializeField] private int m_minAmount;
    [SerializeField] private int m_maxAmount;
    [SerializeField] private float m_minForce;
    [SerializeField] private float m_maxForce;

    private Health m_health;
    private void Start()
    {
        m_health = transform.parent.GetComponent<Health>();
        if (m_health == null) return;

        m_health.OnDeath += OnDrop;
    }

    private void OnDrop()
    {
        var amount = Random.Range(m_minAmount, m_maxAmount);
        for (int i = 0; i < amount; i++)
        {
            var direction = Random.insideUnitCircle;
            //Make sure only get value in upper half of unit circle
            direction.y = Mathf.Abs(direction.y); 
            var spawnPos = direction + (Vector2)transform.position;
            var coin = Instantiate(m_coinPrefab, spawnPos, Quaternion.identity);
            var rb = coin.transform.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * Random.Range(m_minForce,m_maxForce));
        }
        
      
        m_health.OnDeath -= OnDrop;
    }
}
