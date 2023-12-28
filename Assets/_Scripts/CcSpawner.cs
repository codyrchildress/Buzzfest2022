using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcSpawner : MonoBehaviour
{
    public Vector3 spawnSize;
    public Vector3 spawnCenter;
    public int numOfSpawns;
    public GameObject spawnPrefab;
    Vector3 tempPos;

    public float spawnEveryNSeconds = 1f;

    //PlexusController controller;

    // Start is called before the first frame update
    void OnEnable()
    {
        //controller = GetComponent<PlexusController>();
        //controller.plexusAgent = new PlexusAgent[numOfSpawns];

        for (int i = 0; i < numOfSpawns ; i++)
        {
            tempPos = RandomPointInBox(spawnCenter, spawnSize);
            GameObject pGO = Instantiate(spawnPrefab, tempPos, Quaternion.identity, this.transform);
            //PlexusAgent pAgent = pGO.GetComponent<PlexusAgent>();
            //controller.plexusAgent[i] = pAgent;
        }

        StartCoroutine("ISpawner");
        
    }

    IEnumerator ISpawner()
    {
        yield return new WaitForSeconds(spawnEveryNSeconds);
        tempPos = RandomPointInBox(spawnCenter, spawnSize);
        Instantiate(spawnPrefab, tempPos, Quaternion.identity, this.transform);

        StartCoroutine("ISpawner");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {

    }

    private Vector3 RandomPointInBox(Vector3 center, Vector3 size)
    {
        return center + new Vector3(
            (Random.value - 0.5f) * size.x,
            (Random.value - 0.5f) * size.y,
            (Random.value - 0.5f) * size.z
        );
    }

    public void CleanupAndDelete()
    {
        StopAllCoroutines();
    }

}
