using UnityEngine;

using System.Collections;

public class ContactState : MonoBehaviour {

    public int max;
    public bool linked;
    public int outputID;

    public Bezier_new myBezier;
    public LineRenderer lr;

    public Vector3[] bezPos = new Vector3[2];

    public GameObject LinkedTo,bezObj;

    private int all_id,scene_id;

    // Use this for initialization
    void Start () {
        bezObj = GameObject.Find("BezRet");
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
       /* Vector3 startTan = startPos + Vector3.right * 2;
        Vector3 endTan = endPos + Vector3.left * 2;*/

        myBezier = bezObj.GetComponent<Bezier_new>();
        myBezier.SetPoint(startPos, endPos);

        int count = 24;
        lr.SetVertexCount(count);
        lr.SetWidth(0.04f, 0.04f);
        for (int i = 0; i < count; i++)
        {
            lr.SetPosition(i, myBezier.GetPoint(i));
        }
        //Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.cyan, null, 3);
    }
}
