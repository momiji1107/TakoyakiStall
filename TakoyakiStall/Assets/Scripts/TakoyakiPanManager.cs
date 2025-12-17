using UnityEngine;

public class TakoyakiPanManager : MonoBehaviour
{
    [SerializeField] private float holewidth = 4.7f;
    [SerializeField] private float holeStartPos = 7.05f;
    [SerializeField] private int panWidth = 4;
    [SerializeField] private int panHeight = 4;
    private Vector2[] holes = new Vector2[16];
    private float distance = 0;
    private Vector2 selectHole = new Vector2();
    public void OnClick()
    {
        Vector3 cursorPos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(cursorPos);
        Vector3 localPos = transform.InverseTransformPoint(worldPos);

        foreach (Vector2 hole in holes)
        {
            distance = Vector2.Distance(new Vector2(hole.x, hole.y), localPos);
            if (distance < 2.0f)
            {
                selectHole = hole;
                break;
            }
        }
        Debug.Log("selectHole is " + selectHole);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int n = 0;
        float y = holeStartPos;
        for (int i = 0; i < panHeight; i++)
        {
            float x = -holeStartPos;
            for (int j = 0; j < panWidth; j++)
            {
                holes[n] = new Vector3(x, y, 0f);
                n++;
                x += holewidth;
            }
            y -= holewidth;
        }

        foreach (var hole in holes)
        {
            Debug.Log(hole);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
