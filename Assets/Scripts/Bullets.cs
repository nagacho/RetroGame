using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private int kind;
    private float speed;
    private bool isShot;

    SpriteRenderer MainSpriteRenderer;
    public Sprite One;
    public Sprite Two;
    public Sprite Three;
    public Sprite Four;
    public Sprite Five;
    public Sprite Six;


    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        kind = 0;
        isShot = false;
        ChangeBullet(kind);
    }

    // Update is called once per frame
    void Update()
    {
        // 弾発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShot = true;
        }

        // 当たった時元に戻る
        if(transform.position.y >= 5.0f)
        {
            isShot = false;
            transform.position = new Vector3(transform.position.x, -3.0f, transform.position.z);
        }

        if (isShot)
        {
            MoveBullet(0.0f, 0.5f);
            return;
        }

        // 左に移動
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveBullet(-1.3f, 0.0f);
        }

        // 右に移動
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveBullet(1.3f, 0.0f);
        }

        // タイプチェンジ
        if (Input.GetKeyDown(KeyCode.F))
        {
            kind++;
            if(kind % 6 == 0)
            {
                kind = 0;
            }
            ChangeBullet(kind);

        }
        
    }

    //
    // 弾のチェンジ
    //
    private void ChangeBullet(int kind)
    {
       switch(kind)
        {
            case 0:
                MainSpriteRenderer.sprite = One;
                break;
            case 1:
                MainSpriteRenderer.sprite = Two;
                break;
            case 2:
                MainSpriteRenderer.sprite = Three;
                break;
            case 3:
                MainSpriteRenderer.sprite = Four;
                break;
            case 4:
                MainSpriteRenderer.sprite = Five;
                break;
            case 5:
                MainSpriteRenderer.sprite = Six;
                break;
            default:
                break;
        }
    }

    //
    // 移動
    //
    private void MoveBullet(float x, float y)
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x + x, pos.y + y, pos.z);
    }

}
