using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoMision : MonoBehaviour
{
    private GameObject ranaMierda;
    private Dialog myDialog;
    private LocoDialog myLocoDialog;

    void Start()
    {
        ranaMierda = GameObject.FindGameObjectWithTag("Rana");
        myDialog = gameObject.GetComponent<Dialog>();
        myLocoDialog = gameObject.GetComponent<LocoDialog>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ranaMierda == null)
        {
            myDialog.enabled = false;
            myLocoDialog.enabled = true;
        }
    }
}
