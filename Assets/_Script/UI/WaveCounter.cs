using JustGame.Scripts.ScriptableEvent;
using TMPro;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_waveTxt;
    [SerializeField] private IntEvent m_waveEvent;

    private void Awake()
    {
        m_waveEvent.AddListener(OnUpdateWaveCounter);
    }

    private void OnDestroy()
    {
        m_waveEvent.RemoveListener(OnUpdateWaveCounter);
    }

    private void OnUpdateWaveCounter(int waveNumber)
    {
        m_waveTxt.text = $"Wave {waveNumber}";
    }
}
