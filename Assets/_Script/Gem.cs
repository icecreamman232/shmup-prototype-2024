using System.Collections;
using System.Collections.Generic;
using JustGame.Scripts.ScriptableEvent;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private float m_limit;
    [SerializeField] private ActionEvent m_timeOverEvent;

    private void Start()
    {
        m_timeOverEvent.AddListener(OnTimeOver);
        
    }

    private void OnTimeOver()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        m_timeOverEvent.RemoveListener(OnTimeOver);
    }
    private void Update()
    {
        if (transform.position.y <= -m_limit)
        {
            Destroy(this.gameObject);
        }
    }
}
