using System;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UNITinfo : MonoBehaviour
{
    public float health = 25f;
    public string unittype = "Soldier";
    public ManagerScript managerblock;
    public GameObject enemy;
    public GameObject gun;
    public float gundelay = 0f;
    public ParticleSystem muzzleflash;
    public AudioSource gunsound;
    public float distance;
    public UnityEngine.Object[] enemies;
    public Vector3 destination;
    public bool selected;
    public List<float> disttoeachenemy;
    public bool iscommandcenter = false;

    private SphereCollisionDetection sphererange;
    private NavMeshAgent nva;


    // Start is called before the first frame update
    void Start()
    {
        nva = GetComponent<NavMeshAgent>();
        destination = gameObject.transform.position;
        sphererange = GetComponentInChildren<SphereCollisionDetection>();
        managerblock = FindObjectOfType<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        try
        {
            if(iscommandcenter == false)
            {
                nva.SetDestination(destination);
                nva.speed = 5f;
            }

        }
        catch
        {

        }

        try
        {
            if(iscommandcenter == false)
            {
                GameObject firstenemy = sphererange.enemiesinrange[0];
                LookTowardsEnemy(firstenemy.transform);
            }

        }
        catch
        {
            
        }
        
        try
        {
            if(health <= 0.0f && iscommandcenter == false)
            {
                Destroy(gameObject);

                print("Destroying:" + gameObject + "At:" + health + " Health");
            }
        }
        catch(Exception e)
        {
            print("OH FUCK! EVERYTHINGS BROKEN! SHIT FUCK SHIT!");
            print(e);
        }
    }

    public void SelectUnit()
    {
        print("I've been touched");

        if(selected == false)
        {
            selected = true;
            managerblock.currentselectedunits.Add(gameObject);

            print("selected" + gameObject);
        }
        else
        {
            if(selected == true)
            {
                selected = false;
                managerblock.currentselectedunits.Remove(gameObject);

                print("un-selected" + gameObject);
            }
        }
    }

    public void ForceDeSelect()
    {
        selected = false;
        managerblock.currentselectedunits.Remove(gameObject);

        print("Force Un-Selected" + gameObject);
    }

    public void LookTowardsEnemy(Transform enemy)
    {
        transform.LookAt(enemy.GetComponentInChildren<DummyChest>().transform);
    }

}
