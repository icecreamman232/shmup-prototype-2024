using System.Collections;
using JustGame.Scripts.Managers;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private KeyCode m_shootButton;
    [SerializeField] private Transform m_shootPivot;
    [SerializeField] private ObjectPooler m_bulletPooler;
    [SerializeField] private float m_delayBetweenTwoShot;
    [SerializeField] private int m_increaseDamage; //use for when player apply damage upgrade
    private bool m_isDelay;
    
    private void Update()
    {
        if (Input.GetKey(m_shootButton) && !m_isDelay)
        {
            Shoot();
        }
    }
    
        
    private void Shoot()
    {
        var bulletGO = m_bulletPooler.GetPooledGameObject();
        var bullet = bulletGO.GetComponent<PlayerBullet>();
        if (bullet == null) return;
        bullet.SpawnBullet(m_shootPivot.position, m_increaseDamage);
        
        StartCoroutine(OnDelayShoot());
    }

    private IEnumerator OnDelayShoot()
    {
        m_isDelay = true;
        yield return new WaitForSeconds(m_delayBetweenTwoShot);
        m_isDelay = false;
    }


    public void IncreaseDamage(int addValue)
    {
        m_increaseDamage += addValue;
    }
}
