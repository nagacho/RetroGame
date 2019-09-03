using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    public int ScoreNum
    {
        get { return score; }
        set { score = value; }
    }
    private Text text;

    private int hiScore;
    [SerializeField] public GameObject HiScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        hiScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Compare();

        text = GetComponent<Text>();
        text.text = "Score\n" + score;

        HiScore.GetComponent<Text>().text = "HiScore\n" + hiScore;
    }

    public void Initialize()
    {
        score = 0;
    }

    private void Compare()
    {
        if(hiScore <= score)
        {
            hiScore = score;
        }
    }
}
