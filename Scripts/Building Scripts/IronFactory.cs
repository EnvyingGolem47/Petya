using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronFactory : MonoBehaviour
{
    public int ironaminute;
    
    private ManagerScript manager;
    public int currentminute;
    public int nextminute;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<ManagerScript>().GetComponent<ManagerScript>();
        nextminute = 69;
    }

    // Update is called once per frame
    void Update()
    {
        if(nextminute != 69)
        {
            currentminute = DateTime.Now.Minute;
        }
        

        print("The Current Minute: " + currentminute);

        if(currentminute == nextminute || nextminute == 69)
        {
            currentminute = DateTime.Now.Minute;
            manager.Iron += ironaminute;
            nextminute = currentminute + 1;
            if(currentminute > 59)
            {
                nextminute = 0;
            }
        }
    }
}
