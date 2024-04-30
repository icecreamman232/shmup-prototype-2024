using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float m_limit;
    private void Update()
    {
        if (transform.position.y <= -m_limit)
        {
            Destroy(this.gameObject);
        }
    }
}
