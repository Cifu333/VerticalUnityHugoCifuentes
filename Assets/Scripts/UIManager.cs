using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input_Manager._INPUT_MANAGER.getescButton() == 0)
        {

            Cursor.lockState = CursorLockMode.Confined;
            a.SetActive(true);
            a.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
