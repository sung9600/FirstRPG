using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControll : MonoBehaviour
{
    public Transform cameraArm;

    // Start is called before the first frame update
    void Start()
    {
        cameraArm = GameObject.Find("CameraPivot").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float camAngle = 3.0f * Input.GetAxis("Cam");
        cameraArm.rotation = Quaternion.Euler(cameraArm.transform.eulerAngles.x, cameraArm.transform.eulerAngles.y + camAngle, cameraArm.transform.eulerAngles.z);
    }
}
