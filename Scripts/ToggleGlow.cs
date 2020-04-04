using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGlow : MonoBehaviour
{
    public Material transparentmaterial;
    public Material yellow;
    public bool toggled;
    private Renderer rendererer;
    public UNITinfo parentsoldier;
    
    // Start is called before the first frame update
    void Start()
    {
        //toggled = false;

        rendererer = GetComponent<Renderer>();
        parentsoldier = GetComponentInParent<UNITinfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(parentsoldier.selected == true)
        {
            //gameObject.SetActive(true);
            rendererer.material = yellow;
        }
        else
        {
            //gameObject.SetActive(false);
            rendererer.material = transparentmaterial;
        }
    }

    public void toggle(bool onoroff)
    {
        //print("toggling");

        //if(onoroff == true)
        //{
        //    //gameObject.SetActive(true);
        //    toggled = true;
        //}
        //if(onoroff == false)
        //{
        //    //gameObject.SetActive(false);
        //    toggled = false;
        //}    
    }
}
