using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlexusConnection : MonoBehaviour {

    LineRenderer lineRenderer;
    public bool setThisFrame = false;

    public void SetConnection()
    {
        setThisFrame = true;
        lineRenderer.enabled = true;
    }

	// Use this for initialization
	void Awake () {
        lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(setThisFrame)
        {
            setThisFrame = false;
        }
        else
        {
            lineRenderer.enabled = false;
        }
	}
}
