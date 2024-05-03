using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float m_limit;
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private GameEventSO m_gameEvent;

    private bool m_canMove;
    
    private void Start()
    {
        m_gameEvent.AddListener(OnUpdateGameEvent);
        m_canMove = true;
    }

    private void OnUpdateGameEvent(GameEvent incomingEvent)
    {
        switch (incomingEvent)
        {
            case GameEvent.TIME_OVER:
                m_canMove = false;
                m_gameEvent.RemoveListener(OnUpdateGameEvent);
                break;
        }
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
