using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //키가 있는지 확인하고
            if (UserStat.Instance._Key > 0)
            {
                // 키가있으면 열고
                Debug.Log($"{UserStat.Instance._Key}");
                UserStat.Instance._Key--;
                Debug.Log($"{UserStat.Instance._Key}");
                InGame.ChangeKey(UserStat.Instance._Key);
                transform.Find("Treasure_Chest_Up").rotation = Quaternion.Euler(45, 45, 0);
                //코인 생성
                int _coinnum = Random.Range(3, 10);
                for (int i = 0; i < _coinnum; i++)
                {
                    GameObject coin = GameManager.Resource.Instantiate("Creature/Others/Coin", transform.Find("GameObject"));
                    coin.transform.position = transform.Find("GameObject").position + new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), 0);
                    coin.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0, 2f), 2f, Random.Range(0, 2f)));
                }
                // 상자 collider 삭제
                gameObject.GetComponent<BoxCollider>().enabled = false;

            }
            else
            {
                Debug.Log("abc");
                UI_Popup LackUI = GameManager.UI.ShowPopupUI<UI_Popup>("LackUI");
                LackUI.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "You need Key!";
                Destroy(LackUI.gameObject, 0.5f);
            }
        }
    }
}
