using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollisionDetection : MonoBehaviour
{
    public List<GameObject> enemiesinrange;
    public bool iscommandcenter = false;
    private void Update()
    {
        foreach(GameObject enemy in enemiesinrange)
        {
            //print(enemiesinrange[enemiesinrange.IndexOf(enemy)]);
            if(enemiesinrange[enemiesinrange.IndexOf(enemy)] == null)
            {
                enemiesinrange.Remove(enemy);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other + "triggered enter");

        EnemyScript enemy = other.GetComponentInParent<EnemyScript>();
        GameObject enemybody = other.GetComponentInParent<Transform>().gameObject;

        if (enemy != null && !enemiesinrange.Contains(enemybody))
        {
            enemiesinrange.Add(other.GetComponentInParent<Transform>().gameObject);
            enemy.targets.Add(GetComponentInParent<UNITinfo>());
            print(other + "in range");
        }

        if(enemy != null && iscommandcenter == true)
        {
            enemy.targets.Add(GetComponentInParent<UNITinfo>());
            print(other + "in range of Command Center");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        EnemyScript enemy = other.GetComponentInParent<EnemyScript>();
        GameObject enemybody = other.GetComponentInParent<Transform>().gameObject;

        if (enemiesinrange.Contains(enemybody))
        {
            enemiesinrange.Remove(enemybody);

            enemy.targets.Remove(GetComponentInParent<UNITinfo>());

            print(other + "outofrange");
        }
    }
}
