using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerScript : MonoBehaviour
{
    public Villager VillagerClass;
    public GameObject KonusmaBalonu;
    public GameObject Soru;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SoruSor", 2);
        Invoke("sinirlen", 10);
    }

    void SoruSor()
    {
        var soru = Instantiate(KonusmaBalonu, transform);
        Soru = soru.transform.GetChild(0).gameObject;
        Soru.GetComponent<TextMesh>().text = VillagerClass.ask_food.ToString() + " Yemek istiyorum";
    }

    void sinirlen()
    {
        Soru.GetComponent<TextMesh>().text = "Tamam öyle olsun";
        Destroy(transform.gameObject, 2);
    }
}
