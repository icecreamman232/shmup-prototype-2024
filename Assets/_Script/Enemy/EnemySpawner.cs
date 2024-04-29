using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] m_enemyPrefabList;
    [SerializeField] private Transform m_spawnPivot;
    [SerializeField] private float m_minDelaySpawn;
    [SerializeField] private float m_maxDelaySpawn;

    private float m_nextDelaySpawn;
    private float m_timer;
    private void Start()
    {
        m_nextDelaySpawn = Random.Range(m_minDelaySpawn, m_maxDelaySpawn);
    }

    private void Update()
    {
        m_timer += Time.deltaTime;
        
        if (m_timer >= m_nextDelaySpawn)
        {
            m_timer = 0;
            m_nextDelaySpawn = Random.Range(m_minDelaySpawn, m_maxDelaySpawn);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(m_enemyPrefabList[Random.Range(0, m_enemyPrefabList.Length)]
            , m_spawnPivot.position
            , Quaternion.identity);
    }
}
