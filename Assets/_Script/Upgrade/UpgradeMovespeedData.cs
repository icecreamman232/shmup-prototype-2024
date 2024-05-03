using JustGame.Script.Player;
using UnityEngine;

[CreateAssetMenu(menuName = "JustGame/Upgrade/Movespeed")]
public class UpgradeMovespeedData : UpgradeDataBase
{
    [SerializeField] private int m_moveSpeedIncreaseValue;

    public override void ApplyUpgrade(GameObject player)
    {
        var movement = player.GetComponent<PlayerMovement>();

        if (movement != null)
        {
            movement.IncreaseMaxSpeed(m_moveSpeedIncreaseValue);
        }
        base.ApplyUpgrade(player);
    }
}
