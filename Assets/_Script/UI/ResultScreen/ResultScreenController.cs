using System;
using System.Collections;
using JustGame.Scripts.ScriptableEvent;
using UnityEngine;

public class ResultScreenController : MonoBehaviour
{
    [SerializeField] private ResultScreenView m_view;
    [SerializeField] private ActionEvent m_timeOverEvent;

    [SerializeField] private UpgradeScreenController m_upgradeScreenController;
    private void Start()
    {
        m_timeOverEvent.AddListener(OnTimeOver);
    }

    private void OnDestroy()
    {
        m_timeOverEvent.RemoveListener(OnTimeOver);
    }

    private void OnTimeOver()
    {
        StartCoroutine(ShowScreen());
    }

    private IEnumerator ShowScreen()
    {
        yield return new WaitForSecondsRealtime(1f);
        m_view.Show();
        m_upgradeScreenController.ShowUpgrade();
    }
}
