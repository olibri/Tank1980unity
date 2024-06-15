
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 20.0f;
    public float MaxDistance = 1.0f;

    private Vector3 launchPosition;
    private GameObject tank;


    void OnEnable()
    {
        launchPosition = transform.position + transform.forward * 1.445f;
        transform.position = launchPosition;
    }
    public void SetTankReference(GameObject tankObject)
    {
        tank = tankObject;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name);
        if (collision.gameObject != tank)
        {

            var tankHealth = collision.gameObject.GetComponent<TankHealth>();
            if (tankHealth != null)
            {
                tankHealth.TakeDamage(0.1f);
            }
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (tank != null)
        //{
        //    Vector3 direction = tank.transform.forward;
        //    transform.forward = direction;
        //}
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;

        if (Vector3.Distance(launchPosition, transform.position) >= MaxDistance)
        {
            gameObject.SetActive(false);
        }
    }
}
