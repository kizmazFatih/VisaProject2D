using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBullet : MonoBehaviour
{
    public GameObject bulletPrefab;

    public void InstanceToBullet()
    {
        Instantiate(bulletPrefab, transform.position + (transform.right * 0.2f), transform.rotation);

    }


}
