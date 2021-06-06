using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float KralMetre;
    public float KoyluMetre;
    public float YemekSayisi = 1;
    public float AltinSayisi;
    public GameObject VillageSpawner;

    private GameObject kaybettin;
    
    void Start()
    {
        kaybettin = GameObject.Find("Kaybettin");
        VillageSpawner = GameObject.Find("VillagerSpawner");
        kaybettin.SetActive(false);
    }

    public bool Kabul(int altin, int yemek)
    {
        if (AltinSayisi < altin && YemekSayisi < yemek)
        {
            Debug.Log("Bendede yokki");
            Reddet();
            return false;
        }

        YemekSayisi -= yemek;
        AltinSayisi -= altin;
        

        if (YemekSayisi<= 0)
        {
            VillageSpawner.GetComponent<VillagerSpawner>().SpawnVillager = false;
            kaybettin.SetActive(true);
            kaybettin.GetComponent<Text>().text += "\n yemeğin bittiğinden açlıktan öldün";
        }

        KralMetre += 10;
        
        if (KralMetre >= 100)
        {
            VillageSpawner.GetComponent<VillagerSpawner>().SpawnVillager = false;
            kaybettin.SetActive(true);
            kaybettin.GetComponent<Text>().text += "\n Krall seni kıskanıp öldürttü.";
        }

        return true;
    }

    public void Reddet()
    {
        if (KoyluMetre<99)
        {
            KoyluMetre += 10;
        }
        else
        {
            VillageSpawner.GetComponent<VillagerSpawner>().SpawnVillager = false;
            kaybettin.SetActive(true);
            kaybettin.GetComponent<Text>().text += "\n Köylüler sinirlenip seni linç etti";
        }
    }
    

}
