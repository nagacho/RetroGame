﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] public GameObject mTapEffect;
    [SerializeField] public GameObject[] PieceData;
    [SerializeField] public GameObject Bullet;
    [SerializeField] public GameObject Score;
    [SerializeField] public GameObject GameOverLine;
    [SerializeField] public GameObject Level;
    private Vector3[] birthPos;
    private int MaxPieces = 60;
    private float interbal;
    private int tempo;
    private float interbalCounter;
    private GameObject[] Pieces;
    private bool[] isPieces;
    private int[] kind;


    // Start is called before the first frame update
    void Start()
    {
        Pieces = new GameObject[MaxPieces];
        isPieces = new bool[MaxPieces];
        kind = new int[MaxPieces];
        birthPos = new Vector3[6];
        tempo = 1;
        interbal = 8.0f;
        interbalCounter = interbal;
        for(int i = 0; i < 6; i++)
        {
            birthPos[i] = new Vector3(-2.6f + (1.3f * i), 7.8f, 0.0f);
        }
        
        for (int i = 0; i < MaxPieces; i++)
        {
            isPieces[i] = false;
            kind[i] = -1;
        }

        for(int i = 0; i < 6; i++)
        {
            int number = Random.Range(0, 6);
            Pieces[i] = Instantiate(PieceData[number], birthPos[i], Quaternion.identity);
            isPieces[i] = true;
            kind[i] = number;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオーバー時更新を停止
        if(GameOverLine.GetComponent<GameOverLine>().IsDeadLine){ return; }

        interbalCounter -= Time.deltaTime;

        // パズルの移動と生成をする
        if (interbalCounter <= 0.0f)
        {
            int birth = 0;
            interbalCounter = interbal;
            for (int i = 0; i < MaxPieces; i++)
            {
                if (isPieces[i])
                {
                    Vector3 pos = Pieces[i].transform.position;
                    Pieces[i].transform.position = new Vector3(pos.x, pos.y - 1.3f, pos.z);
                }
                else if (birth != 6)
                {
                    int number = Random.Range(0, 6);
                    Pieces[i] = Instantiate(PieceData[number], birthPos[birth], Quaternion.identity);
                    isPieces[i] = true;
                    kind[i] = number;
                    birth++;
                }
            }
        }

        // 削除
        for (int i = 0; i < MaxPieces; i++)
        {
            if (isPieces[i])
            {
                if (Pieces[i].GetComponent<Piece>().Hit)
                {
                    // 同じ種類なら削除
                    if(Bullet.GetComponent<Bullets>().Kind == kind[i])
                    {
                        // スコア加算
                        Score.GetComponent<Score>().ScoreNum += 10;

                        // 役に追加

                        // 削除
                        Object.Instantiate(mTapEffect, Pieces[i].transform.position, Quaternion.identity);

                        Destroy(Pieces[i]);
                        isPieces[i] = false;
                        kind[i] = -1;
                    }
                    else
                    {
                        Pieces[i].GetComponent<Piece>().Hit = false;
                    }
                }
            }
        }

        // テンポを早く
        if(Score.GetComponent<Score>().ScoreNum >= (120 * tempo))
        {
            if(tempo > 9) { return; }
            tempo++;
            interbal -= 0.5f;
        }

        if (tempo >= 9)
        {
            Level.GetComponent<Text>().text = "Level  Max";
        }
        else
        {
            Level.GetComponent<Text>().text = "Level  " + tempo;
        }

    }

    public void Release()
    {
        for (int i = 0; i < MaxPieces; i++)
        {
            Destroy(Pieces[i]);
            isPieces[i] = false;
            kind[i] = -1;
        }
    }

    public void Initialize()
    {
        for (int i = 0; i < 6; i++)
        {
            int number = Random.Range(0, 6);
            Pieces[i] = Instantiate(PieceData[number], birthPos[i], Quaternion.identity);
            isPieces[i] = true;
            kind[i] = number;
            tempo = 1;
            interbal = 8.0f;
            interbalCounter = interbal;
            Level.GetComponent<Text>().text = "Level  " + tempo;
        }
    }

}
