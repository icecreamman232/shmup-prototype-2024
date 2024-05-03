using JustGame.Script.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private HealthEvent m_playerHealthEvent;
    [SerializeField] private TextMeshProUGUI m_healthTxt;
    [SerializeField] private Image m_healthBar;

    private void Awake()
    {
        m_playerHealthEvent.AddListener(OnUpdatePlayerHealth);
    }

    private void OnDestroy()
    {
        m_playerHealthEvent.RemoveListener(OnUpdatePlayerHealth);
    }

    private void OnUpdatePlayerHealth(int cur, int max)
    {
        m_healthBar.fillAmount = MathHelpers.Remap(cur,0,max,0,1);
        m_healthTxt.text = $"{cur}/{max}";
    }
}
