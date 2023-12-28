using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CcGameManagerOld : MonoBehaviour
{

    public CcVFXSwitcher pointCloudSwitcher;
    public CcSpriteBasedSwitcher spriteBasedSwitcher;
    public CcSkeletonSwitcher skeletonSwitcher;

    public PlayableDirector _cameraDirector;
    public TimelineAsset[] transitionTimelines;

    public TimelineAsset previuosTimeline;
    public TimelineAsset nextTimeline;
    public TimelineAsset nextTypeTimeline;

    public GameObject[] effectTypes;
    int currentEffectType;
    public CcEffectGroup[] effectGroup;

    public KeyCode previousKey;
    public KeyCode nextKey;
    public KeyCode nextType;

    public bool _autoPlay;
    public bool _autoSwitchTypes { get; set; }

    public float effectDuration { get; set; }

    // Start is called before the first frame update
    void Start()
    {


        for (int i = 0; i < effectTypes.Length; i++)
        {
            effectTypes[i].SetActive(false);
        }
        effectTypes[0].SetActive(true);

       // _autoPlay = true;
        currentEffectType = 0;
        effectDuration = 20f;

        if (_autoPlay)
        {
            StartCoroutine("IAutoPlayEffects");
        }
        
    }

    public void SetActiveEffectType()
    {

    }


    public void AutoPlay(bool value)
    {
        if (value)
        {
            _autoPlay = true;
            StartCoroutine("IAutoPlayEffects");
        }
        else
        {
            _autoPlay = false;
            StopCoroutine("IAutoPlayEffects");
        }
        
    }


    IEnumerator IAutoPlayEffects()
    {
        yield return new WaitForSeconds(effectDuration);
        PlayNextEffect();
        StartCoroutine("IAutoPlayEffects");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(previousKey))
        {
            PlayPreviousEffect();
        }
        if (Input.GetKeyDown(nextKey))
        {
            PlayNextEffect();
        }
        if (Input.GetKeyDown(nextType))
        {
            PlayNextType();
        }
    }

    public void PlayNextType()
    {
        StopAllCoroutines();
        //_cameraDirector.playableAsset = transitionTimelines[2];
        _cameraDirector.playableAsset = nextTypeTimeline;


        _cameraDirector.Play();

        if (_autoPlay)
        {
            StartCoroutine("IAutoPlayEffects");
        }
    }

    public void NextType()
    {
        effectTypes[currentEffectType].SetActive(false);
        currentEffectType++;
        if (currentEffectType > effectTypes.Length - 1)
        {
            currentEffectType = 0;
        }
        effectTypes[currentEffectType].SetActive(true);

        Debug.Log("next type called");
    }

    public void PlayNextEffect()
    {
        // _cameraDirector.playableAsset = transitionTimelines[1];
        _cameraDirector.playableAsset = nextTimeline;
        _cameraDirector.Play();
    }

    public void PlayPreviousEffect()
    {
        //_cameraDirector.playableAsset = transitionTimelines[0];
        _cameraDirector.playableAsset = previuosTimeline;
        _cameraDirector.Play();
    }

    public void NextEffects()
    {
        if (currentEffectType == 0)
        {
            pointCloudSwitcher.NextEffect();
        }
        else if (currentEffectType == 1)
        {
            skeletonSwitcher.NextEffect();
        }
        else if (currentEffectType == 2)
        {
            spriteBasedSwitcher.NextEffect();
        }
        
        
    }

    public void PreviousEffects()
    {
        if (currentEffectType == 0)
        {
            pointCloudSwitcher.PreviousEffect();

        }
        else if (currentEffectType == 1)
        {
            skeletonSwitcher.PreviousEffect();
        }
        else if (currentEffectType == 2)
        {
            spriteBasedSwitcher.PreviousEffect();
        }
        
    }
}
