using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.rfilkov.kinect;
public class CcSetKinnectValues : MonoBehaviour
{
    Kinect2Interface kinect2Interface;

    // Start is called before the first frame update
    void Start()
    {
        kinect2Interface = GetComponent<Kinect2Interface>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMinDepth(float value)
    {
        kinect2Interface.minDepthDistance = value;
    }

    public void SetMaxDepthDistance(float value)
    {
        kinect2Interface.maxDepthDistance = value;
    }

    public void SetMinMaxDepth(float min, float max)
    {
        kinect2Interface.minDepthDistance = min;
        kinect2Interface.maxDepthDistance = max;
    }

}
