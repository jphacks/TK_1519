using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleTap : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

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
                if (obj.name == "new_recipe")
                {
                }
                else if (obj.name == "tonjiru")
                {
                    PlayerPrefs.SetInt("menu", 0);
                    Application.LoadLevel("Material");
                }
            }
        }
    }
}
