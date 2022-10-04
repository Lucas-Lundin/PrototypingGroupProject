using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Slider rifleChargeSlider;
    [SerializeField] private Slider shotgunChargeSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateShotgunChargeBar();
        UpdateRifleChargeBar();
    }


    void UpdateRifleChargeBar()
    {
        float rifleCharge = player.GetComponent<PlayerFireController>().GetRifle().GetCharge();
        float rifleMaxCharge = player.GetComponent<PlayerFireController>().GetRifle().GetMaxCharge();
        rifleChargeSlider.value = rifleCharge / rifleMaxCharge; //Normalize (0-1)
    }

    void UpdateShotgunChargeBar()
    {
        float shotgunCharge = player.GetComponent<PlayerFireController>().GetShotgun().GetCharge();
        float shotgunMaxCharge = player.GetComponent<PlayerFireController>().GetShotgun().GetMaxCharge();
        shotgunChargeSlider.value = shotgunCharge / shotgunMaxCharge; //Normalize (0-1)
    }
 

}
