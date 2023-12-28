using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.rfilkov.components;

public class CcSkeletonSwitcher : MonoBehaviour
{
    public GameObject[] GO;
    
    GameObject currentAvatarMatcher_GO;
    //UserAvatarMatcher userAvatarMatcher;
    public CcGameManager gameManager;

    //public KeyCode nextKey;

    int current;

    // Start is called before the first frame update
    void Awake()
    {


        current = 0;
        //for (int i = 0; i < GO.Length; i++)
        // {
        //GO[i].SetActive(false);

        // }
        //GO[current].SetActive(true) ;
        
        //userAvatarMatcher = currentAvatarMatcher_GO.GetComponent<UserAvatarMatcher>();

    }

    private void OnEnable()
    {

        currentAvatarMatcher_GO = Instantiate(GO[current]);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void NextEffect()
    {

        if (this.gameObject.activeInHierarchy)
        {
            if (currentAvatarMatcher_GO != null)
            {
                Destroy(currentAvatarMatcher_GO);
            }


            current++;
            if (current > GO.Length - 1)
            {
                if (gameManager._autoSwitchTypes)
                {
                    Debug.Log("NextType called from SkeletonSwitcher");
                    current = 0;
                    gameManager.PlayNextType();
                    return;
                }
                else
                {
                    current = 0;
                }
                
            }

            StartCoroutine("INextEffect");
            //currentAvatarMatcher_GO = Instantiate(GO[current]);
            //userAvatarMatcher = currentAvatarMatcher_GO.GetComponent<UserAvatarMatcher>();
        }

    }

    IEnumerator INextEffect()
    {
        yield return new WaitForSeconds(0.75f);
        currentAvatarMatcher_GO = Instantiate(GO[current]);
    }


    public void PreviousEffect()
    {
        if (this.gameObject.activeInHierarchy)
        {
            Destroy(currentAvatarMatcher_GO);

            current--;
            if (current > 0)
            {
                current = GO.Length - 1;
            }

            currentAvatarMatcher_GO = Instantiate(GO[current]);
            //userAvatarMatcher = currentAvatarMatcher_GO.GetComponent<UserAvatarMatcher>();
        }


    }

    public void CleanupAndDelete()
    {
        if (this.gameObject.activeInHierarchy)
        {
            if (currentAvatarMatcher_GO != null)
            {
                Destroy(currentAvatarMatcher_GO);
                Debug.Log("CleanupAndDelete on SkeletonSwitcher Called");
            }
            //Destroy(this.gameObject);
        }

    }
}
