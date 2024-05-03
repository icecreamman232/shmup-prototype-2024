using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : Button
{
    [SerializeField] private TextMeshProUGUI m_placeholderText;
    [SerializeField] private UpgradeDataBase m_upgrade;

    public UpgradeDataBase Upgrade => m_upgrade;
    
    public void InitButton(UpgradeDataBase upgrade)
    {
        m_upgrade = upgrade;
        m_placeholderText.text = m_upgrade.UpgradeID;
    }
}
