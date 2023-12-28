using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CcVFXSwitcher : MonoBehaviour
{
    public VisualEffectAsset[] vfxs;
    
    private int currentVFX;
    VisualEffect visualEffect;

    public CcGameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        visualEffect = GetComponent<VisualEffect>();
        currentVFX = 0;

        visualEffect.visualEffectAsset = vfxs[0];
        //StartCoroutine("INextEffect");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextEffect()
    {
        if (this.gameObject.activeInHierarchy)
        {
            currentVFX++;
            if (currentVFX > vfxs.Length - 1)
            {
                if (gameManager._autoSwitchTypes)
                {
                    Debug.Log("NextType from VFXSwitcher called");

                    currentVFX = 0;
                    gameManager.PlayNextType();
                    return;
                }
                else
                {
                    currentVFX = 0;
                }
            }
            visualEffect.visualEffectAsset = vfxs[currentVFX];
        }

    }

    public void PreviousEffect()
    {
        if (this.gameObject.activeInHierarchy)
        {
            currentVFX--;
            if (currentVFX < 0)
            {
                currentVFX = vfxs.Length - 1;
            }
            visualEffect.visualEffectAsset = vfxs[currentVFX];
        }
    }

    /*
    IEnumerator INextEffect()
    {
        yield return new WaitForSeconds(waitTime);
        NextEffect();
        StartCoroutine("INextEffect");

    }
    */
}
