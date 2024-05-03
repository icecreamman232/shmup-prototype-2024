using System;
using UnityEngine;

public class UpgradeScreenController : MonoBehaviour
{
    [SerializeField] private ResultScreenController m_resultScreenController;
    [SerializeField] private UpgradeButton[] m_buttons;

    public void ShowUpgrade()
    {
        var upgradeList = UpgradeManager.Instance.GetRandomUpgradeList(3);
        for (int i = 0; i < m_buttons.Length; i++)
        {
            m_buttons[i].InitButton(upgradeList[i]);
        }
    }
    
    public void OnChooseUpgrade(UpgradeButton button)
    {
        UpgradeManager.Instance.AddChosenUpgrade(button.Upgrade);
        m_resultScreenController.Hide();
        GameManager.Instance.NextWave();
    }
}
