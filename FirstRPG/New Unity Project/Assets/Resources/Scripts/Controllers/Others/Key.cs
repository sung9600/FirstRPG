using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Vector3 _initPos;
    void Start()
    {
        _initPos = transform.position;
        StartCoroutine("Rotate");
        StartCoroutine("Patrol");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UserStat.Instance._Key++;
            InGame.ChangeKey(UserStat.Instance._Key);
            Destroy(gameObject);
        }
    }

    public IEnumerator Rotate()
    {
        yield return null;
        while (true)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 100f);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator Patrol()
    {
        yield return null;
        while (true)
        {
            Vector3 vector = _initPos;
            vector.y += 0.5f * (Mathf.Sin(Time.time) + 1);
            transform.position = vector;
            yield return new WaitForEndOfFrame();
        }
    }
}
