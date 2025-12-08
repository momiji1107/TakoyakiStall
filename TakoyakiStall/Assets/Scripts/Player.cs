using UnityEngine;

public class Player : MonoBehaviour
{
    public enum ACTION
    {
        NOTHING,
        BATTER, //タネ
        TAKO, //たこ
        NEGI, //ねぎ
        BENI, //紅しょうが
        PICK, //ピック
        OFFER //提供する
    }
    
    private ACTION action;
    
    public ACTION Action { get => action; set => action = value; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action = ACTION.NOTHING;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
