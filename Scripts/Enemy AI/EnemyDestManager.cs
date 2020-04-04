using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestManager : MonoBehaviour
{
    public List<Transform> destinations;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (DestInfo di in FindObjectsOfType<DestInfo>())
        {
            destinations.Add(di.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (DestInfo di in FindObjectsOfType<DestInfo>())
        {
            if(!destinations.Contains(di.transform) && !destinations.Contains(null))
            {
                destinations.Add(di.transform);
            }
            else if(destinations.Contains(null))
            {
                destinations.Remove(null);
            }
            
        }
    }
}
