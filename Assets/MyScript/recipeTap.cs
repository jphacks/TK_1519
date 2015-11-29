using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class recipeTap : MonoBehaviour {

    private GameObject currentOBJ;
    private int count;
    public Canvas POP;

    // Use this for initialization
    void Start () {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

            if (aCollider2d)
            {
                GameObject obj = aCollider2d.transform.gameObject;
                currentOBJ = obj;

                if (obj.name == "change_people")
                {
                    GameObject.Find("POP").GetComponent<Canvas>().enabled = true;
                }
                else if(obj.name == "M_list(Clone)")
                {
                    GameObject.Find("POP2").GetComponent<Canvas>().enabled = true;
                }else if(obj.name == "go_recipe")
                {
                    Application.LoadLevel("test");
                }
            }
        }
    }
}
