using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public delegate void OnReachMaxValue(string StatusName,float maxValue);
public delegate void OnReachZeroValue(string StatusName);
public delegate void OnChangeValue(string StatusName,float deltaChange);

[Serializable]
public class Status
{
    [SerializeField]
    private string StatusName; 
    [SerializeField]
    private float CurrentStatusValue; 
    [SerializeField]
    private float MaxStatusValue;

    public event OnReachMaxValue OnReachMaxValue;
    public event OnReachZeroValue OnReachZeroValue;
    public event OnChangeValue OnChangeValue;

    public float StatusPercent
    {
        get { return Mathf.Clamp01(CurrentStatusValue / MaxStatusValue); }
    }

    public float Max
    {
        get { return MaxStatusValue; }
    }

    public float Current
    {
        get { return CurrentStatusValue; }
    }

    public void Init()
    {
        CurrentStatusValue = MaxStatusValue;
    }

    public void ChangeValue(float deltaValue)
    {
        float tempResult = CurrentStatusValue + deltaValue;
        float actualDeltaValue = 0f;
        if (tempResult >= MaxStatusValue)
        {
            actualDeltaValue = MaxStatusValue - CurrentStatusValue;
          
            if (actualDeltaValue > float.Epsilon)
            {
                if (OnReachMaxValue != null)
                {
                    OnReachMaxValue(StatusName, MaxStatusValue);
                }
                if (OnChangeValue != null)
                {
                    OnChangeValue(StatusName,actualDeltaValue);
                }
            }
            
            CurrentStatusValue = MaxStatusValue;
            
        }
        
        else if (tempResult <= 0)
        {
            actualDeltaValue = -CurrentStatusValue;
            if (actualDeltaValue < -float.Epsilon)
            {
                if (OnReachZeroValue != null)
                {
                    OnReachZeroValue(StatusName);
                }
                if (OnChangeValue != null)
                {
                    OnChangeValue(StatusName,actualDeltaValue);
                }
            }

            CurrentStatusValue = 0;
        }
        else
        {
            actualDeltaValue = deltaValue;
            if (OnChangeValue != null)
            {
                OnChangeValue(StatusName,actualDeltaValue);
            }

            CurrentStatusValue += actualDeltaValue;
        }
        
    }
    
    
}
