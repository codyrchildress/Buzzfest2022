using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostContainer
{
    public CcCopyDemBones Ghost;
    public float Life = 2;
    public float Fade = 1;

    public GhostContainer(CcCopyDemBones pGhost, float pLife)
    {
        Ghost = pGhost;
        Life = pLife;
    }
}



public class CcGhostGenerator : MonoBehaviour
{
    public GameObject sourceBoneRoot;
    public CcCopyDemBones ghostPrefab;
    public float ghostDistance = 10f;
    public float ghostLife = 10;
    public float ghostFadeInTime = 1;
    public float ghostFadeOutTime = 1;
    public float ghostDistortion = 0.1f;
    public float ghostDistortionOutTime = 1f;
    public float ghostScaleOut = 0.25f;

    bool Generate = true;

    public float generateGhostTime = 1f;
    Vector3 lastPosition;
    //float distanceTraveled = 0f;


    List<GhostContainer> Ghosts;
    Vector3 initialScale;

    Queue<CcCopyDemBones> GhostPool;

    public bool GetGenerate()
    {
        return Generate;
    }

    public void SetGenerate(bool value)
    {
        Generate = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        Ghosts = new List<GhostContainer>();
        GhostPool = new Queue<CcCopyDemBones>();
        //lastPosition = transform.position;
        StartCoroutine("IGenerateGhosts");
    }

    void SetGhostMaterialVar(string pVar, CcCopyDemBones pGhost, float pValue)
    {
        SkinnedMeshRenderer[] meshes = pGhost.GetComponentsInChildren<SkinnedMeshRenderer>(); 
        foreach (SkinnedMeshRenderer mesh in meshes)
        {
            foreach (Material mat in mesh.materials)
            {
                mat.SetFloat(pVar, pValue);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        distanceTraveled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        if (distanceTraveled >= ghostDistance) //Generate && 
        {
            distanceTraveled = 0;
            GenerateGhost();
        }
        */

        List<GhostContainer> removeGhosts = new List<GhostContainer>();

        foreach(GhostContainer ghost in Ghosts)
        {
            ghost.Life -= Time.deltaTime;
            if (ghost.Life <= 0)
            {
                removeGhosts.Add(ghost);
            }

            if (ghost.Life < ghostDistortionOutTime)
            {
                float prop = Mathf.Clamp(1 - (ghost.Life / ghostDistortionOutTime), 0f, 1f);
                //SetGhostMaterialVar("VertexDistortionStrength", ghost.Ghost, prop * ghostDistortion);

                if (initialScale == Vector3.zero)
                {
                    initialScale = ghost.Ghost.transform.localScale;
                }

                ghost.Ghost.transform.localScale = initialScale * (1 + (ghostScaleOut * prop));
            }

            if (ghost.Life < ghostFadeOutTime)
            {
                float fade = Mathf.Clamp(1 - (ghost.Life / ghostFadeOutTime), 0f, 1f);
                //SetGhostMaterialVar("Fade", ghost.Ghost, fade);
            }
            else
            {
                float fade = Mathf.Clamp(1 - ((ghostLife - ghost.Life) / ghostFadeInTime), 0f, 1f);
                //SetGhostMaterialVar("Fade", ghost.Ghost, fade);
            }
        }

        foreach (GhostContainer ghost in removeGhosts)
        {
            Ghosts.Remove(ghost);
            ghost.Ghost.gameObject.SetActive(false);
            GhostPool.Enqueue(ghost.Ghost);
        }

    }


    void GenerateGhost()
    {
        CcCopyDemBones ghost;
        if (GhostPool.Count > 0)
        {
            ghost = GhostPool.Dequeue();
            //SetGhostMaterialVar("VertexDistortionStrength", ghost, 0);
            ghost.transform.localScale = initialScale;
            ghost.gameObject.SetActive(true);

        }
        else
        {
            ghost = Instantiate(ghostPrefab, transform.parent);
        }

        Ghosts.Add(new GhostContainer(ghost, ghostLife));

        ghost.transform.localPosition = transform.localPosition;
        ghost.transform.localRotation = transform.localRotation;

        ghost.source = sourceBoneRoot;
        ghost.Initialize();
        ghost.CopyBones();

    }


    IEnumerator IGenerateGhosts()
    {
        yield return new WaitForSeconds(1f);
        GenerateGhost();
        while(true)
        {
            yield return new WaitForSeconds(generateGhostTime);
            GenerateGhost();
        }
        
        //StartCoroutine("IGenerateGhosts");
    }
}
