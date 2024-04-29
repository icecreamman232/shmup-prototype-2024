using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image m_healthBar;
    [SerializeField] private CanvasGroup m_canvasGroup;
    
    public void UpdateHealthBar(float value)
    {
        if (m_canvasGroup.alpha == 0)
        {
            m_canvasGroup.alpha = 1;
        }
        m_healthBar.fillAmount = value;
    }
}
