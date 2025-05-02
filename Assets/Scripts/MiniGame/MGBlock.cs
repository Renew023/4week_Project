using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGBlock : MonoBehaviour
{
    [SerializeField] private Transform top;
	[SerializeField] private Transform bottom;
    MGGameManager gameManager;

    private float minSize = 2f;
    private float maxSize = 3f;

    private float minDistance = 3f;
    private float maxDistance = 4f;
	// Start is called before the first frame update
	void Awake()
    {
        gameManager = MGGameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 SetBlock(Vector3 lastPosition)
    {
        float pos = Random.Range(minSize, maxSize);
        float halfpos = pos / 2;

        top.localPosition = new Vector3(0, halfpos);
        bottom.localPosition = new Vector3(0, -halfpos);

        float distance = Random.Range(minDistance, maxDistance);
        Vector3 placePosition = lastPosition + new Vector3(distance, 0);
        placePosition.y = Random.Range(-2f, 2f);

        transform.position = placePosition;


		return placePosition;
	}

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.curScore++;
        }
    }
}
