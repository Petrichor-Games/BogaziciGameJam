using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rand : MonoBehaviour
{


    void Start()
    {
        
        CreateVillager();
    }

    // Update is called once per frame
    void Update()
    {

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


    public void CreateVillager()
    {

        int rand_ask_gold = Random.Range(10,25);
        int rand_ask_food = Random.Range(10,25);
        Villager villager1 = new Villager(rand_ask_gold,rand_ask_food);

    }
}

