using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float m_timeInterval;
    [SerializeField] private int m_curSeconds;
    [SerializeField] private int m_curMinutes;
    [SerializeField] private TimeEvent m_timeEvent;

    private float m_timer;
    private bool m_canUpdate;
    
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
