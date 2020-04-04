using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestruction : MonoBehaviour
{
    public ManagerScript managerblock;

    void Start()
    {
        managerblock = FindObjectOfType<ManagerScript>();
    }

    public void DestroyTree()
    {
        managerblock.globalwarminglevel += 1f;
        Destroy(gameObject);
    }

}
