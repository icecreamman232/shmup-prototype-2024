using JustGame.Script.Manager;
using JustGame.Scripts.ScriptableEvent;
using MoreMountains.Feedbacks;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int m_curCoin;
    [SerializeField] private IntEvent m_coinUpdateEvent;
    [SerializeField] private MMF_Player m_collectCoinSFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(LayerManager.CoinTag))
        {
            CollectCoin(other.gameObject);
            return;
        }
    }

    private void CollectCoin(GameObject coin)
    {
        m_collectCoinSFX.PlayFeedbacks();
        m_curCoin++;
        m_coinUpdateEvent.Raise(m_curCoin);
        Destroy(coin);
    }
}
