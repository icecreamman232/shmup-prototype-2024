using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ResultScreenView : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_canvasGroup;

    private void Start()
    {
        Hide(isInstant:true);
    }

    public void Show()
    {
        m_canvasGroup.DOFade(1, 0.3f).SetUpdate(true).OnComplete(() =>
        {
            m_canvasGroup.interactable = true;
            m_canvasGroup.blocksRaycasts = true;
        });
        
    }

    public void Hide(bool isInstant = false)
    {
        if (isInstant)
        {
            m_canvasGroup.alpha = 0;
        }
        else
        {
            m_canvasGroup.DOFade(0, 0.3f).SetUpdate(true).OnComplete(() =>
            {
                m_canvasGroup.interactable = false;
                m_canvasGroup.blocksRaycasts = false;
            });
        }
    }
}
