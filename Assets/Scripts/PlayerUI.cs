//using Newtonsoft.Json.Bson;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Drawing;
using Color = UnityEngine.Color;
using Image = UnityEngine.UI.Image;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [Header("Rifle Slider:")]
    [SerializeField] private Slider rifleChargeSlider;
    [SerializeField] private TMP_Text rifleText;
    [SerializeField] private Image rifleFill;
    [Header("Shotgun Slider:")]
    [SerializeField] private Slider shotgunChargeSlider;
    [SerializeField] private TMP_Text shotgunText;
    [SerializeField] private Image shotgunFill;
    [Header("Chargebar color:")]
    [SerializeField] private Color colorSliderNotCharging;
    [SerializeField] private Color colorSliderCharging;
    [SerializeField] private float chargeColorBlinkSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateShotgunChargeBar();
        UpdateRifleChargeBar();
        HighlightSelectedWeapon();
    }


    void UpdateRifleChargeBar()
    {
        // Update the value of the chargebar slider:
        float rifleCharge = player.GetComponent<PlayerFireController>().GetRifle().GetCharge();
        float rifleMaxCharge = player.GetComponent<PlayerFireController>().GetRifle().GetMaxCharge();
        rifleChargeSlider.value = rifleCharge / rifleMaxCharge; //Normalize (0-1)

        // Change color when charging and not charging:
        bool rifleIsCharging = player.GetComponent<PlayerFireController>().GetRifle().GetIsCharging();
        if (rifleIsCharging == true)
        {
            rifleFill.color = Color.Lerp(colorSliderCharging, colorSliderNotCharging, Mathf.PingPong(Time.time * chargeColorBlinkSpeed, 1f));
        }
        if (rifleIsCharging == false)
        {
            rifleFill.color = colorSliderNotCharging;
        }
    }

    void UpdateShotgunChargeBar()
    {
        // Update the value of the chargebar slider:
        float shotgunCharge = player.GetComponent<PlayerFireController>().GetShotgun().GetCharge();
        float shotgunMaxCharge = player.GetComponent<PlayerFireController>().GetShotgun().GetMaxCharge();
        shotgunChargeSlider.value = shotgunCharge / shotgunMaxCharge; //Normalize (0-1)

        // Change color when charging and not charging:
        bool shotgunIsCharging = player.GetComponent<PlayerFireController>().GetShotgun().GetIsCharging();
        if  ( shotgunIsCharging == true)
        {
            shotgunFill.color = Color.Lerp(colorSliderCharging, colorSliderNotCharging, Mathf.PingPong(Time.time * chargeColorBlinkSpeed, 1f));
        }
        if (shotgunIsCharging == false)
        {
            shotgunFill.color = colorSliderNotCharging;
        }
    }
    
    void HighlightSelectedWeapon()
    {
        if (0 == player.GetComponent<PlayerFireController>().GetSelectedWeapon())
        {
            rifleText.fontStyle = FontStyles.Bold;
            shotgunText.fontStyle = FontStyles.Normal;
        }
        if (1 == player.GetComponent<PlayerFireController>().GetSelectedWeapon())
        {
            rifleText.fontStyle = FontStyles.Normal;
            shotgunText.fontStyle = FontStyles.Bold;
            
        }

    }

}
