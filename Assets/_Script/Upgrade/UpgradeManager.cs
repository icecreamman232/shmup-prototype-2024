using System;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpgradeManager : MMSingleton<UpgradeManager>
{
    [SerializeField] private UpgradeDataBase[] m_upgradeList;
    [SerializeField] private List<UpgradeDataBase> m_chosenList;

    private void Start()
    {
        m_chosenList = new List<UpgradeDataBase>();
    }

    public List<UpgradeDataBase> GetRandomUpgradeList(int number)
    {
        var result = new List<UpgradeDataBase>();
        for (int i = 0; i < number; i++)
        {
            var index = Random.Range(0, m_upgradeList.Length);
            result.Add(Instantiate(m_upgradeList[index]));
        }

        return result;
    }

    public void AddChosenUpgrade(UpgradeDataBase upgrade)
    {
        m_chosenList.Add(upgrade);
    }
}
