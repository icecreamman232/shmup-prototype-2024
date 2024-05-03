using System;
using System.Collections;
using JustGame.Script.Manager;
using JustGame.Scripts.ScriptableEvent;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

public class GameManager : MMSingleton<GameManager>
{
    [SerializeField] private GameEventSO m_gameEventSO;
    [Header("Player")] 
    [SerializeField] private GameObject m_playerPrefab;
    [SerializeField] private Vector3 m_spawnPos;
    private GameObject m_player;
    
    [Header("Wave")]
    [SerializeField] private int m_initWave;
    [SerializeField] private int m_curWave;
    [SerializeField] private IntEvent m_waveEvent;

    [Header("Time")] 
    [SerializeField] private int m_waveMinute;
    [SerializeField] private int m_waveSeconds;
    [SerializeField] private TimeManager m_timeManager;

    [Header("XP")]
    [SerializeField] private IntEvent m_levelUpEvent;
    [SerializeField] private IntEvent m_xpEarnEvent;
    [SerializeField] private FloatEvent m_updateXPBarEvent;
    [SerializeField] private int m_maxXP;
    [SerializeField] private int m_curXP;
    [SerializeField] private int m_curLevel;
    [SerializeField] private int m_initLevel;
    //how many player level up during a run
    [SerializeField] private int m_levelUpCounter; 
    [SerializeField] private MMF_Player m_levelUpSFX;

    [Header("Dragon")] 
    [SerializeField] private DragonData m_curDragonData;

    private void Start()
    {
        m_xpEarnEvent.AddListener(OnEarnXP);
        m_gameEventSO.AddListener(OnUpdateGameEvent);
        m_curLevel = m_initLevel;
        m_levelUpEvent.Raise(m_curLevel); //send level info to HUD
        
        StartCoroutine(LoadLevel());
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    
    private IEnumerator LoadLevel()
    {

        if (m_player != null)
        {
            Destroy(m_player.gameObject);
        }

        yield return new WaitForSecondsRealtime(0.3f);
        
        //Spawn player
        m_player = Instantiate(m_playerPrefab, m_spawnPos, Quaternion.identity);
        
        //TODO: Play player respawn anim;
        yield return new WaitForSecondsRealtime(0.3f);
        
        UpgradeManager.Instance.ApplyUpgrades(m_player);
        m_gameEventSO.Raise(GameEvent.RESPAWN_PLAYER);
        
        
        m_timeManager.SetTime(m_waveMinute, m_waveSeconds);
        GetDragonInfo();
        //Spawn wave
        NextWave();
        
        UnPauseGame();
    }
    
    private void OnUpdateGameEvent(GameEvent incomingEvent)
    {
        switch (incomingEvent)
        {
            case GameEvent.RESPAWN_PLAYER:
                break;
            case GameEvent.TIME_OVER:
                PauseGame();
                break;
        }
    }

    private void OnDestroy()
    {
        m_xpEarnEvent.RemoveListener(OnEarnXP);
    }

    private void OnEarnXP(int xp)
    {
        m_curXP++;
        if (m_curXP >= m_maxXP)
        {
            m_curLevel++;
            m_levelUpCounter++;
            m_levelUpEvent.Raise(m_curLevel);
            m_levelUpSFX.PlayFeedbacks();
            GetDragonInfo();
        }
        m_updateXPBarEvent.Raise(MathHelpers.Remap(m_curXP,0,m_maxXP,0,1));
    }

    private void GetDragonInfo()
    {
        m_curXP = 0;
        m_maxXP = m_curDragonData.GetMaxXPAtLvl(m_curLevel);
        m_updateXPBarEvent.Raise(MathHelpers.Remap(m_curXP,0,m_maxXP,0,1));
    }

    public void NextWave()
    {
        m_curWave++;
        m_levelUpCounter = 0;
        //Update wave counter UI
        m_waveEvent.Raise(m_curWave);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}
