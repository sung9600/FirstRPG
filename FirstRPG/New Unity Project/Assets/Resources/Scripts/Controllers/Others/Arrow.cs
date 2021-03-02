using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * 30f, ForceMode.Impulse);
        GetComponent<Rigidbody>().useGravity = false;
        Destroy(gameObject, 1f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("wall") || collision.transform.CompareTag("enemy"))
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
}
