using UnityEngine;
using UnityEditor;

public class tapCheck : MonoBehaviour {

    private bool NodeMoveMode, SceneMoveMode, NodeJoinMode;
    private Vector2 mousePos_begin, mousePos_now;
    private Vector2 objPos_begin;
    private GameObject currentOBJ;

    public GameObject MainCam;

    public Bezier myBezier;
    public LineRenderer lr;

	// Use this for initialization
	void Start () {
        NodeMoveMode = SceneMoveMode = NodeJoinMode = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

            if (aCollider2d)
            {
                GameObject obj = aCollider2d.transform.gameObject;
                Debug.Log(obj.name);
                currentOBJ = obj;
                if (obj.name == "contact_O"){
                    NodeJoinMode = true;
                    lr.enabled = true;
                }else{
                    NodeMoveMode = true;
                    objPos_begin = obj.transform.position;
                    mousePos_begin = Input.mousePosition;
                }
            }else{
                currentOBJ = MainCam;
                objPos_begin = MainCam.transform.position;
                mousePos_begin = Input.mousePosition;
                SceneMoveMode = true;
            }
        }else if (Input.GetMouseButtonUp(0)){
            if (NodeJoinMode)
            {
                Vector3 aUpPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D bCollider2d = Physics2D.OverlapPoint(aUpPoint);
                if (bCollider2d)
                {
                    GameObject upObj = bCollider2d.transform.gameObject;
                    if (CanContact(currentOBJ, upObj) && upObj.name == "contact_I")
                    {
                        currentOBJ.GetComponent<ContactState>().linked = true;
                        currentOBJ.GetComponent<ContactState>().LinkedTo = upObj;
                    }
                }
            }
            else if (NodeMoveMode) {

            }
            NodeMoveMode = SceneMoveMode = NodeJoinMode = false;
            lr.enabled = false;
        }

        if (NodeMoveMode) {
            mousePos_now = Input.mousePosition;
            Vector2 worldPos_now = cameraToWolid(mousePos_now);
            Vector2 worldPos_begin = cameraToWolid(mousePos_begin);
            currentOBJ.transform.position = objPos_begin + (worldPos_now - worldPos_begin);
        }
        if (NodeJoinMode){
            DrawNodeCurve(currentOBJ.transform.position, cameraToWolid(Input.mousePosition));
        }
        if (SceneMoveMode) {
            mousePos_now = Input.mousePosition;
            Vector2 worldPos_now = cameraToWolid(mousePos_now);
            Vector2 worldPos_begin = cameraToWolid(mousePos_begin);
            currentOBJ.transform.position = objPos_begin - (worldPos_now - worldPos_begin);
            currentOBJ.transform.position = new Vector3(currentOBJ.transform.position.x,currentOBJ.transform.position.y,-10f);
        }

    }

    Vector2 cameraToWolid(Vector2 cameraVec) {

        Vector3 tmpPosition = new Vector3(cameraVec.x, cameraVec.y, 0f);
        // Z軸修正
        tmpPosition.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(tmpPosition);

        return new Vector2(screenToWorldPointPosition.x, screenToWorldPointPosition.y);
    }

    bool CanContact(GameObject outputObj, GameObject inputObj) {

        for (int i = 0; i < outputObj.GetComponent<ContactState>().max; i++) {

        }
        return true;
    }

    void DrawNodeCurve(Vector3 startPos, Vector3 endPos)
    {
        Vector3 startTan = startPos + Vector3.right * 5;
        Vector3 endTan = endPos + Vector3.left * 5;

        myBezier = new Bezier(startPos, startTan, endTan, endPos);

        int count = 51;
        lr.SetVertexCount(count);
        for (int i = 0; i < count; i++) {
            lr.SetPosition(i, myBezier.GetPointAtTime(i * 0.02f));
        }
        //Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.cyan, null, 3);
    }

}
