using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcChooseRandomVfx : MonoBehaviour
{
    public GameObject[] VfxGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("VfxGameObjects.Length: " + VfxGameObjects.Length);
        int rand = Random.Range(0, VfxGameObjects.Length);
        Debug.Log("Rand: " + rand);
        for (int i = 0; i < VfxGameObjects.Length; i++)
        {
            VfxGameObjects[i].SetActive(false);
        }

        VfxGameObjects[rand].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
