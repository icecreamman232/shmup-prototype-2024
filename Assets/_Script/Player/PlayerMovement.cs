using UnityEngine;

namespace JustGame.Script.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float m_limit;
        [SerializeField] private float m_moveSpeed;
        private Vector2 m_direction;
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                m_direction = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                m_direction = Vector3.right;
            }
            else
            {
                m_direction = Vector3.zero;
            }

            
            transform.Translate(m_direction * (Time.deltaTime * m_moveSpeed));
            
            if (Mathf.Abs(transform.position.x) >= m_limit)
            {
                var pos = transform.position;
                pos.x = pos.x > 0 ? m_limit : -m_limit;
                transform.position = pos;
            }
        }

        public void IncreaseMaxSpeed(int addValue)
        {
            m_moveSpeed += addValue;
        }
    }
}

