using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcFloatGhost : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float scaleSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        transform.transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
    }
}
