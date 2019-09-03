using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] public GameObject Board;
    [SerializeField] public GameObject Bullets;
    [SerializeField] public GameObject Score;
    [SerializeField] public GameObject GameOver_Text;
    [SerializeField] public GameObject GameOver_Yes;
    [SerializeField] public GameObject GameOver_No;
    [SerializeField] public GameObject GameOverLine;
    private bool isContinue;
    private bool onceBoard;

    // Start is called before the first frame update
    void Start()
    {
        isContinue = false;
        onceBoard = false;
        Color text = GameOver_Text.GetComponent<Text>().color;
        GameOver_Text.GetComponent<Text>().color = new Vector4(text.r, text.g, text.b, 0.0f);
        GameOver_Yes.GetComponent<Text>().color = new Vector4(text.r, text.g, text.b, 0.0f);
        GameOver_No.GetComponent<Text>().color = new Vector4(text.r, text.g, text.b, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOverLine.GetComponent<GameOverLine>().IsDeadLine) { return; }

        if(!onceBoard)
        {
            // ボード初期化
            Board.GetComponent<Board>().Release();
            onceBoard = true;
        }

        Color text = GameOver_Text.GetComponent<Text>().color;
        GameOver_Text.GetComponent<Text>().color = new Vector4(text.r, text.g, text.b, 1.0f);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // yes
            isContinue = true;

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // no
            isContinue = false;
        }

        if(isContinue)
        {
            GameOver_Yes.GetComponent<Text>().color = new Vector4(0.0f, 0.7f, 1.0f, 1.0f);
            GameOver_No.GetComponent<Text>().color = new Vector4(text.r, text.g, text.b, 1.0f);
        }
        else
        {
            GameOver_Yes.GetComponent<Text>().color = new Vector4(text.r, text.g, text.b, 1.0f);
            GameOver_No.GetComponent<Text>().color = new Vector4(0.0f, 0.7f, 1.0f, 1.0f);
        }
        

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameOver_Text.GetComponent<Text>().color = new Vector4(text.r, text.g, text.b, 0.0f);
            GameOver_Yes.GetComponent<Text>().color = new Vector4(text.r, text.g, text.b, 0.0f);
            GameOver_No.GetComponent<Text>().color = new Vector4(text.r, text.g, text.b, 0.0f);

            // 決定
            if (isContinue)
            {
                // コンティニュー
                isContinue = false;

                // ハイスコア更新


                // ボード初期化
                Board.GetComponent<Board>().Initialize();
                onceBoard = false;

                // スコア初期化
                Score.GetComponent<Score>().Initialize();
                
                // 弾初期化
                Bullets.GetComponent<Bullets>().Initialize();

                // ゲームオーバーライン解除
                GameOverLine.GetComponent<GameOverLine>().IsDeadLine = false;

            }
            else
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
                // ゲーム終了
                UnityEngine.Application.Quit();
#endif

                //isContinue = false;
                //GameOverLine.GetComponent<GameOverLine>().IsDeadLine = false;

            }
        }
            
    }
}
