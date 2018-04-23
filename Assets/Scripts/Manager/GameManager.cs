using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private Player player;
    [SerializeField]
    private List<NPC> enemies;
    private NPC currentTarget;
    
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject EmemyPrefab;

	// Use this for initialization
	void Start ()
	{
	    player.SetupData(DataManager.ShareInstance.PlayerData);
	    for (int i = 0; i < enemies.Count; i++)
	    {
	        enemies[i].SetupData(DataManager.ShareInstance.EnemyDatas[i]);
	    }
	    UIManager.ShareInstance.ShowPlayerStatuView(DataManager.ShareInstance.PlayerData);
	    UIManager.ShareInstance.HideEnemyStatuView();
	}
	
	// Update is called once per frame
	void Update () {
        ClickTarget();
    }

    private void ClickTarget()
    {
        //未点击ui组件
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            //获取屏幕点击位置,设定敌人
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity,512);
            if (hit.collider)
            {
                if (currentTarget)
                {
                    currentTarget.DeSelect();
                }

                currentTarget = hit.collider.GetComponent<Enemy>();

                player.Target = currentTarget.Select();
            }
            else
            {
                if (currentTarget != null)
                {
                    currentTarget.DeSelect();
                }

                currentTarget = null;
                player.Target = null;
            }
        }
    }
}
