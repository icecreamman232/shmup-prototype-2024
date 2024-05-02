using JustGame.Script.Manager;
using JustGame.Scripts.ScriptableEvent;
using MoreMountains.Feedbacks;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Coin")]
    [SerializeField] private int m_curCoin;
    [SerializeField] private IntEvent m_coinUpdateEvent;
    [SerializeField] private MMF_Player m_collectCoinSFX;
    
    [Header("Coin")]
    [SerializeField] private int m_curGem;
    [SerializeField] private IntEvent m_gemUpdateEvent;
    [SerializeField] private MMF_Player m_collectGemSFX;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(LayerManager.CoinTag))
        {
            CollectCoin(other.gameObject);
        }
        else if (other.gameObject.CompareTag(LayerManager.GemTag))
        {
            CollectGem(other.gameObject);
        }
    }

    private void CollectGem(GameObject gem)
    {
        m_collectGemSFX.PlayFeedbacks();
        m_curGem++;
        m_gemUpdateEvent.Raise(m_curGem);
        Destroy(gem);
    }
    
    private void CollectCoin(GameObject coin)
    {
        m_collectCoinSFX.PlayFeedbacks();
        m_curCoin++;
        m_coinUpdateEvent.Raise(m_curCoin);
        Destroy(coin);
    }
}
