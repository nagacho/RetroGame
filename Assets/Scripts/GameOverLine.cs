using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLine : MonoBehaviour
{

    private bool isDeadLine;
    public bool IsDeadLine
    {
        get { return isDeadLine; }
        set { isDeadLine = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        isDeadLine = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    // ゲームオーバー
    // 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullets")) { return; }
        Debug.Log("ゲームオーバー");
        isDeadLine = true;
    }
}
