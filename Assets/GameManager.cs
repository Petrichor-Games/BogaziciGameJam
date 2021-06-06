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
    
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    public int bolumNum;
    public Text timeText;
    
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
                PARATEXT.GetComponent<Text>().text = AltinSayisi.ToString();
                YEMEKTEXT.GetComponent<Text>().text = YemekSayisi.ToString();
                timerIsRunning = true;
                timeRemaining = 60;
                break;
            default:
                bolumNum = 0;
                break;
        }
    }

    public void Reflesh()
    {
        PARATEXT.GetComponent<Text>().text = AltinSayisi.ToString();
        YEMEKTEXT.GetComponent<Text>().text = YemekSayisi.ToString();
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
    
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
            DisplayTime(timeRemaining);
        }
    }
    

}
