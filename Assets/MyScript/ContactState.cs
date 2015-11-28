using UnityEngine;
using UnityEditor;
using System.Collections;

public class ContactState : MonoBehaviour {

    public int max;
    public bool linked;
    public int outputID;

    public Bezier myBezier;
    public LineRenderer lr;

    public Vector3[] bezPos = new Vector3[2];

    public GameObject LinkedTo;

    private int all_id,scene_id;

    // Use this for initialization
    void Start () {
        linked = false;
	}
	
	// Update is called once per frame
	void Update () {

        all_id = this.transform.parent.GetComponent<NodeParentState>().all_id;
        scene_id = this.transform.parent.GetComponent<NodeParentState>().scene_id;

        if (linked) { 
            Vector3 LinkedToPos = LinkedTo.transform.position;
            DrawNodeCurve(this.transform.position, LinkedToPos);
        }
	}

    void DrawNodeCurve(Vector3 startPos, Vector3 endPos)
    {
        Vector3 startTan = startPos + Vector3.right * 5;
        Vector3 endTan = endPos + Vector3.left * 5;

        myBezier = new Bezier(startPos, startTan, endTan, endPos);

        int count = 51;
        lr.SetVertexCount(count);
        for (int i = 0; i < count; i++)
        {
            lr.SetPosition(i, myBezier.GetPointAtTime(i * 0.02f));
        }
        //Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.cyan, null, 3);
    }
}
