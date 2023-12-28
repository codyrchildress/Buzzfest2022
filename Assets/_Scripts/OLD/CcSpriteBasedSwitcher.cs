using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcSpriteBasedSwitcher : MonoBehaviour
{
    public Material[] materials;
    public SpriteRenderer spriteRenderer;
    public CcSpawner ccSpawner;

    public CcGameManager gameManager;
    int current;

    // Start is called before the first frame update
    void Awake()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextEffect()
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

    public void PreviousEffect()
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

    public void CleanupAndDelete()
    {

    }
}
