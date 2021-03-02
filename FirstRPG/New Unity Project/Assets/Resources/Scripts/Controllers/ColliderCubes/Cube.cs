using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public int camnum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            CameraManager.Instance.CamChange(camnum);
            ShowUI();
        }
    }
    public virtual void ShowUI()
    {
    }
    public void init()
    {

    }
}
