using UnityEngine;
using System.Collections;

public class CamScroll : MonoBehaviour {

    public float scroll;
    public float min;
    public Camera MainCam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        MainCam.transform.position += Vector3.up * scroll * 15f;
        if (MainCam.transform.position.y >= 0f) {
            MainCam.transform.position = new Vector3(0f, 0f, -10f);
        }
        else if (MainCam.transform.position.y <= min) {
            MainCam.transform.position = new Vector3(0f, min, -10f);
        }
	}
}
