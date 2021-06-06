using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerScript : MonoBehaviour
{
    public Villager VillagerClass;
    public GameObject KonusmaBalonu;
    public GameObject Soru;
    public GameManager GameManager;
    private bool kabulEtti;
    public bool hazirmi;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("SoruSor", 2);
        Invoke("sinirlen", 10);
    }

    void SoruSor()
    {
        var soru = Instantiate(KonusmaBalonu, transform);
        Soru = soru.transform.GetChild(0).gameObject;
        Soru.GetComponent<TextMesh>().text = VillagerClass.ask_food.ToString() + " Yemek istiyorum ve \n" + VillagerClass.ask_gold + " Altın istiyorum";
        hazirmi = true;
    }

    public void TesekkurEt()
    {
        hazirmi = false;
        Destroy(transform.gameObject, 1);
        kabulEtti = true;
        var gelen = GameManager.Kabul(VillagerClass.ask_gold,VillagerClass.ask_food);
        if (gelen)
        {
            Soru.GetComponent<TextMesh>().text = "Teşekkür ederim";
        }
        else
        {
            Soru.GetComponent<TextMesh>().text = "Fakir";
        }
    }

    public void sinirlen()
    {
        if (kabulEtti)
        {
            return;
        }
        hazirmi = false;
        Soru.GetComponent<TextMesh>().text = "Tamam öyle olsun";
        Destroy(transform.gameObject, 2);
        GameManager.Reddet();
    }
}
