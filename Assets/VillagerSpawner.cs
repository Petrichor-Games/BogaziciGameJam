using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour
{
    public List<GameObject> VillagerPrefabs;
    public bool SpawnVillager = true;

    void Start()
    {
        
        InvokeRepeating("CreateVillager", 2.0f, 5f);
    }
    
    public void CreateVillager()
    {
        if (GameObject.FindWithTag("Villager") == null && SpawnVillager == true )
        {
            int rand_ask_gold = Random.Range(0,25);
            int rand_ask_food = Random.Range(0,25);
            Villager villager1 = new Villager(rand_ask_gold,rand_ask_food);

            Instantiate(VillagerPrefabs[Random.Range(0, 7)], transform);
            GameObject.FindWithTag("Villager").GetComponent<VillagerScript>().VillagerClass = villager1;
        }
    }

    
}
public class Villager
{
    public int ask_gold;
    public int ask_food;

    public Villager(int ask_gold, int ask_food)
    {
        this.ask_gold = ask_gold;
        this.ask_food = ask_food;
    }
}
