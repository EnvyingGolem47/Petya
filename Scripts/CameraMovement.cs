using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public GameObject su;
    private GameObject oldmoveorder;
    private GameObject moveorder;
    private new Camera camera;
    public GameObject movetoherecube;
    public ManagerScript managerblock;
    public SelectUNIT unitselect;
    private Transform test;
    public float panSpeed = 20f;
    public float scrollSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        unitselect = GetComponent<SelectUNIT>();
    }

    // Update is called once per frame

    void Update()
    {

        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        if(Input.GetKey("e"))
        {
            managerblock.OpenPauseMenu();
        }

        if(Input.GetKey("c"))
        {
            unitselect.SelectAll();
        }

        if(Input.GetKey("x"))
        {
            unitselect.DeSelectAll();
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y += scroll * scrollSpeed * 100f * Time.deltaTime * -1;

        transform.position = pos;
    }



    public void PlaceMoveOrder()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit2;





            if (managerblock.currentselectedunits != null && Physics.Raycast(ray, out hit2))
            {
                print("placing move orders");

                if (managerblock.currentmoveorder != null)
                {
                    print("destroying");
                    Destroy(managerblock.currentmoveorder);
                }

                //GameObject moveorder = Instantiate(movetoherecube, hit2.point, Quaternion.LookRotation(hit2.normal));

                foreach(GameObject unit in managerblock.currentselectedunits)
                {
                   UNITinfo uninfo = unit.GetComponent<UNITinfo>();
                   if(uninfo != null)
                    {
                        //DummyMoveHere dummov = unit.GetComponentInChildren<DummyMoveHere>();
                        uninfo.destination = hit2.point;


                        if (uninfo.destination == null)
                        {
                            print("ERROR, MOVE ORDER NOT FOUND");
                            print(unit);
                        }

                        //dummov.gameObject.transform.SetPositionAndRotation(hit2.point, dummov.transform.rotation);
                        //dummov.gameObject.SetActive(true);

                    }
                }

                //managerblock.currentmoveorder = moveorder;
                //managerblock.curmovordtransform = moveorder.transform;
            }
        }
    }

    public void Construct(bool constructing, string building)
    {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit2;

            if (constructing == true && Physics.Raycast(ray, out hit2) && building == "Iron Factory")
            {
                print("Placing building");

                Instantiate(unitselect.IronFactory, new Vector3(hit2.point.x, hit2.point.y, hit2.point.z), new Quaternion());
                managerblock.Iron -= 6;
                constructing = false;

                print("Building Location" + hit2.point.x + hit2.point.y + hit2.point.z);
            }
    }
}
