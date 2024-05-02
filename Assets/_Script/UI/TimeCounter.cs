using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_timerTxt;
    [SerializeField] private TimeEvent m_timeEvent;

    private void Start()
    {
        m_timeEvent.AddListener(OnUpdateTime);
    }
    
    private void OnDestroy()
    {
        m_timeEvent.RemoveListener(OnUpdateTime);
    }

    private void OnUpdateTime(int minute, int seconds)
    {
        m_timerTxt.text = $"{minute:00}:{seconds:00}";
    }
}
