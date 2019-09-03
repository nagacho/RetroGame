using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] public GameObject GameOverLine;

    private int kind;
    public int Kind
    {
        get { return kind; }
        set { kind = value; }
    }
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
        // ゲームオーバー時更新を停止
        if (GameOverLine.GetComponent<GameOverLine>().IsDeadLine) { return; }

        // 弾発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShot = true;
        }

        // 上限制御
        if (transform.position.y > 7.8f)
        {
            isShot = false;
            transform.position = new Vector3(transform.position.x, -3.9f, transform.position.z);
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

        // 左右制御
        if(transform.position.x > 3.9f || transform.position.x < -2.6f)
        {
            transform.position = pos;
        }
    }

    //
    // 弾を元に戻す
    //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameOverLine")) { return; }
        isShot = false;
        transform.position = new Vector3(transform.position.x, -3.9f, transform.position.z);
    }

    public void Initialize()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        kind = 0;
        isShot = false;
        ChangeBullet(kind);
        transform.position = new Vector3(transform.position.x, -3.9f, transform.position.z);
    }

}
