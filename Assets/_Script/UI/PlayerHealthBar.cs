using JustGame.Scripts.ScriptableEvent;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private IntEvent m_playerHealthEvent;
    [SerializeField] private Image[] m_heartList;

    private void Start()
    {
        m_playerHealthEvent.AddListener(OnUpdatePlayerHealth);
    }

    private void OnDestroy()
    {
        m_playerHealthEvent.RemoveListener(OnUpdatePlayerHealth);
    }

    private void OnUpdatePlayerHealth(int curHealth)
    {
        for (int i = m_heartList.Length - 1; i >= curHealth; i--)
        {
            m_heartList[i].gameObject.SetActive(false);
        }
    }
}
