using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;


        GameObject player = GameManager.Resource.Instantiate("Creature/Player", GameObject.Find("Character").transform);
        player.name = "Player";
        player.transform.localPosition = new Vector3(0, 0, 0);
        GameManager.Object.Add(player);
        UI_Scene ingameUI = GameManager.UI.ShowSceneUI<UI_Scene>("InGame");
    }

    public override void Clear()
    {

    }
}
