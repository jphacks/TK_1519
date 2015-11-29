using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class tapCheck : MonoBehaviour {

    private bool NodeMoveMode, SceneMoveMode, NodeJoinMode;
    private Vector2 mousePos_begin, mousePos_now;
    private Vector2 objPos_begin;
    private GameObject currentOBJ;

    public GameObject MainCam;

    public Bezier myBezier;
    public LineRenderer lr;

    public GameObject TimeLinePanel;
    private float PanelBeginX;

    public Color lineColor;
    public Color[] setColor = new Color[4];

	// Use this for initialization
	void Start () {
        NodeMoveMode = SceneMoveMode = NodeJoinMode = false;
	}
	
	// Update is called once per frame
	void Update () {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        MainCam.GetComponent<Camera>().orthographicSize -= scroll*2.5f;
        if (MainCam.GetComponent<Camera>().orthographicSize <= 3) {
            MainCam.GetComponent<Camera>().orthographicSize = 3f;
        }else if (MainCam.GetComponent<Camera>().orthographicSize >= 7.5f)
        {
            MainCam.GetComponent<Camera>().orthographicSize = 7.5f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

            if (aCollider2d)
            {
                GameObject obj = aCollider2d.transform.gameObject;
                Debug.Log(obj.name);
                currentOBJ = obj;
                if (obj.name == "contact_O_inc")
                {
                    NodeJoinMode = true;
                    lr.enabled = true;
                    lineColor = setColor[1];
                }
                else if (obj.name == "contact_O_mat")
                {
                    NodeJoinMode = true;
                    lr.enabled = true;
                    lineColor = setColor[0];
                }
                else if (obj.name == "contact_O_func")
                {
                    NodeJoinMode = true;
                    lr.enabled = true;
                    lineColor = setColor[2];
                }
                else if (obj.name == "contact_I_func")
                {

                }
                else if (obj.name == "contact_if") {
                    NodeJoinMode = true;
                    lr.enabled = true;
                    lineColor = setColor[3];
                }
                else
                {
                    NodeMoveMode = true;
                    objPos_begin = obj.transform.position;
                    mousePos_begin = Input.mousePosition;
                }
            }else{
                currentOBJ = MainCam;
                objPos_begin = MainCam.transform.position;
                mousePos_begin = Input.mousePosition;
                SceneMoveMode = true;
                PanelBeginX = TimeLinePanel.GetComponent<RectTransform>().position.x;
            }
        }else if (Input.GetMouseButtonUp(0)){
            if (NodeJoinMode)
            {
                Vector3 aUpPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D bCollider2d = Physics2D.OverlapPoint(aUpPoint);
                if (bCollider2d)
                {
                    GameObject upObj = bCollider2d.transform.gameObject;
                    if (CanContact(currentOBJ, upObj) && upObj.name == "contact_I_func")
                    {
                        currentOBJ.GetComponent<ContactState>().linked = true;
                        currentOBJ.GetComponent<ContactState>().outputID = upObj.transform.parent.GetComponent<NodeParentState>().all_id;
                        currentOBJ.GetComponent<ContactState>().LinkedTo = upObj;
                    }else if (CanContact(currentOBJ, upObj) && upObj.name == "contact_if")
                    {
                        currentOBJ.GetComponent<ContactState>().linked = true;
                        currentOBJ.GetComponent<ContactState>().LinkedTo = upObj;

                    }else if(CanContact(currentOBJ, upObj) && upObj.name == "complete")
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

            TimeLinePanel.GetComponent<RectTransform>().position 
                = new Vector3(PanelBeginX + (mousePos_now.x - mousePos_begin.x), 
                              TimeLinePanel.GetComponent<RectTransform>().position.y,
                              TimeLinePanel.GetComponent<RectTransform>().position.z);
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
        lr.SetColors(lineColor,lineColor);
        for (int i = 0; i < count; i++) {
            lr.SetPosition(i, myBezier.GetPointAtTime(i * 0.02f));
        }
        //Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.cyan, null, 3);
    }

}
