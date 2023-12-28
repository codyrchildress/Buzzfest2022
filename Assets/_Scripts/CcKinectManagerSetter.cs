using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.rfilkov.kinect;

public class CcKinectManagerSetter : MonoBehaviour
{

    KinectManager _kinectManager;

    // Start is called before the first frame update
    void Start()
    {
        _kinectManager = GetComponent<KinectManager>();
    }

    public void ToggleDebugScreen(bool isOn)
    {
        //_kinectManager.displayImages[0].
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
