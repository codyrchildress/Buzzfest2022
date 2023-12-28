using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CcEffectGroup : MonoBehaviour
{
    public GameObject[] effectGO;

    public VisualEffectAsset[] vfxs;
    VisualEffect visualEffect;

    public CcGameManager gameManager;

    GameObject currentAvatarMatcher_GO;

    public bool usesAvatarMatcher; 
    public bool usesVisualEffects;
    public bool usesSpriteRenderer;

    SpriteRenderer spriteRenderer;
    public Material[] materials;

    public int current;

    public int numOfEffects;

    // Start is called before the first frame update
    void Awake()
    {
        current = 0;

        if (usesVisualEffects)
        {
            visualEffect = GetComponent<VisualEffect>();
            visualEffect.visualEffectAsset = vfxs[current];

            numOfEffects = vfxs.Length - 1;
        }
        if (usesAvatarMatcher)
        {
            numOfEffects = effectGO.Length - 1;
        }
        if (usesSpriteRenderer)
        {
            numOfEffects = materials.Length - 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        current = 0;
        if (usesAvatarMatcher)
        {
            currentAvatarMatcher_GO = Instantiate(effectGO[current]);
        }
    }


    public void NextEffect()
    {
        if (usesVisualEffects)
        {
            if (this.gameObject.activeInHierarchy)
            {
                current++;
                if (current > vfxs.Length - 1)
                {
                    if (gameManager._autoSwitchTypes)
                    {
                        Debug.Log("NextType from VFXSwitcher called");

                        current = 0;
                        gameManager.PlayNextType();
                        return;
                    }
                    else
                    {
                        current = 0;
                    }
                }
                visualEffect.visualEffectAsset = vfxs[current];
            }

        }

        if (usesSpriteRenderer)
        {
            if (this.gameObject.activeInHierarchy)
            {
                current++;
                if (current > materials.Length - 1)
                {
                    if (gameManager._autoSwitchTypes)
                    {
                        Debug.Log("NextEffect called from SpriteSwitcher");
                        current = 0;
                        gameManager.PlayNextType();
                        return;
                    }
                    else
                    {
                        current = 0;
                    }
                }
                spriteRenderer.material = materials[current];

            }

        }

        if (usesAvatarMatcher)
        {
            if (this.gameObject.activeInHierarchy)
            {
                if (currentAvatarMatcher_GO != null)
                {
                    Destroy(currentAvatarMatcher_GO);
                }

                current++;
                if (current > effectGO.Length - 1)
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
            }
        }

        Debug.Log("current is: "+current);

    }

    public void PreviousEffect()
    {
        if (usesVisualEffects)
        {
            if (this.gameObject.activeInHierarchy)
            {
                current--;
                if (current < 0)
                {
                    current = vfxs.Length - 1;
                }
                visualEffect.visualEffectAsset = vfxs[current];
            }
        }

        if (usesSpriteRenderer)
        {
            if (this.gameObject.activeInHierarchy)
            {
                current--;
                if (current > 0)
                {
                    current = materials.Length - 1;
                }
                spriteRenderer.material = materials[current];
            }
        }

        if (usesAvatarMatcher)
        {
            if (this.gameObject.activeInHierarchy)
            {
                Destroy(currentAvatarMatcher_GO);

                current--;
                if (current > 0)
                {
                    current = effectGO.Length - 1;
                }

                currentAvatarMatcher_GO = Instantiate(effectGO[current]);
                //userAvatarMatcher = currentAvatarMatcher_GO.GetComponent<UserAvatarMatcher>();

            }
        }
    }

    public void CleanupAndDelete()
    {
        if (this.gameObject.activeInHierarchy)
        {
            if (currentAvatarMatcher_GO != null)
            {
                Destroy(currentAvatarMatcher_GO);
                //Debug.Log("CleanupAndDelete on SkeletonSwitcher Called");
            }
            //Destroy(this.gameObject);
        }
    }


    IEnumerator INextEffect()
    {
        if (gameManager.useMultiTransitions == true)
        {
            yield return new WaitForSeconds(0.75f);
        }
        
        currentAvatarMatcher_GO = Instantiate(effectGO[current]);
    }
}
