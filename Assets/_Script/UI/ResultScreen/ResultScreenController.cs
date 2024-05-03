using System.Collections;
using UnityEngine;

public class ResultScreenController : MonoBehaviour
{
    [SerializeField] private ResultScreenView m_view;
    [SerializeField] private GameEventSO m_gameEvent;

    [SerializeField] private UpgradeScreenController m_upgradeScreenController;
    private void Start()
    {
        m_gameEvent.AddListener(OnUpdateGameEvent);
    }

    private void OnDestroy()
    {
        m_gameEvent.RemoveListener(OnUpdateGameEvent);
    }

    public void Hide()
    {
        m_view.Hide();
    }
    
    private void OnUpdateGameEvent(GameEvent incomingEvent)
    {
        switch (incomingEvent)
        {
            case GameEvent.RESPAWN_PLAYER:
                break;
            case GameEvent.TIME_OVER:
                StartCoroutine(ShowScreen());
                break;
        }
    }
    
    private IEnumerator ShowScreen()
    {
        yield return new WaitForSecondsRealtime(1f);
        m_view.Show();
        m_upgradeScreenController.ShowUpgrade();
    }
}
