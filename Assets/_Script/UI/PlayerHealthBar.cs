using JustGame.Scripts.ScriptableEvent;
using MoreMountains.Feedbacks;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private IntEvent m_playerHealthEvent;
    [SerializeField] private MMF_Player[] m_feedbackList;

    private void Start()
    {
        m_playerHealthEvent.AddListener(OnUpdatePlayerHealth);
    }

    private void OnDestroy()
    {
        m_playerHealthEvent.RemoveListener(OnUpdatePlayerHealth);
    }

    private void OnUpdatePlayerHealth(int curHealth)
    {
        m_feedbackList[curHealth].PlayFeedbacks();
    }
}
