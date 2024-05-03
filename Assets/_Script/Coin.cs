using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float m_limit;
    [SerializeField] private GameEventSO m_gameEvent;

    private void Start()
    {
        m_gameEvent.AddListener(OnUpdateGameEvent);
        
    }

    private void OnUpdateGameEvent(GameEvent incomingEvent)
    {
        switch (incomingEvent)
        {
            case GameEvent.RESPAWN_PLAYER:
                break;
            case GameEvent.TIME_OVER:
                Destroy(this.gameObject);
                break;
        }
    }

    private void OnDestroy()
    {
        m_gameEvent.RemoveListener(OnUpdateGameEvent);
    }

    private void Update()
    {
        if (transform.position.y <= -m_limit)
        {
            Destroy(this.gameObject);
        }
    }
}
