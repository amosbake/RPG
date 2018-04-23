using UnityEngine;
using UnityEngine.UI;

public class EmenyStatuView : MonoBehaviour
{
    [SerializeField]
    private HealthStatusView healthView;
    [SerializeField]
    private ManaStatusView manaView;
    [SerializeField]
    private Image avator;
    [SerializeField]
    private Text name;
    [HideInInspector] private CharacterData enemyData;

    public void Setup(CharacterData data)
    {
        this.enemyData = data;
        if (avator)
        {
            avator.sprite = data.avatorSprite;
        }

        if (name)
        {
            name.text = data.name;
        }

        if (healthView)
        {
            healthView._status = data.healthStatus;
        }

        if (manaView)
        {
            manaView._status = data.manaStatus;
        }
    }
}