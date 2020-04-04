using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    /*
     Enemy in this context refers to the target that this object is shooting at
     */
    
    public EnemyScript uinfo;
    public float curdelay = 0f;
    public float damage = 2.5f;

    private float gundelay = 1f;
    private float nextimetofire;
    private UNITinfo enemyinfo;
    private GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        uinfo = gameObject.GetComponent<EnemyScript>();
    }

    public void ShootEnemy(UNITinfo enemy)
    {
        if (enemy != null && Time.time >= nextimetofire)
        {
            print("bang enemy");

            uinfo.muzzleflash.Play();
            uinfo.gunsound.Play();
            enemy.health -= damage;

            nextimetofire = Time.time + gundelay;
            print(nextimetofire);

        }
    }
}
