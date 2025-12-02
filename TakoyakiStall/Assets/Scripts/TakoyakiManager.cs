using System;
using UnityEngine;

public class TakoyakiManager : MonoBehaviour
{
    public enum TAKOYAKI_STATE
    {
        NOTHING,
        BATTAR, //タネ
        TAKO, //タコ入り
        TURNOVER, //ひっくり返す
        WAITING, //焼けるまで待機
        DONE, //焼けた
        BURNT //焦げた
    }
    
    public Sprite[] sprites;
    SpriteRenderer renderer;

    private TAKOYAKI_STATE curState;
    private float doneTime = 10.0f; //焼けるまでの時間
    private float burntTime = 15.0f; //焦げるまでの時間
    private float cookTimer = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curState = TAKOYAKI_STATE.NOTHING;
        Debug.Log(curState);
        
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       if(curState == TAKOYAKI_STATE.WAITING || curState == TAKOYAKI_STATE.DONE) cookTimer += Time.deltaTime;
       else cookTimer = 0.0f;

        if (cookTimer >= doneTime && cookTimer < burntTime)
        {
            curState = TAKOYAKI_STATE.DONE;
            renderer.sprite = sprites[4];
            Debug.Log(curState);
        }
        if (cookTimer >= burntTime)
        {
            curState = TAKOYAKI_STATE.BURNT;
            renderer.sprite = sprites[5];
            Debug.Log(curState);
        }
    }

    //画像がクリックされたとき
    public void OnClick()
    {
        switch (curState)
        {
            case TAKOYAKI_STATE.NOTHING:
                curState = TAKOYAKI_STATE.BATTAR;
                renderer.enabled = true;
                renderer.sprite = sprites[0];
                break;
            case TAKOYAKI_STATE.BATTAR:
                curState = TAKOYAKI_STATE.TAKO;
                renderer.sprite = sprites[1];
                break;
            case TAKOYAKI_STATE.TAKO:
                curState = TAKOYAKI_STATE.TURNOVER;
                renderer.sprite = sprites[2];
                break;
            case TAKOYAKI_STATE.TURNOVER:
                curState = TAKOYAKI_STATE.WAITING;
                renderer.sprite = sprites[3];
                break;
            case TAKOYAKI_STATE.WAITING:
                break;
            case TAKOYAKI_STATE.DONE:
                curState = TAKOYAKI_STATE.NOTHING;
                renderer.enabled = false;
                break;
            case TAKOYAKI_STATE.BURNT:
                curState = TAKOYAKI_STATE.NOTHING;
                renderer.enabled = false;
                break;
            default:
                break;
        }
        Debug.Log(curState);
    }
}
