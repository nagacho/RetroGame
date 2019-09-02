using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] public GameObject[] PieceData;
    private Vector3[] birthPos;
    private int MaxPieces = 60;
    private float interbal = 10.0f;
    private GameObject[] Pieces;
    private bool[] isPieces;


    // Start is called before the first frame update
    void Start()
    {
        Pieces = new GameObject[MaxPieces];
        isPieces = new bool[MaxPieces];
        birthPos = new Vector3[6];
        for(int i = 0; i < 6; i++)
        {
            birthPos[i] = new Vector3(-2.6f + (1.3f * i), 7.8f, 0.0f);
        }
        
        for (int i = 0; i < MaxPieces; i++)
        {
            isPieces[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        interbal -= Time.deltaTime;

        // パズルの移動と生成をする
        if (interbal <= 0.0f)
        {
            int birth = 0;
            interbal = 10.0f;
            for (int i = 0; i < MaxPieces; i++)
            {
                if (isPieces[i])
                {
                    Vector3 pos = Pieces[i].transform.position;
                    Pieces[i].transform.position = new Vector3(pos.x, pos.y - 1.3f, pos.z);
                }
                else if(birth != 6)
                {
                    int number = Random.Range(0, 6);
                    Pieces[i] = Instantiate(PieceData[number], birthPos[birth], Quaternion.identity);
                    isPieces[i] = true;
                    birth++;
                }

            }
        }
        
        
    }
}
