using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlexusController : MonoBehaviour {

    //public PlexusAgent[] plexusAgent;
    public List<PlexusAgent> plexAgents;


    public float maxDist = 5.0f;
    public float widthScale = 1.0f;

    /*
    public void CreatePlexusEffect()
    {
        //for each item in the plexus agent variable
        for (var i = 0; i < plexusAgent.Length - 1; i++)
        {
            var nodeA = plexusAgent[i];

            //for each item in the plexus agent array that comes after i
            for (var j = i + 1; j < plexusAgent.Length; j++)
            {
                var nodeB = plexusAgent[j];
                float dx = nodeB.transform.position.x - nodeA.transform.position.x,
                    dy = nodeB.transform.position.y - nodeA.transform.position.y,
                    dz = nodeB.transform.position.z - nodeA.transform.position.z,
                    dist = Mathf.Sqrt(dx * dx + dy * dy + dz * dz);
                if (dist < maxDist)
                {
                    //Debug.Log("connection");
                    float width = (1 - dist / maxDist) * (widthScale * 0.1f);
                    nodeA.SetLine(nodeB.transform, width);
                    nodeB.AddConnectionRating(width);
                }
            }
        }
    }

    */
    public void CreatePlexusEffectList()
    {
        //RefreshAgentsList();

        //for each item in the plexus agent variable
        for (var i = 0; i < plexAgents.Count - 1; i++)
        {
            var nodeA = plexAgents[i];

            //for each item in the plexus agent array that comes after i
            for (var j = i + 1; j < plexAgents.Count; j++)
            {
                var nodeB = plexAgents[j];
                float dx = nodeB.transform.position.x - nodeA.transform.position.x,
                    dy = nodeB.transform.position.y - nodeA.transform.position.y,
                    dz = nodeB.transform.position.z - nodeA.transform.position.z,
                    dist = Mathf.Sqrt(dx * dx + dy * dy + dz * dz);
                if (dist < maxDist)
                {
                    //Debug.Log("connection");
                    float width = (1 - dist / maxDist) * (widthScale * 0.1f);
                    nodeA.SetLine(nodeB.transform, width);
                    nodeB.AddConnectionRating(width);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        CreatePlexusEffectList();
    }

    public void RefreshAgentsList()
    {
        plexAgents.Clear();

        //PlexusAgent[] _activeAgents = gameObject.GetComponentsInChildren<PlexusAgent>();
        //plexAgents.AddRange(_activeAgents);

        Debug.Log("RefreshAgentsList called");
        /*
        
        for (int i = plexAgents.Count - 1; i >= 0; i--)
        {
            if (!plexAgents[i].gameObject.activeInHierarchy)
            {
                plexAgents.Remove(plexAgents[i]);
            }
        }
        */
    }

}
