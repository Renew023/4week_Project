using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour 
{
    protected MGUIManager MGUIManager;

    public virtual void Init(MGUIManager minigame)
    {
        this.MGUIManager = minigame;
    }

    protected abstract UIState GetUIstate(); // ����ڴٰ� ���

    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIstate() == state);
    }
}
