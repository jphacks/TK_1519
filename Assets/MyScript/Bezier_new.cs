using UnityEngine;
using System.Collections;

public class Bezier_new : MonoBehaviour {

    public float wid_length,rad;
    public Vector3[] bezPos = new Vector3[24];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetPoint(Vector3 startPos, Vector3 endPos) {
        if (Mathf.Abs(startPos.y-endPos.y)<rad*2)
        {
            for(int i = 0; i < 24; i++)
            {
                bezPos[i] = startPos + ((endPos - startPos) * i / 24);
            }
        }
        else if (startPos.y > endPos.y)
        {
            bezPos[0] = startPos;
            bezPos[1] = startPos + Vector3.right * wid_length;
            for (int i = 2; i < 12; i++)
            {
                bezPos[i] = bezPos[1]
                            + Vector3.up * (rad * Mathf.Sin(Mathf.PI / 180 * (90 - (9 * (i - 1)))) - rad)
                            + Vector3.right * (rad * Mathf.Cos(Mathf.PI / 180 * (90 - (9 * (i - 1)))));
            }
            bezPos[12] = new Vector3(bezPos[11].x, endPos.y + rad, endPos.z);
            for (int i = 13; i < 23; i++)
            {
                bezPos[i] = bezPos[12]
                            + Vector3.up * (rad * Mathf.Sin(Mathf.PI / 180 * (180 + (9 * (i - 12)))))
                            + Vector3.right * (rad * Mathf.Cos(Mathf.PI / 180 * (180 + (9 * (i - 12)))) + rad);
            }
            bezPos[23] = endPos;
        }
        else
        {
            bezPos[0] = startPos;
            bezPos[1] = startPos + Vector3.right * wid_length;
            for (int i = 2; i < 12; i++)
            {
                bezPos[i] = bezPos[1]
                            + Vector3.up * (rad * Mathf.Sin(Mathf.PI / 180 * (270 + (9 * (i - 1)))) + rad)
                            + Vector3.right * (rad * Mathf.Cos(Mathf.PI / 180 * (270 + (9 * (i - 1)))));
            }
            bezPos[12] = new Vector3(bezPos[11].x, endPos.y - rad, endPos.z);
            for (int i = 13; i < 23; i++)
            {
                bezPos[i] = bezPos[12]
                            + Vector3.up * (rad * Mathf.Sin(Mathf.PI / 180 * (180 - (9 * (i - 12)))))
                            + Vector3.right * (rad * Mathf.Cos(Mathf.PI / 180 * (180 - (9 * (i - 12)))) + rad);
            }
            bezPos[23] = endPos;
        }
    }

    public Vector3 GetPoint(int t) {
        if (t >= 0) {
            if (t <= 24) {
                return bezPos[t];
            }
        }
        Debug.Log("somthingWrong");
        return new Vector3(100f,100f,100f);
    }
}
