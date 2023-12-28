using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlexusAgent : MonoBehaviour {

    public bool useScale = true;
    public float minScale = 0.25f;
    public float agentScaleMultiplier = 1.0f;
    public float lineWidthMultiplier = 1.0f;
    public int maxLineRenderers = 10;

    public Material mat;

    GameObject[] lineRendererGO = new GameObject[10];
    LineRenderer[] lineRs = new LineRenderer[10];
    PlexusConnection[] plexusConnections = new PlexusConnection[10];
    int currentLineR = 0;
    float connectionRating = 0.0f;

    // Use this for initialization
    void Awake () {

        PlexusController controller = gameObject.GetComponentInParent(typeof(PlexusController)) as PlexusController;
        

        for (int i = 0; i < maxLineRenderers; i++)
        {
            lineRendererGO[i] = new GameObject();
            lineRendererGO[i].name = "PlexusConnection";
            lineRendererGO[i].transform.parent = this.transform;
            lineRs[i] = lineRendererGO[i].AddComponent<LineRenderer>();
            plexusConnections[i] = lineRendererGO[i].AddComponent<PlexusConnection>();
            //lineRs[i].material = new Material(Shader.Find("Particles/Additive"));
            lineRs[i].material = mat;
        }

        controller.plexAgents.Add(this);
    }

    public void SetLine(Transform t, float lineWidth)
    {
        lineRs[currentLineR].SetPosition(0, transform.position);
        lineRs[currentLineR].SetPosition(1, t.position);
        lineRs[currentLineR].startWidth = lineWidth * lineWidthMultiplier;
        lineRs[currentLineR].endWidth = lineWidth * lineWidthMultiplier;
        lineRs[currentLineR].enabled = true;
        plexusConnections[currentLineR].SetConnection();
        connectionRating += lineWidth;
        currentLineR++;
        if(currentLineR >= maxLineRenderers){currentLineR = 0;}
    }

    public void AddConnectionRating(float value)
    {
        connectionRating += value;
    }

	// Update is called once per frame
	void Update () {
        if(connectionRating != 0)
        {
            if(useScale){transform.localScale = new Vector3((connectionRating * agentScaleMultiplier * 0.1f + minScale), (connectionRating * agentScaleMultiplier * 0.1f + minScale), (connectionRating * agentScaleMultiplier * 0.1f + minScale));}
            connectionRating = 0;
        }
    }
}
