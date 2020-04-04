using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SelectUNIT : MonoBehaviour
{
    public UNITinfo selectedunitinfo;
    public CameraMovement cammov;
    private new Camera camera;
    public GameObject selectedunit;
    public ManagerScript managerblock;
    public List<UNITinfo> slaldum;
    public bool curbuilding;
    public string selectedbuilding;

    //Buildings
    public GameObject IronFactory;

    private void Start()
    {
        camera = gameObject.GetComponent<Camera>();
        cammov = GetComponent<CameraMovement>();
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            try
            {
                if(curbuilding == true)
                {
                    cammov.Construct(true, "Iron Factory");
                    curbuilding = false;
                }


                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                print("Yeeted the ray");

                if (Physics.Raycast(ray, out hit) && hit.transform.GetComponent<UNITinfo>())
                {
                    print("ray: " + ray);
                    
                    selectedunitinfo = hit.transform.GetComponent<UNITinfo>();

                    if (!managerblock.currentselectedunits.Contains(hit.transform.gameObject) && selectedunitinfo.selected != true && selectedunitinfo.iscommandcenter == false)
                    {

                        managerblock.currentselectedunits.Add(hit.transform.gameObject);
                        selectedunitinfo.SelectUnit();
                    }
                    else
                    {
                        if (managerblock.currentselectedunits.Contains(hit.transform.gameObject) && selectedunitinfo.selected == true && selectedunitinfo.iscommandcenter == false)
                        {
                            managerblock.currentselectedunits.Remove(hit.transform.gameObject);
                            selectedunitinfo.SelectUnit();
                        }
                        else
                        {
                            print("It could just be a command center calm down");
                            if(selectedunitinfo.iscommandcenter == false)
                            {
                                print("Ok well now we are fucked...");
                            }
                            else
                            {
                                print("Ok! We good!");
                            }
                            
                        }
                    }


                }
                else
                {
                    if (hit.transform.GetComponent<TreeDestruction>())
                    {

                        print("destroying tree");

                        TreeDestruction td = hit.transform.GetComponent<TreeDestruction>();
                        td.DestroyTree();

                        print(td);
                    }
                    else
                    {
                        if(curbuilding == true)
                        {
                            if(selectedbuilding == "Iron Factory")
                            {
                                if(managerblock.Iron >= 6)
                                {
                                    Instantiate(IronFactory, hit.transform.position, hit.transform.rotation);
                                    managerblock.Iron -= 6;
                                    curbuilding = false;

                                    print("Building Location" + hit.transform);

                                }
                                else
                                {
                                    print("Broke much?");
                                }
                                
                            }
                        }
                        else
                        {
                            cammov.PlaceMoveOrder();
                        }

                    }
                }
            }
            catch(Exception e)
            {
                print("SelectUNIT script error:"+e);
            }
        }
    }   

    public void SelectAll()
    {
        //List<UNITinfo> slaldum;
        slaldum.AddRange(FindObjectsOfType<UNITinfo>());
        foreach(UNITinfo unit in slaldum)
        {
            if(!managerblock.currentselectedunits.Contains(unit.gameObject) && unit.iscommandcenter == false)
            {
                managerblock.currentselectedunits.Add(unit.gameObject);
                unit.SelectUnit();
            }
        }
        //foreach()
    }

    public void DeSelectAll()
    {
        try
        {
            while (managerblock.currentselectedunits[0] != null && managerblock.currentselectedunits[1] != null)
            {
                foreach (GameObject unit in managerblock.currentselectedunits)
                {
                    UNITinfo uninfo = unit.GetComponent<UNITinfo>();
                    if (managerblock.currentselectedunits.Contains(unit))
                    {
                        managerblock.currentselectedunits.Remove(unit);
                        uninfo.ForceDeSelect();
                    }
                }
            }

        }
        catch
        {

        }
    }

    public void ConstructBuilding(string building)
    {
        if(building == "Iron Factory")
        {
            DeSelectAll();
            curbuilding = true;
            selectedbuilding = "Iron Factory";
        }
    }

}
