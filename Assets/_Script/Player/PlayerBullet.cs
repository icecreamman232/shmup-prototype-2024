using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_limit;
    
    private bool m_canUpdate;
    
    private void OnDisable()
    {
        m_canUpdate = false;
    }

    public void SpawnBullet(Vector2 position)
    {
        transform.position = position;
        m_canUpdate = true;
    }

    private void Update()
    {
        if (!m_canUpdate) return;
        
        transform.Translate(Vector2.up * (Time.deltaTime * m_moveSpeed));

        if (transform.position.y >= m_limit)
        {
            this.gameObject.SetActive(false);
        }
    }
}
