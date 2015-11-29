using UnityEngine;
using System.Collections;

public class static_timebar : MonoBehaviour {

    public Vector3 defPos;
    private float yPosInWorld,yPosInCamera;
    private Vector3 PosInCamera;
    public GameObject thisOBJ;

	// Use this for initialization
	void Start () {
        thisOBJ.transform.position = defPos;
        PosInCamera = Camera.main.WorldToScreenPoint(defPos);
        yPosInCamera = PosInCamera.y;
	}
	
	// Update is called once per frame
	void Update () {
        yPosInWorld = Camera.main.ScreenToWorldPoint(PosInCamera).y;
        thisOBJ.transform.position = new Vector3(thisOBJ.transform.position.x, yPosInWorld, thisOBJ.transform.position.z);
	}
}
