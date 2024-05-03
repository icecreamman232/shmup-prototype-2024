using UnityEngine;

[CreateAssetMenu(menuName = "JustGame/Upgrade/Damage")]
public class UpgradeDamageData : UpgradeDataBase
{
    [SerializeField] private int m_damageIncreaseValue;

    public override void ApplyUpgrade(GameObject player)
    {
        var weapon = player.GetComponent<PlayerWeapon>();
        if (weapon != null)
        {
            weapon.IncreaseDamage(m_damageIncreaseValue);
        }
        
        base.ApplyUpgrade(player);
    }
}
