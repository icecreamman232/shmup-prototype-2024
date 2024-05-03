using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float m_timeInterval;
    [SerializeField] private int m_curSeconds;
    [SerializeField] private int m_curMinutes;
    [SerializeField] private GameEventSO m_gameEvent;
    [SerializeField] private TimeEvent m_timeEvent;
    
    private float m_timer;
    private bool m_canUpdate;

    private void Awake()
    {
        m_gameEvent.AddListener(OnUpdateGameEvent);
    }

    private void OnDestroy()
    {
        m_gameEvent.RemoveListener(OnUpdateGameEvent);
    }

    private void OnUpdateGameEvent(GameEvent incomingEvent)
    {
        switch (incomingEvent)
        {
            case GameEvent.RESPAWN_PLAYER:
                PlayTime();
                break;
            case GameEvent.TIME_OVER:
                PauseTime();
                break;
        }
    }

    private void PlayTime()
    {
        m_canUpdate = true;
    }

    private void PauseTime()
    {
        m_canUpdate = false;
    }

    private void ResetData()
    {
        m_curMinutes = 0;
        m_curSeconds = 0;
        m_timer = 0;
    }

    private void Update()
    {
        if (!m_canUpdate) return;
        
        m_timer += Time.deltaTime;
        if (m_timer >= m_timeInterval)
        {
            UpdateTime();
            m_timer = 0;
        }
    }


    private void UpdateTime()
    {
        m_curSeconds--;
        if (m_curSeconds <= 0)
        {
            m_curSeconds = 60;
            m_curMinutes--;
        }
        
        m_timeEvent.Raise(m_curMinutes, m_curSeconds);
        
        if (m_curMinutes >= 0) return;
        m_timeEvent.Raise(0, 0);
        
        m_gameEvent.Raise(GameEvent.TIME_OVER);
        m_canUpdate = false;
    }

    public void SetTime(int waveMinute, int waveSeconds)
    {
        ResetData();
        m_curMinutes = waveMinute;
        m_curSeconds = waveSeconds;
        m_timeEvent.Raise(m_curMinutes, m_curSeconds);
        m_canUpdate = true;
    }
}
