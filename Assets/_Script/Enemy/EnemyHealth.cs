using JustGame.Script.Manager;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private EnemyHealthBar m_healthBar;

    protected override void UpdateHealthUI()
    {
        m_healthBar.UpdateHealthBar(MathHelpers.Remap(m_curHealth,0,m_maxHealth,0,1));
        base.UpdateHealthUI();
    }
}
