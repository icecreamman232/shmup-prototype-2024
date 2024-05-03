using DG.Tweening;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_canvasGroup;
    [SerializeField] private GameEventSO m_gameEvent;

    private void Awake()
    {
        m_gameEvent.AddListener(OnUpdateGameEvent);
        Hide();
    }

    private void OnDestroy()
    {
        m_gameEvent.RemoveListener(OnUpdateGameEvent);
    }

    private void Show()
    {
        m_canvasGroup.DOFade(1, 0.3f).SetUpdate(true);
    }

    private void Hide()
    {
        m_canvasGroup.DOFade(0, 0.3f).SetUpdate(true);
    }

    private void OnUpdateGameEvent(GameEvent incomingEvent)
    {
        switch (incomingEvent)
        {
            case GameEvent.RESPAWN_PLAYER:
                Show();
                break;
        }
    }
}
