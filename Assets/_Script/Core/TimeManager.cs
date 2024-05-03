using JustGame.Scripts.ScriptableEvent;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float m_timeInterval;
    [SerializeField] private int m_curSeconds;
    [SerializeField] private int m_curMinutes;
    [SerializeField] private TimeEvent m_timeEvent;
    [SerializeField] private ActionEvent m_timeOverEvent;
    [SerializeField] private EnemySpawner[] m_enemySpawner;
    
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
        
        if (m_curMinutes >= 0) return;
        m_timeEvent.Raise(0, 0);
        m_timeOverEvent.Raise();
        PauseGame();
        m_canUpdate = false;
    }

    public void SetTime(int waveMinute, int waveSeconds)
    {
        ResetData();
        m_curMinutes = waveMinute;
        m_curSeconds = waveSeconds;
        m_timeEvent.Raise(m_curMinutes, m_curSeconds);
        m_canUpdate = true;
        UnPauseGame();
    }

    private void PauseGame()
    {
        foreach (var spawner in m_enemySpawner)
        {
            spawner.StopSpawn();
        }
        Time.timeScale = 0;
    }

    private void UnPauseGame()
    {
        foreach (var spawner in m_enemySpawner)
        {
            spawner.StartSpawn();
        }
        Time.timeScale = 1;
    }
}
