using UnityEngine;

[CreateAssetMenu(menuName = "JustGame/Upgrade/Health")]
public class UpgradeHealthData : UpgradeDataBase
{
    [SerializeField] private int m_healthIncreaseValue;

    public override void ApplyUpgrade(GameObject player)
    {
        var health = player.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.IncreaseMaxHealth(m_healthIncreaseValue);
        }
        base.ApplyUpgrade(player);
    }
}
