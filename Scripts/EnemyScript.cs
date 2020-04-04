using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public float health = 25f;
    public string unittype = "EnemySoldier";
    private NavMeshAgent nva;
    public ManagerScript managerblock;
    public float range = 10f;
    public Transform spawnpoint;
    public ParticleSystem muzzleflash;
    public AudioSource gunsound;
    
    public EnemyRespawning enemyrespawn;
    public List<UNITinfo> targets;
    public EnemyDestManager Command;

    private Transform MoveOrders;
    private int destnum;
    private EnemyShooting selfshoot; 


    // Start is called before the first frame update
    void Start()
    {
        managerblock = FindObjectOfType<ManagerScript>();
        selfshoot = GetComponent<EnemyShooting>();
        enemyrespawn = FindObjectOfType<EnemyRespawning>();
        enemyrespawn.currentunits.Add(gameObject.GetComponent<EnemyScript>());
        Command = FindObjectOfType<EnemyDestManager>();
        nva = GetComponent<NavMeshAgent>();

        if (Command == null)
        {
            print("Lost contact!" + "-- Missing EnemyDestManager");
        }

        //System.Random rnd = new System.Random();
        //destnum = rnd.Next(Command.destinations.Count);

        //if(Command.destinations[destnum].GetComponent<DestInfo>().unitsassigned.Count < Command.destinations[destnum].GetComponent<DestInfo>().WantedUnits)
        //{
        //    Command.destinations[destnum].GetComponent<DestInfo>().unitsassigned.Add(GetComponent<EnemyScript>());
        //    MoveOrders = Command.destinations[destnum].transform;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0f)
        {
            try
            {
                enemyrespawn.currentunits.Remove(gameObject.GetComponent<EnemyScript>());
            }
            catch(Exception e)
            {
                print("I think I just lost my kid..." + e);
            }
            DestroyObject();
        }

        try
        {
            if(targets[0] != null)
            {
                LookTowardsEnemy(targets[0].transform);
                print("ShootBangPow");
                selfshoot.ShootEnemy(targets[0]);
            }
        }
        catch
        {

        }

        if (MoveOrders == null)
        {
            System.Random rnd = new System.Random();
            destnum = rnd.Next(Command.destinations.Count);

            if (Command.destinations[destnum].GetComponent<DestInfo>().unitsassigned.Count < Command.destinations[destnum].GetComponent<DestInfo>().WantedUnits)
            {
                Command.destinations[destnum].GetComponent<DestInfo>().unitsassigned.Add(GetComponent<EnemyScript>());
                MoveOrders = Command.destinations[destnum].transform;
                nva.SetDestination(new Vector3(MoveOrders.position.x, MoveOrders.position.y, MoveOrders.position.z));
            }
        }
    }

    private void DestroyObject()
    {
        managerblock.currentenemies.Remove(gameObject);
        Destroy(gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.GetComponentInParent<UNITinfo>() != null)
    //    {

    //        if(true)
    //        {
    //            targets.Add(collision.gameObject);
    //            //debug
    //            print("added" + collision.gameObject + "to targets list");
    //            //end debug
    //        }

    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    try
    //    {
    //        targets.Remove(collision.gameObject);
    //    }
    //    catch (Exception e)
    //    {
    //        print("ngl, this should not have been nulled" + e);
    //    }
    //}


    public void LookTowardsEnemy(Transform enemy)
    {
        transform.LookAt(enemy);
    }
}
