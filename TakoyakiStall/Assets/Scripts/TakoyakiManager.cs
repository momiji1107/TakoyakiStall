using System;
using System.Collections;
using UnityEngine;

public class TakoyakiManager : MonoBehaviour
{
    public enum TAKOYAKI_STATE
    {
        NOTHING = 0,
        BATTER, //タネ
        TAKO, //タコ入り
        TURNOVER, //ひっくり返す
        WAITING, //焼けるまで待機
        DONE, //焼けた
        BURNT //焦げた
    }
    
    [SerializeField] private Player player;
    [SerializeField] private IngredientManager ingredientManager;
    
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
        renderer.enabled = false;
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
                if (player.Action == Player.ACTION.BATTER)
                {
                    curState = TAKOYAKI_STATE.BATTER;
                    renderer.enabled = true;
                    renderer.sprite = sprites[0];
                }

                break;
            case TAKOYAKI_STATE.BATTER:
                if (player.Action == Player.ACTION.TAKO)
                {
                    curState = TAKOYAKI_STATE.TAKO;
                    renderer.sprite = sprites[1];
                }

                break;
            case TAKOYAKI_STATE.TAKO:
                if (player.Action == Player.ACTION.PICK)
                {
                    curState = TAKOYAKI_STATE.TURNOVER;
                    StartCoroutine("TurnOver");
                }
                else AddIngredient(player.Action);

                break;
            case TAKOYAKI_STATE.TURNOVER:
                break;
            case TAKOYAKI_STATE.WAITING:
                break;
            case TAKOYAKI_STATE.DONE:
                if (player.Action == Player.ACTION.PICK)
                {
                    curState = TAKOYAKI_STATE.NOTHING;
                    renderer.enabled = false;
                }

                break;
            case TAKOYAKI_STATE.BURNT:
                if (player.Action == Player.ACTION.PICK)
                {
                    curState = TAKOYAKI_STATE.NOTHING;
                    renderer.enabled = false;
                }

                break;
            default:
                break;
        }
        Debug.Log(curState);
    }

    IEnumerator TurnOver()
    {
        foreach (Transform ingredients in transform)
        {
            GameObject.Destroy(ingredients.gameObject);
        }
        renderer.sprite = sprites[2];
        yield return new WaitForSeconds(0.3f);
        curState = TAKOYAKI_STATE.WAITING;
        renderer.sprite = sprites[3];
        Debug.Log(curState);
    }

    private void AddIngredient(Player.ACTION action)
    {
        switch(action)
        {
            case Player.ACTION.NEGI:
                ingredientManager.AddIngredient("NEGI");
                break;
            case Player.ACTION.BENI:
                ingredientManager.AddIngredient("BENI");
                break;
            default:
                break;
        }
    }
}
