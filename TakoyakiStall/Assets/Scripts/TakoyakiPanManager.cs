using UnityEngine;

public class TakoyakiPanManager : MonoBehaviour
{
    [SerializeField] private float holewidth = 4.7f;
    [SerializeField] private float holeStartPos = 7.05f;
    [SerializeField] private int panWidth = 4;
    [SerializeField] private int panHeight = 4;
    private Vector3[] holes = new Vector3[16];
    public void OnClick()
    {
        Vector3 cursorPos = Input.mousePosition;
        Debug.Log(cursorPos);
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
