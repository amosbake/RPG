using System;
using UnityEngine;

public delegate void OnCharacterDie();

[Serializable]
public class CharacterData
{
    [SerializeField] public string name;
    [SerializeField] public Status healthStatus;
    [SerializeField] public Status manaStatus;
    [SerializeField] public Sprite avatorSprite;
    
    [SerializeField] public Vector3 spawnPosition;
    [SerializeField] public Vector3 currentPosition;
    
    
    public event OnCharacterDie OnCharacterDie;
    
    public void TakeDamage(float damage)
    {
        healthStatus.ChangeValue(-damage);
    }

    public void SetupData()
    {
        if (healthStatus != null)
        {
            healthStatus.Init();
            healthStatus.OnReachZeroValue += OnDie;
        }

        if (manaStatus != null)
        {
            manaStatus.Init();
        }
        
        currentPosition = spawnPosition;
    }
    
    void OnDie(string StatusName)

    {
        if (OnCharacterDie != null)
        {
            OnCharacterDie();
        }
        
        healthStatus.OnReachZeroValue -= OnDie;
    }
}