using System;
using JustGame.Scripts.ScriptableEvent;
using UnityEngine;

public class ResultScreenController : MonoBehaviour
{
    [SerializeField] private ResultScreenView m_view;
    [SerializeField] private ActionEvent m_timeOverEvent;
    
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
        m_view.Show();
    }
}
