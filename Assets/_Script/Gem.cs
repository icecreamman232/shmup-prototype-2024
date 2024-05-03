using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private float m_limit;
    [SerializeField] private GameEventSO m_gameEvent;

    private void Start()
    {
        m_gameEvent.AddListener(OnUpdateGameEvent);
        
    }

    private void OnUpdateGameEvent(GameEvent incomingEvent)
    {
        Destroy(this.gameObject);
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
