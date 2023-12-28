using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CcSetConstraintToGrandparent : MonoBehaviour
{
    ParentConstraint parentConstraint;
    ConstraintSource constraintSource;


    private void Awake()
    {
        parentConstraint = GetComponent<ParentConstraint>();
    }

    // Start is called before the first frame update
    void Start()
    {

        constraintSource.sourceTransform = gameObject.transform.root;
        constraintSource.weight = 1;
        parentConstraint.AddSource(constraintSource);

        parentConstraint.constraintActive = true;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
