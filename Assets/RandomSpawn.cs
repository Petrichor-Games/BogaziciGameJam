using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
   
        public GameObject bugdayPrefab;
        public GameObject coinSpawn;
        private int durum;
    
        void Start()
        {

           
                    SpawnCoins(coinSpawn);

                
        }
    

        void SpawnCoins(GameObject asd)
        {
            int coinsToSpawn = 3;
            for (int i = 0; i < coinsToSpawn; i++)
            {
                GameObject temp = Instantiate(bugdayPrefab, asd.transform);
                temp.transform.position = GetRandomPointInCollider(asd.GetComponent<Collider>());
            }
        }


        Vector3 GetRandomPointInCollider(Collider collider)
        {
            Vector3 point = new Vector3(
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

            if (point != collider.ClosestPoint(point))
            {
                point = GetRandomPointInCollider(collider);
            }

            point.y = 1;
            return point;
        }
    }


