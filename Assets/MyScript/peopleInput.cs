using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class peopleInput : MonoBehaviour {

    public InputField val;
    private string str;
    private int value;
    public Canvas POP;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Pushed() {
        str = val.text;
        int.TryParse(str, out value);
        GameObject.Find("ReadCSV").GetComponent<MaterialList>().peopleNUM = value;
        GameObject.Find("ReadCSV").GetComponent<MaterialList>().people_change = true;
        POP.GetComponent<Canvas>().enabled = false;
    }

    public void Canseled() {
        POP.GetComponent<Canvas>().enabled = false;
    }
}
