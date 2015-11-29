﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class func : MonoBehaviour
{

    public string objName;
    public string value;
    private Text nameHolder;
    private Text valHolder;

    public Text namePref, valPref;

    public float tmp;

    /*public float volume;
	public string credit_1,credit_2,credit_ex;
	public bool taste;*/

    public GameObject inputLink, outputLink;

    public Vector3 inputPos,outputPos;

    public int outputID;

    public Camera MainCamera;

    private int all_id, scene_id;

    // Use this for initialization
    void Start()
    {
        nameHolder = Instantiate(namePref);
        nameHolder.GetComponent<Text>().text = objName;
        nameHolder.transform.parent = GameObject.Find("Canvas").transform;
        valHolder = Instantiate(valPref);
        valHolder.GetComponent<Text>().text = value;
        valHolder.transform.parent = GameObject.Find("Canvas").transform;
    }

    // Update is called once per frame
    void Update()
    {

        all_id = this.transform.parent.GetComponent<NodeParentState>().all_id;
        scene_id = this.transform.parent.GetComponent<NodeParentState>().scene_id;

        Vector3 nodePosition = this.transform.position;
        Vector2 nodeSize = this.transform.localScale;

        inputPos = new Vector3(nodePosition.x - nodeSize.x * 1.02f, nodePosition.y, nodePosition.z - 0.1f);
        outputPos = new Vector3(nodePosition.x + nodeSize.x * 1.02f, nodePosition.y, nodePosition.z - 0.1f);

        inputLink.transform.position = inputPos;
        inputLink.transform.localScale = new Vector3(this.transform.localScale.y*0.25f, this.transform.localScale.y * 0.25f, this.transform.localScale.y * 0.25f);
        outputLink.transform.position = outputPos;
        outputLink.transform.localScale = new Vector3(this.transform.localScale.y * 0.15f, this.transform.localScale.y * 0.15f, this.transform.localScale.y * 0.15f);

        //テキスト座標変換
        Vector3 TextScreenportPoint = MainCamera.WorldToScreenPoint(nodePosition);
        //Z座標指定
        TextScreenportPoint.z = 0f;
        nameHolder.transform.position = TextScreenportPoint;
        Vector3 valScreenPoint = new Vector3(TextScreenportPoint.x, TextScreenportPoint.y - 15, TextScreenportPoint.z);
        valHolder.transform.position = valScreenPoint;

        if (outputID >= 0)
        {

        }

    }
}