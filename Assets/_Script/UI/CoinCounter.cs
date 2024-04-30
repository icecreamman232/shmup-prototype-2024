using JustGame.Scripts.ScriptableEvent;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_coinCounterTxt;
    [SerializeField] private IntEvent m_coinUpdateEvent;
    [SerializeField] private MMF_Player m_zoomFeedback;

    private void Start()
    {
        m_coinCounterTxt.text = "0";
        m_coinUpdateEvent.AddListener(OnUpdateCoin);
    }

    private void OnDestroy()
    {
        m_coinUpdateEvent.RemoveListener(OnUpdateCoin);
    }

    private void OnUpdateCoin(int coin)
    {
        m_zoomFeedback.PlayFeedbacks();
        m_coinCounterTxt.text = coin.ToString();
    }
}
