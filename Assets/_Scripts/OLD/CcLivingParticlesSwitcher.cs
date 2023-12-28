using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcLivingParticlesSwitcher : MonoBehaviour
{
    public Transform affector;
    public GameObject[] livingParticles;
    int currentLP;

    ParticleSystem ps;

    public KeyCode forwardKey;
    public KeyCode backKey;

    // Start is called before the first frame update
    void Start()
    {
        currentLP = 0;

        //ps = GetComponent<ParticleSystem>();
    }





    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(forwardKey))
        {
            NextEffect();
        }
        else if (Input.GetKeyDown(backKey))
        {
            PreviousEffect();
        }
    }

    public void NextEffect()
    {
        //disable current
        livingParticles[currentLP].SetActive(false);
        currentLP++;
        if (currentLP > livingParticles.Length - 1)
        {
            currentLP = 0;
        }
        //enable next
        LivingParticleController temp = livingParticles[currentLP].GetComponent<LivingParticleController>();
        temp.affector = affector;
        livingParticles[currentLP].SetActive(true);
        ps = livingParticles[currentLP].GetComponent<ParticleSystem>();
        ps.Play();
    }

    public void PreviousEffect()
    {
        //disable current
        livingParticles[currentLP].SetActive(false);
        currentLP--;
        if (currentLP < 0)
        {
            currentLP = livingParticles.Length - 1;
        }
        //enable next
        LivingParticleController temp = livingParticles[currentLP].GetComponent<LivingParticleController>();
        temp.affector = affector;
        livingParticles[currentLP].SetActive(true);
        ps = livingParticles[currentLP].GetComponent<ParticleSystem>();
        ps.Play();
    }
}
