using JustGame.Scripts.ScriptableEvent;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Wave")]
    [SerializeField] private int m_initWave;
    [SerializeField] private int m_curWave;
    [SerializeField] private IntEvent m_waveEvent;

    [Header("Time")] 
    [SerializeField] private int m_waveMinute;
    [SerializeField] private int m_waveSeconds;
    [SerializeField] private TimeManager m_timeManager;

    private void Start()
    {
        NextWave(isFirstWave: true);
    }


    private void NextWave(bool isFirstWave = false)
    {
        if (isFirstWave)
        {
            m_curWave = m_initWave;
        }
        else
        {
            m_curWave++;
        }
        
        m_waveEvent.Raise(m_curWave);

        m_timeManager.SetTime(m_waveMinute, m_waveSeconds);
    }
}
