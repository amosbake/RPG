using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    
    private static UIManager instance;

    public static UIManager ShareInstance
    {
        get { return instance; }
    }
    
    [SerializeField]
    private Button[] actionBtns;
    [SerializeField]
    private PlayerStatuView _playerStatuView;
    [SerializeField]
    private EmenyStatuView _emenyStatuView;

    private KeyCode action1, action2, action3;

    private void Awake()
    {
        instance = FindObjectOfType<UIManager>();
    }

    // Use this for initialization
    void Start () {
        
        action1 = KeyCode.Alpha1;
        action2 = KeyCode.Alpha2;
        action3 = KeyCode.Alpha3;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(action1))
        {
            ActionButtonOnClick(0);
        }
        if (Input.GetKeyDown(action2))
        {
            ActionButtonOnClick(1);
        }
        if (Input.GetKeyDown(action3))
        {
            ActionButtonOnClick(2);
        }
    }

    public void ShowPlayerStatuView(CharacterData characterData)
    {
        if (_playerStatuView)
        {
            _playerStatuView.Setup(characterData);
        }
      
    }
    
    public void ShowEnemyStatuView(CharacterData characterData)
    {
        if (_emenyStatuView)
        {
            _emenyStatuView.Setup(characterData);
            _emenyStatuView.gameObject.SetActive(true);
        }
     
    }
    
    public void HideEnemyStatuView()
    {
        if (_emenyStatuView)
        {
            _emenyStatuView.gameObject.SetActive(false);
        }
    }

    

    private void ActionButtonOnClick(int btnIndex)
    {
        //运行绑定时间
        actionBtns[btnIndex].onClick.Invoke();
    }
}
