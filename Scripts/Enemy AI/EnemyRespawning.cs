using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawning : MonoBehaviour
{


    public GameObject SoldierPrefab;
    public Transform SoldierSpawnpoint;

    public List<EnemyScript> currentunits;
    public int maxsoldiers = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print("Current Units" + currentunits.Count);

        if(currentunits.Count < maxsoldiers)
        {
            SpawnEnemy(SoldierPrefab, SoldierSpawnpoint);
        }

        foreach(EnemyScript es in currentunits)
        {
            if(es == null)
            {
                currentunits.Remove(es);
            }
        }
    }

    private void SpawnEnemy(GameObject unit, Transform spawnpoint)
    {
        GameObject newunit = Instantiate(unit, spawnpoint.position, spawnpoint.rotation);
    }
}
