using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CcGameManager : MonoBehaviour
{

    public PlayableDirector _cameraDirector;

    public TimelineAsset previuosTimeline;
    public TimelineAsset nextTimeline;
    public TimelineAsset nextTypeTimeline;

    public CcEffectGroup[] effectGroup;
    int currentEffectType;

    public KeyCode previousKey;
    public KeyCode nextKey;
    public KeyCode nextType;
    public KeyCode multiNextKey;

    public bool _autoPlay;
    public bool _autoSwitchTypes { get; set; }
    public float effectDuration { get; set; }

    public bool useTransitions { get; set; }

    public bool useMultiTransitions { get; set; }
    public int numOfMultiTransitions = 20;
    public float multiTransitionWaitTime = 0.2f;

    bool isTransitioning = false;

    // Start is called before the first frame update
    void Start()
    {
        //setup
        currentEffectType = 0;
        effectDuration = 20f; //initialize autoplay length
        _autoPlay = true; //initialize autoplay
        _autoSwitchTypes = true; //initialize auto switch types
        useTransitions = false;
        useMultiTransitions = true;

        //set first effect
        for (int i = 0; i < effectGroup.Length; i++)
        {
            effectGroup[i].gameObject.SetActive(false);
        }
        effectGroup[0].gameObject.SetActive(true);

        if (_autoPlay)
        {
            AutoPlayEffects();
            //StartCoroutine("IAutoPlayEffects");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(previousKey))
        {
            StopAllCoroutines();
//            StopCoroutine("IAutoPlayEffects");
            PlayPreviousEffect();
        }
        if (Input.GetKeyDown(nextKey))
        {
            StopAllCoroutines(); 
            //StopCoroutine("IAutoPlayEffects");
            PlayNextEffect();
        }
        if (Input.GetKeyDown(nextType))
        {
            StopAllCoroutines(); 
            //StopCoroutine("IAutoPlayEffects");
            PlayNextType();
        }
        if (Input.GetKey(multiNextKey))
        {
            StartCoroutine("IMultiTransitions");
        }
    }

    public void AutoPlay(bool value)
    {
        if (value)
        {
            StopAllCoroutines();
            _autoPlay = true;
            AutoPlayEffects();

        }
        else
        {
            _autoPlay = false;
            StopAllCoroutines();
        }
    }

    IEnumerator IMultiTransitions()
    {
        if (!isTransitioning)
        {
            isTransitioning = true;
            Debug.Log("MultiTransition called");
            for (int i = 0; i < numOfMultiTransitions; i++)
            {
                Debug.Log("MultiTransition i = " + i);
                NextEffects();
                yield return new WaitForSeconds(multiTransitionWaitTime);

            }
            isTransitioning = false;
            StartCoroutine("INextEffect");
        }
        
    }

    IEnumerator INextEffect()
    {
        yield return new WaitForSeconds(effectDuration);
        PlayNextEffect();
    }

    public void AutoPlayEffects()
    {
        if (useMultiTransitions)
        {
            StartCoroutine("IMultiTransitions");
        }
        else
        {

            StartCoroutine("INextEffect");
            //            yield return new WaitForSeconds(effectDuration);
            //          PlayNextEffect();
            //StartCoroutine("IAutoPlayEffects");
        }

    }

    public void PlayNextType()
    {
        if (!useMultiTransitions)
        {
            StopAllCoroutines();
        }
        

        if (useTransitions)
        {
            _cameraDirector.playableAsset = nextTypeTimeline;
            _cameraDirector.Play();
        }
        else
        {
            NextType();
        }

        if (_autoPlay)
        {
            //////////
            //AutoPlayEffects();
            //////////


            //StartCoroutine("IAutoPlayEffects");
        }
    }

    public void NextType()
    {
        effectGroup[currentEffectType].CleanupAndDelete();
        effectGroup[currentEffectType].gameObject.SetActive(false);
        currentEffectType++;
        if (currentEffectType > effectGroup.Length - 1)
        {
            currentEffectType = 0;
        }
        effectGroup[currentEffectType].gameObject.SetActive(true);

        //Debug.Log("next type called");
    }

    public void PlayNextEffect()
    {
        //        StopAllCoroutines();
        if (effectGroup[currentEffectType].current > effectGroup[currentEffectType].numOfEffects - 1)
        {
            PlayNextType();
        }
        else
        {
            if (useTransitions)
            {
                _cameraDirector.playableAsset = nextTimeline;
                _cameraDirector.Play();
            }
            else
            {
                NextEffects();
            }
            
            if (_autoPlay)
            {
                //////////
                //AutoPlayEffects();
                //////////

                //StartCoroutine("IAutoPlayEffects");
            }
        }
    }

    public void PlayPreviousEffect()
    {
        if (useTransitions)
        {
            _cameraDirector.playableAsset = previuosTimeline;
            _cameraDirector.Play();
        }
        else
        {
            PreviousEffects();
        }
        
        if (_autoPlay)
        {
            AutoPlayEffects();
            //StartCoroutine("IAutoPlayEffects");
        }
    }

    public void NextEffects()
    {
        effectGroup[currentEffectType].NextEffect();

    }

    public void PreviousEffects()
    {
        effectGroup[currentEffectType].PreviousEffect();

    }

}
