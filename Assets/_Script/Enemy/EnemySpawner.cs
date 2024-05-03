using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] m_enemyPrefabList;
    [SerializeField] private Transform m_spawnPivot;
    [SerializeField] private float m_minDelaySpawn;
    [SerializeField] private float m_maxDelaySpawn;
    [SerializeField] private GameEventSO m_gameEvent;
  
    private float m_nextDelaySpawn;
    private float m_timer;
    private bool m_canSpawn;

    private void Awake()
    {
        m_gameEvent.AddListener(OnUpdateGameEvent);
    }

    private void OnUpdateGameEvent(GameEvent incomingEvent)
    {
        switch (incomingEvent)
        {
            case GameEvent.RESPAWN_PLAYER:
                StartSpawn();
                break;
            case GameEvent.TIME_OVER:
                StopSpawn();
                break;
        }
    }

    private void Start()
    {
        m_nextDelaySpawn = Random.Range(m_minDelaySpawn, m_maxDelaySpawn);
        StartSpawn();
    }

    private void StartSpawn()
    {
        m_canSpawn = true;
    }
    
    private void StopSpawn()
    {
        m_timer = 0;
        m_canSpawn = false;
    }

    private void Update()
    {
        if (!m_canSpawn) return;
        
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
