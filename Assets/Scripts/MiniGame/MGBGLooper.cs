using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGBGLooper : MonoBehaviour
{
    private int numBgCount = 5;
    private int blockCount = 5;
    private int curBlockCount = 0;
    [SerializeField] private Vector3 blockLastPosition = new Vector3(18, 0, 0);
    [SerializeField] private MGBlock block;
    private MGBlock[] blocks;

	// Start is called before the first frame update

	void Start()
    {
		blocks = new MGBlock[numBgCount];
        GameObject parent;
        parent = GameObject.FindWithTag("Parent");

		for (int i = 0; i < blockCount; i++)
        {
                blocks[i] = Instantiate(block, this.transform.position, Quaternion.identity, parent.transform);
                blockLastPosition = blocks[i].SetBlock(blockLastPosition);
		}
       
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerEnter2D(Collider2D collider)
	{
        if (collider.gameObject.CompareTag("BackGround"))
        {
			float widthSize = collider.bounds.size.x;
            Vector3 pos = collider.transform.position;
            pos.x += widthSize*numBgCount;
            collider.transform.position = pos;
        }
        if (collider.gameObject.CompareTag("Block"))
        {
            blockLastPosition = blocks[curBlockCount].SetBlock(blockLastPosition);
			curBlockCount++;
            if(curBlockCount >= blockCount)
			{
				curBlockCount = 0;
			}
		}
	}
}
