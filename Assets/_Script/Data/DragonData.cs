using System;
using UnityEngine;

[CreateAssetMenu(menuName = "JustGame/Dragon Data")]
public class DragonData : ScriptableObject
{
    [SerializeField] private string DragonID;
    [SerializeField] private DragonXP[] Level;

    public int GetMaxXPAtLvl(int level)
    {
        return Level[level - 1].MaxXP;
    }
}

[Serializable]
public struct DragonXP
{
    public int Level;
    public int MaxXP;
}
