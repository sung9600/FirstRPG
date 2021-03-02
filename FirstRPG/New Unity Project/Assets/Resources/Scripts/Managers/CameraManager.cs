using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance = null;
    public Camera[] camArr; // maincam은 0번 -> quest -> 여기서부턴 나중에...
    public int currentIdx;
    // 렌더링 될 cam은 1로, 나머지는 0으로 세팅하자
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static CameraManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    private void Start()
    {
        currentIdx = 0;
        foreach (Camera cam in camArr)
        {
            cam.depth = 0;
        }
        camArr[0].depth = 1;
    }

    // 영역 colliding 시 해당 gameobject의 child로 cam둬서 바꾸자

    public void CamChange(int camidx) // 새로 켤 카메라 idx를 인자로
    {
        //Debug.Log($"Change Cam{camidx}");
        //Debug.Log($"{camArr[currentIdx].depth} {camArr[camidx].depth}");
        camArr[camidx].depth ++;
        camArr[currentIdx].depth --;
    }
}
