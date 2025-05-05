using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MGBaseUI : MonoBehaviour
{
    protected MGUIManager uiManager;
    
    public virtual void Init(MGUIManager uiManager)
    {
        this.uiManager = uiManager;
    }
    
    protected abstract MGUIState GetUIState();

    public void SetActive(MGUIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }

}
