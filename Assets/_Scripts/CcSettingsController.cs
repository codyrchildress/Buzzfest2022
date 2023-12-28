using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcSettingsController : MonoBehaviour
{
    public GameObject uiPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //toggle settings
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiPanel.SetActive(!uiPanel.activeInHierarchy);
        }
    }
}
