using System;
using JustGame.Scripts.ScriptableEvent;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float m_limit;
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private ActionEvent m_timeOverEvent;

    private bool m_canMove;
    
    private void Start()
    {
        m_timeOverEvent.AddListener(OnTimeOver);
        m_canMove = true;
    }

    private void OnTimeOver()
    {
        m_canMove = false;
        m_timeOverEvent.RemoveListener(OnTimeOver);
    }

    private void Update()
    {
        if (!m_canMove) return;
        
        transform.Translate(Vector2.down * (Time.deltaTime*m_moveSpeed));
        if (transform.position.y <= -m_limit)
        {
            Destroy(this.gameObject);
        }
    }
}
