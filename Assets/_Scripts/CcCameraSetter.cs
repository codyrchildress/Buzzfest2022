using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcCameraSetter : MonoBehaviour
{
    //Camera cam;
    //Transform t;

    // Start is called before the first frame update
    void Start()
    {
        //cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCameraPosition(float z)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, z);
    }

}
