using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class include : MonoBehaviour {

	public string objName;
	public string details;
    public Sprite image;
    public Text nameHolder;
    
	public float volume;
	public string credit_1,credit_2,credit_ex;
	public bool taste;

    public GameObject inputLink, outputLink;

    public Vector3 outputPos;

    public int outputID;

    public Camera MainCamera,UICamera;

    private int all_id, scene_id;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        all_id = this.transform.parent.GetComponent<NodeParentState>().all_id;
        scene_id = this.transform.parent.GetComponent<NodeParentState>().scene_id;

        Vector3 nodePosition = this.transform.position;
        Vector2 nodeSize = this.transform.localScale;
        //Vector2 inputPos = new Vector2(nodePosition.x - nodeSize.x * 1.02f, nodePosition.y);

        outputPos = new Vector3(nodePosition.x + nodeSize.x * 1.02f, nodePosition.y, nodePosition.z - 0.1f);

        /*inputLink.transform.position = inputPos;
        inputLink.transform.localScale = new Vector3(this.transform.localScale.y*0.15f, this.transform.localScale.y * 0.15f, this.transform.localScale.y * 0.15f);*/
        outputLink.transform.position = outputPos;
        outputLink.transform.localScale = new Vector3(this.transform.localScale.y * 0.15f, this.transform.localScale.y * 0.15f, this.transform.localScale.y * 0.15f);

        //テキスト座標変換
        Vector3 TextScreenportPoint = MainCamera.WorldToScreenPoint(nodePosition);
        //Z座標指定
        TextScreenportPoint.z = 0f;
        nameHolder.transform.position = TextScreenportPoint;

        if (outputID >= 0) {

        }

    }
}