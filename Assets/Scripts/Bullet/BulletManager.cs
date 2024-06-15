

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public int maxBullets = 5;

    public GameObject tank;

    private List<GameObject> bulletPool = new List<GameObject>();


    public void Start()
    {
        InitializeBulletPool();
    }
    //private void Update ()
    //{
    //    Fire();
    //}

    private void FixedUpdate()
    {
        Fire();

    }
    void InitializeBulletPool()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
            Debug.Log("Active bullet: " + bullet.name);
        }
    }
    public void Fire()
    {
        GameObject bullet = bulletPool.FirstOrDefault(b => !b.activeInHierarchy);
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = bulletSpawnPoint.rotation;
            bullet.SetActive(true);

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetTankReference(tank);
            }

            //StartCoroutine(ResetBullet(bullet, 0.01f));
        }
    }
    private IEnumerator ResetBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Deactivating bullet: " + bullet.name);

        bullet.SetActive(false);
    }

}
