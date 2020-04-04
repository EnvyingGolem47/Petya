using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnit : MonoBehaviour
{
    public Transform soldierspawnpoint;
    public GameObject soldierprefab;

    public GameObject tankprefab;
    public Transform tankspawnpoint;

    public ManagerScript manager;

    private SelectUNIT slunit;


    // Start is called before the first frame update
    void Start()
    {
        soldierspawnpoint = gameObject.transform;
        slunit = FindObjectOfType<SelectUNIT>().GetComponent<SelectUNIT>();
        manager = FindObjectOfType<ManagerScript>().GetComponent<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create(int unittype)
    {
        if(unittype == 0 && manager.Iron >= 2)
        {
            Vector3 spvect3 = soldierspawnpoint.position;
            Quaternion spquat = soldierspawnpoint.rotation;

            GameObject newsoldier = Instantiate(soldierprefab, soldierspawnpoint.transform.position, soldierspawnpoint.transform.rotation);
            newsoldier.transform.SetPositionAndRotation(soldierspawnpoint.transform.position, soldierspawnpoint.transform.rotation);

            manager.Iron -= 2;
        }
        else if(unittype == 1 && manager.Iron >= 5)
        {
            Vector3 spvect3 = soldierspawnpoint.position;
            Quaternion spquat = soldierspawnpoint.rotation;

            GameObject newtank = Instantiate(tankprefab, soldierspawnpoint.transform.position, soldierspawnpoint.transform.rotation);
            newtank.transform.SetPositionAndRotation(soldierspawnpoint.transform.position, soldierspawnpoint.transform.rotation);

            manager.Iron -= 5;
        }
    }

    public void Build(string building)
    {
        slunit.ConstructBuilding(building);
    }
}
