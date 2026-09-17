using UnityEngine;

public class TakoyakiPanManager : MonoBehaviour
{
    [SerializeField] private float holewidth = 4.7f;
    [SerializeField] private float holeStartPos = 7.05f;
    [SerializeField] private int panWidth = 4;
    [SerializeField] private int panHeight = 4;
    [SerializeField] private GameObject takoyakiPrefab;
    [SerializeField] private Player player;

    public struct Hole
    {
        public Vector2 pos;
        public bool InUse;
    }

    private int holeNum;
    private Hole[] holes;
    private float distance = 0;
    private Vector2 selectHolePos = new Vector2();

    private GameObject takoyaki;
    public void OnClick()
    {
        if (player.Action == Player.ACTION.BATTER)
        {
            Vector3 cursorPos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(cursorPos);
            Vector3 localPos = transform.InverseTransformPoint(worldPos);

            for (int i = 0; i < holes.Length; i++)
            {
                distance = Vector2.Distance(new Vector2(holes[i].pos.x, holes[i].pos.y), localPos);
                if (distance < 2.0f && !holes[i].InUse)
                {
                    Hole hole = holes[i];
                    hole.InUse = true;
                    holes[i] = hole;
                    selectHolePos = holes[i].pos;
                    Debug.Log("selectHole is " + selectHolePos);
                    
                    takoyaki = Instantiate(takoyakiPrefab, transform);
                    takoyaki.transform.localPosition = new Vector3(selectHolePos.x, selectHolePos.y, 0f);
                    takoyaki.GetComponent<TakoyakiManager>().SetHole(i);
                    break;
                }
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        holeNum = panWidth * panHeight;
        holes = new Hole[holeNum];
        
        int n = 0;
        float y = holeStartPos;
        for (int i = 0; i < panHeight; i++)
        {
            float x = -holeStartPos;
            for (int j = 0; j < panWidth; j++)
            {
                holes[n].pos = new Vector2(x, y);
                holes[n].InUse = false;
                n++;
                x += holewidth;
            }
            y -= holewidth;
        }
        
    }

    public void ReleaseHole(int num)
    {
        Debug.Log("ReleaseHole");
        Hole hole = holes[num];
        hole.InUse = false;
        holes[num] = hole;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
