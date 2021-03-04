using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * 30f, ForceMode.Impulse);
        GetComponent<Rigidbody>().useGravity = false;
        Destroy(gameObject, 1f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Bullet"))
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("enemy"))
        {
            Debug.Log("hit enemy");
            other.GetComponent<EnemyController>().gothit(UserStat.Instance._atk);
            Destroy(gameObject);
        }
    }
}
