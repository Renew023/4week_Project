using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private Button selectItem;

    void Awake()
    {
        selectItem.onClick.AddListener(Select);
    }
    void Start()
    {
        
    }

    void Select()
    {
        GameManager.instance.GetItem(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
