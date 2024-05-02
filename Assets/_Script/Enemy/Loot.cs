using UnityEngine;
using Random = UnityEngine.Random;

public class Loot : MonoBehaviour
{
    [Header("Coin")]
    [SerializeField] private GameObject m_coinPrefab;
    [SerializeField] private int m_minCoinAmount;
    [SerializeField] private int m_maxCoinAmount;
    [Header("Gem")]
    [SerializeField] private GameObject m_gemPrefab;
    [SerializeField] private int m_minGemAmount;
    [SerializeField] private int m_maxGemAmount;
    [Header("Force")]
    [SerializeField] private float m_minForce;
    [SerializeField] private float m_maxForce;

    private Health m_health;
    private void Start()
    {
        m_health = transform.parent.GetComponent<Health>();
        if (m_health == null) return;

        m_health.OnDeath += OnDrop;
    }

    private void OnDrop()
    {
        var amountCoin = Random.Range(m_minCoinAmount, m_maxCoinAmount + 1);
        for (int i = 0; i < amountCoin; i++)
        {
            SpawnItem(m_coinPrefab);
        }
        
        var amountGem = Random.Range(m_minGemAmount, m_maxGemAmount + 1);
        for (int i = 0; i < amountGem; i++)
        {
            SpawnItem(m_gemPrefab);
        }
        
      
        m_health.OnDeath -= OnDrop;
    }

    private void SpawnItem(GameObject itemPrefab)
    {
        var direction = Random.insideUnitCircle;
        //Make sure only get value in upper half of unit circle
        direction.y = Mathf.Abs(direction.y); 
        var spawnPos = direction + (Vector2)transform.position;
        var coin = Instantiate(itemPrefab, spawnPos, Quaternion.identity);
        var rb = coin.transform.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * Random.Range(m_minForce,m_maxForce));
    }
}
