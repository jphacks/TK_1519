using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Collections;

public class MaterialList : MonoBehaviour {

    private List<int> M_idList = new List<int>();
    private List<string> M_nameList = new List<string>();
    private List<float> M_valList = new List<float>();
    private List<string> M_creditList = new List<string>();

    private List<int> I_idList = new List<int>();
    private List<string> I_nameList = new List<string>();
    private List<float> I_valList = new List<float>();
    private List<string> I_creditList = new List<string>();

    private List<GameObject> M_button = new List<GameObject>();
    private List<GameObject> I_button = new List<GameObject>();

    private List<GameObject> M_Text_name = new List<GameObject>();
    private List<GameObject> M_Text_val = new List<GameObject>();

    public int readSeed;
    public int peopleNUM;

    bool people_change;

    public GameObject Material_button,Include_button;
    public GameObject Text_name, Text_val;

    // Use this for initialization
    void Start()
    {
        //readseedをなんやかんや
        CSVreader(readSeed, peopleNUM);
        people_change = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (people_change) {
            CSVreader(readSeed, peopleNUM);
        }
	}

    void CSVreader(int recipeID, int people) {

        M_idList.Clear();
        M_nameList.Clear();
        M_valList.Clear();
        M_creditList.Clear();
        I_idList.Clear();
        I_nameList.Clear();
        I_valList.Clear();
        I_creditList.Clear();
        M_button.Clear();
        I_button.Clear();

        TextAsset csv_material = Resources.Load("CSV/material_" + recipeID + "_" + people) as TextAsset;
        TextAsset csv_include = Resources.Load("CSV/include_" + recipeID + "_" + people) as TextAsset;
        StringReader reader_material = new StringReader(csv_material.text);
        StringReader reader_include = new StringReader(csv_include.text);
        while (reader_material.Peek() > -1)
        {
            string line_material = reader_material.ReadLine();
            string[] values_material = line_material.Split(',');

            int tmp0, tmp2;
            int.TryParse(values_material[0], out tmp0);
            int.TryParse(values_material[2], out tmp2);
            M_idList.Add(tmp0);
            M_nameList.Add(values_material[1]);
            M_valList.Add(tmp2);
            M_creditList.Add(values_material[3]);
        }
        while (reader_include.Peek() > -1)
        {
            string line_include = reader_include.ReadLine();
            string[] values_include = line_include.Split(',');

            int tmp0, tmp2;

            int.TryParse(values_include[0], out tmp0);
            int.TryParse(values_include[2], out tmp2);
            I_idList.Add(tmp0);
            I_nameList.Add(values_include[1]);
            I_valList.Add(tmp2);
            I_creditList.Add(values_include[3]);
        }
        int M_max = M_idList.Count;
        for (int i = 0; i < M_max; i++)
        {
            M_button.Add(Object.Instantiate(Material_button, new Vector3(-4.5f, 1.0f - (i * 1.5f), 0f), Quaternion.identity) as GameObject);
            M_Text_name.Add(Object.Instantiate(Text_name));
            M_Text_val.Add(Object.Instantiate(Text_val));
            M_Text_name[i].GetComponent<list_nameHolder>().parent = M_button[i];
            M_Text_val[i].GetComponent<list_nameHolder>().parent = M_button[i];
            M_Text_name[i].GetComponent<Text>().text = M_nameList[i];
            M_Text_val[i].GetComponent<Text>().text = "" + M_valList[i] + M_creditList[i];
        }
        int I_max = I_idList.Count;
        for (int i = 0; i < I_max; i++)
        {
            I_button.Add(Object.Instantiate(Include_button, new Vector3(4.5f, 1.0f - (i * 1.5f), 0f), Quaternion.identity) as GameObject);
        }
    }

    void CSVreaderDEMO(){

        M_idList.Clear();
        M_nameList.Clear();
        M_valList.Clear();
        M_creditList.Clear();
        I_idList.Clear();
        I_nameList.Clear();
        I_valList.Clear();
        I_creditList.Clear();
        M_button.Clear();
        I_button.Clear();

        TextAsset csv_material = Resources.Load("CSV/material_DEMO") as TextAsset;
        TextAsset csv_include = Resources.Load("CSV/include_DEMO") as TextAsset;
        StringReader reader_material = new StringReader(csv_material.text);
        StringReader reader_include = new StringReader(csv_include.text);
        while (reader_material.Peek() > -1)
        {
            string line_material = reader_material.ReadLine();
            string[] values_material = line_material.Split(',');

            int tmp0, tmp2;
            int.TryParse(values_material[0], out tmp0);
            int.TryParse(values_material[2], out tmp2);
            M_idList.Add(tmp0);
            M_nameList.Add(values_material[1]);
            M_valList.Add(tmp2);
            M_creditList.Add(values_material[3]);
        }
        while (reader_include.Peek() > -1)
        {
            string line_include = reader_include.ReadLine();
            string[] values_include = line_include.Split(',');

            int tmp0, tmp2;

            int.TryParse(values_include[0], out tmp0);
            int.TryParse(values_include[2], out tmp2);
            I_idList.Add(tmp0);
            I_nameList.Add(values_include[1]);
            I_valList.Add(tmp2);
            I_creditList.Add(values_include[3]);
        }
        int M_max = M_idList.Count;
        for (int i = 0; i < M_max; i++)
        {
            M_button.Add(Object.Instantiate(Material_button, new Vector3(-4.5f, 1.0f - (i * 1.5f), 0f), Quaternion.identity) as GameObject);
        }
        int I_max = I_idList.Count;
        for (int i = 0; i < I_max; i++)
        {
            I_button.Add(Object.Instantiate(Include_button, new Vector3(4.5f, 1.0f - (i * 1.5f), 0f), Quaternion.identity) as GameObject);
        }
    }

}
