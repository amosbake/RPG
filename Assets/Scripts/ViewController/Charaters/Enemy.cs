using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    [SerializeField]
    private CanvasGroup healthGroup;
    [SerializeField] private StatusView HealthStatusView;


    public override void DeSelect()
    {
        healthGroup.alpha = 0;
        base.DeSelect();
    }

    public override Transform Select()
    {
        HealthStatusView._status = _characterData.healthStatus;
        healthGroup.alpha = 1;
        return base.Select();
    }
}
