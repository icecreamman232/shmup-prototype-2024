using System;
using JustGame.Scripts.ScriptableEvent;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private FloatEvent m_xpUpdateEvent;
    [SerializeField] private IntEvent m_levelUpEvent;
    [SerializeField] private TextMeshProUGUI m_levelTxt;
    [SerializeField] private Image m_xpBar;

    private void Awake()
    {
        m_xpUpdateEvent.AddListener(OnUpdateXPBar);
        m_levelUpEvent.AddListener(OnLevelUp);
    }

    private void OnDestroy()
    {
        m_xpUpdateEvent.RemoveListener(OnUpdateXPBar);
        m_levelUpEvent.RemoveListener(OnLevelUp);
    }

    private void OnLevelUp(int level)
    {
        m_levelTxt.text = $"Level {level}";
    }

    private void OnUpdateXPBar(float value)
    {
        m_xpBar.fillAmount = value;
    }
}
