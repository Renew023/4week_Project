using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMove playerMove;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

    public void GetItem(GameObject item)
    {
        playerMove.SetItem(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
