using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //gamemanager 싱글턴
    static GameManager g_instance;
    static GameManager Instance
    {
        get { Init(); return g_instance; }
    }

    PoolManager _pool = new PoolManager();
    InputManager _input = new InputManager();
    SceneManagerEx _scene = new SceneManagerEx();
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();
    ObjectManager _obj = new ObjectManager();
    public static PoolManager Pool { get { return Instance._pool; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static ObjectManager Object { get { return Instance._obj; } }
    public static InputManager Input { get { return Instance._input; } }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    static void Init()
    {
        if (g_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(go);
            g_instance = go.GetComponent<GameManager>();
            g_instance._pool.Init();
            g_instance._input.Init();
        }
    }

    public static void Clear()
    {
        Scene.Clear();
        UI.Clear();
        Pool.Clear();
    }
    private void Update()
    {
        Input.OnUpdate();
    }
}
