using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform player;
    private void Start()
    {
        player = GameObject.Find("Character").transform.Find("Player");
        StartCoroutine(MoveToPlayer());
    }
    IEnumerator MoveToPlayer()
    {
        yield return new WaitForSeconds(1f);
        while ((player.position - transform.position).magnitude > 1f) //도착할때까지
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.5f);
            yield return null;
        }
        UserStat.Instance._Coin++;
        InGame.ChangeCoin(UserStat.Instance._Coin);
        Destroy(this.gameObject);
    }
}
