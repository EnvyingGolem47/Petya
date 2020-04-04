using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenterInfo : MonoBehaviour
{
    public float health;
    public int team; //Team 0 for player, Team 1 for enemy

    private UNITinfo uninfo;
    private ManagerScript manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<ManagerScript>();
        health = GetComponent<UNITinfo>().health;
        uninfo = GetComponent<UNITinfo>();

        uninfo.iscommandcenter = true;
    }

    // Update is called once per frame
    void Update()
    {
        health = GetComponent<UNITinfo>().health;

        if (health <= 0)
        {
            if(team == 0 && manager.gamemode == "Base Domination")
            {
                manager.lost = true;
                Destroy(gameObject);
            }
            else if(team == 1 && manager.gamemode == "Base Domination")
            {
                manager.won = true;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
