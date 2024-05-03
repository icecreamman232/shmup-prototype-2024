using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image m_healthBar;
    [SerializeField] private CanvasGroup m_canvasGroup;

    public void Hide()
    {
        m_canvasGroup.alpha = 0;
    }
    
    public void UpdateHealthBar(float value)
    {
        if (m_canvasGroup == null)
        {
            return;
        }
        if (m_canvasGroup.alpha == 0)
        {
            m_canvasGroup.alpha = 1;
        }

        if (value <= 0)
        {
            m_canvasGroup.alpha = 0;
        }
        m_healthBar.fillAmount = value;
    }
}
