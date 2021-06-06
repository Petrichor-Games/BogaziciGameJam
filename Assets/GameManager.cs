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

    public GameObject HalkBar;
    public GameObject KralBar;

    public GameObject PARATEXT;
    public GameObject YEMEKTEXT;

    private GameObject kaybettin;

    public int bolumNum;
    
    void Start()
    {
        switch (bolumNum)
        {
            case 1 :
                kaybettin = GameObject.Find("Kaybettin");
                VillageSpawner = GameObject.Find("VillagerSpawner");
                kaybettin.SetActive(false);
                KralBar.GetComponent<Slider>().value = KralMetre;
        
                HalkBar.GetComponent<Slider>().value = KoyluMetre;

                PARATEXT.GetComponent<Text>().text = AltinSayisi.ToString();
                YEMEKTEXT.GetComponent<Text>().text = YemekSayisi.ToString();
                break;
            case 2:
                
                break;
            default:
                bolumNum = 0;
                break;
        }
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
        KralBar.GetComponent<Slider>().value = KralMetre;
        HalkBar.GetComponent<Slider>().value = KoyluMetre;
        PARATEXT.GetComponent<Text>().text = AltinSayisi.ToString();
        YEMEKTEXT.GetComponent<Text>().text = YemekSayisi.ToString();
        return true;
        
    }

    public void Reddet()
    {
        if (KoyluMetre<99)
        {
            KoyluMetre += 10;
            KralBar.GetComponent<Slider>().value = KralMetre;
            HalkBar.GetComponent<Slider>().value = KoyluMetre;
        }
        else
        {
            VillageSpawner.GetComponent<VillagerSpawner>().SpawnVillager = false;
            kaybettin.SetActive(true);
            kaybettin.GetComponent<Text>().text += "\n Köylüler sinirlenip seni linç etti";
        }
    }
    

}
