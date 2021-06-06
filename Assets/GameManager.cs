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
        VillageSpawner = GameObject.Find("VillageSpawner");
        kaybettin.SetActive(false);
    }

    public void Kabul(int altin, int yemek)
    {
        if (AltinSayisi<altin && YemekSayisi< yemek)
        {
            Debug.Log("Bendede yokki");
            Reddet();
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
    }

    public void Reddet()
    {
        if (KoyluMetre<100)
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
    

    // Update is called once per frame
    void Update()
    {
        

       
    }
}
