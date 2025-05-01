using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePump : MonoBehaviour
{
    // Start is called before the first frame update
    int rand = 0;
    [SerializeField] List<GameObject> objectPool = new List<GameObject>();
    [SerializeField] private GameObject monster;
    int index = 0;

	void Awake()
    {
        StartCoroutine("CreateMonster");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isHaveObject(int line)
    {
        if (objectPool.Count <= index)
        {
            objectPool.Add(
                Instantiate(
                    monster,
                    transform.position,
                    Quaternion.identity)
                );
        }
        else
        {
            objectPool[objectPool.Count-index].SetActive(true);
            objectPool[objectPool.Count-index].transform.position = gameObject.transform.position + new Vector3(line, 15, 0);
            index -= 1;
        }

    }

    IEnumerable CreateMonster()
    {
        Debug.Log("확인이요");
		rand = Random.Range(0, 5);
        isHaveObject(rand);
        MoveMonster(objectPool[objectPool.Count-index]);
        yield return new WaitForSeconds(2.0f);
	}

    IEnumerable MoveMonster(GameObject objectPool)
    {
        float speed = 0.5f;
        objectPool.transform.position += Vector3.down * speed;
        index += 1;
        yield break;
    }
}
