using UnityEngine;
using System.Collections;

public class lineMaker : MonoBehaviour {

    public LineRenderer line;

	// Use this for initialization
	void Start () {
        for (int i = -45; i < 45; i++)
        {
            LineRenderer lr = Instantiate(line);
            lr.transform.parent = GameObject.Find("lines").transform;
            lr.SetVertexCount(2);
            lr.SetPosition(0, new Vector3(0.89f * i - 0.025f, -10f, 5f));
            lr.SetPosition(1, new Vector3(0.89f * i - 0.025f, 10f, 5f));
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
