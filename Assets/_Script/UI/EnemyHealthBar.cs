using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image m_healthBar;
    
    public void UpdateHealthBar(float value)
    {
        m_healthBar.fillAmount = value;
    }
}
