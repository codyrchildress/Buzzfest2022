using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CcTimeSetter : MonoBehaviour
{
    TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(float textFloat)
    {
        _text.text = textFloat.ToString() + " seconds";
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
