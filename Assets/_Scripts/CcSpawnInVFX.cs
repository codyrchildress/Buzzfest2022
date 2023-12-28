using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcSpawnInVFX : MonoBehaviour
{
    public GameObject VFX_GO;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(VFX_GO);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
