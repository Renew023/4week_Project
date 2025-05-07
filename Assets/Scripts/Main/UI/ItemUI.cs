using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> ItemList = new List<GameObject>();
    [SerializeField] private Transform pos;

    void Awake()
    {
        foreach (var item in ItemList)
        {
            Instantiate(item, pos.position, Quaternion.identity, pos);
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
