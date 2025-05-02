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

    protected abstract UIState GetUIstate(); // 만들겠다고 명시

    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIstate() == state);
    }
}
