using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcCopyDemBones : MonoBehaviour
{

    public GameObject source;
    public GameObject myBoneRoot;

    Transform[] sourceBones;
    Transform[] myBones;

    // Start is called before the first frame update
    void Start()
    {
        if (source && myBoneRoot)
        {
            Initialize();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int CompareName(Transform a, Transform b)
    {
        return (a.name.CompareTo(b.name));
    }


    public void Initialize()
    {
        sourceBones = source.GetComponentsInChildren<Transform>();
        myBones = myBoneRoot.GetComponentsInChildren<Transform>();

        //dont necessarily need this step
        Array.Sort(sourceBones, CompareName);
        Array.Sort(myBones, CompareName);
    }

    public void CopyBones()
    {
        for (int i = 0; i < sourceBones.Length; i++)
        {
            myBones[i].localPosition = sourceBones[i].localPosition;
            myBones[i].localRotation = sourceBones[i].localRotation;
            myBones[i].localScale = sourceBones[i].localScale;
        }
    }

}
