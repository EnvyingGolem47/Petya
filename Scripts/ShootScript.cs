using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public UNITinfo uinfo;
    private GameObject enemy;
    public float curdelay = 0f;
    private EnemyScript enemyinfo;
    public SphereCollisionDetection sphererange;
    public float nextimetofire;

    private float gundelay = 1f;
    private float damage = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        uinfo = gameObject.GetComponent<UNITinfo>();
        sphererange = GetComponentInChildren<SphereCollisionDetection>();   
    
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            enemy = sphererange.enemiesinrange[0];
        }
        catch
        {

        }

        //enemyinfo = uinfo.enemy2;
        //distance = Vector3.Distance(enemyinfo.gameObject.transform.position, transform.position);

        if (enemy != null && Time.time >= nextimetofire)
        {
            enemyinfo = enemy.GetComponentInParent<EnemyScript>();

            print("bang");

            uinfo.muzzleflash.Play();
            uinfo.gunsound.Play();
            enemyinfo.health -= damage;

            nextimetofire = Time.time + gundelay;
            print(nextimetofire);

        }
    }
}
