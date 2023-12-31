using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HitPoints hitPoints;

    [HideInInspector]
    public Player character;

    public Image meterImage;

    public Text hpText;

    float maxHitPoints;


    void Start()
    {
        //maxHitPoints = character.maxHitPoints;
        if (character != null)
        {
            maxHitPoints = character.maxHitPoints;
        }
        else
        {
            Debug.LogError("Character reference is not assigned to the HealthBar.");
        }
    }

    //update fill of healthbar and text
    void Update()
    {
        if (character != null)
        {
            meterImage.fillAmount = hitPoints.value / maxHitPoints;
            hpText.text = "HP:" + (meterImage.fillAmount * 100);
        }
    }
}
