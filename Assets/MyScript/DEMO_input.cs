using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DEMO_input : MonoBehaviour
{
    public Canvas POP2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pushed()
    {
        GameObject.Find("ReadCSV").GetComponent<MaterialList>().DEMO_mode = true;
        GameObject.Find("ReadCSV").GetComponent<MaterialList>().peopleNUM = 100;
        POP2.GetComponent<Canvas>().enabled = false;
    }
    public void Canseled()
    {
        POP2.GetComponent<Canvas>().enabled = false;
    }
}
