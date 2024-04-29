using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float m_limit;
    [SerializeField] private float m_moveSpeed;

    private void Update()
    {
        transform.Translate(Vector2.down * (Time.deltaTime*m_moveSpeed));
        if (transform.position.y <= -m_limit)
        {
            Destroy(this.gameObject);
        }
    }
}
