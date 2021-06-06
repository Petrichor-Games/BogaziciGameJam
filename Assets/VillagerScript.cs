using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerScript : MonoBehaviour
{
    public Villager VillagerClass;
    public GameObject KonusmaBalonu;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SoruSor", 2);
    }

    void SoruSor()
    {
        var soru = Instantiate(KonusmaBalonu, transform);
        soru.GetComponentInChildren<TextMesh>().text = VillagerClass.ask_food.ToString() + " Yemek istiyorum";
    }
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
