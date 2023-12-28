using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcSpriteMatSwitcher : MonoBehaviour
{
    SpriteRenderer sr;

    public Material[] materials;


    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
