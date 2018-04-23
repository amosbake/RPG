using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character {

    
    public virtual void DeSelect()
    {
        UIManager.ShareInstance.HideEnemyStatuView();
    }

    public virtual Transform Select()
    {
        UIManager.ShareInstance.ShowEnemyStatuView(_characterData);
        return hitBox;
    }

    protected override void OnDestroy()
    {
        UIManager.ShareInstance.HideEnemyStatuView();
        base.OnDestroy();
    }
}
