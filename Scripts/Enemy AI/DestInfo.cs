using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestInfo : MonoBehaviour
{

    public List<EnemyScript> unitsassigned;
    public int WantedUnits;
    public int priority;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach(EnemyScript es in unitsassigned)
        {
            if(es == null)
            {
                unitsassigned.Remove(es);
            }
        }
    }
}
