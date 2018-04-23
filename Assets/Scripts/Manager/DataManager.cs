using Boo.Lang;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public static DataManager ShareInstance
    {
        get { return instance; }
    }
    
    public CharacterData PlayerData;
    [SerializeField] public CharacterData[] EnemyDatas;

    private void Awake()
    {
        instance = FindObjectOfType<DataManager>();
    }

}