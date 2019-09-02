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

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text = GetComponent<Text>();
        text.text = "Score\n" + score;
    }
}
