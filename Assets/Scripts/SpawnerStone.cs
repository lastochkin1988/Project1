using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Golf
{
    public class SpawnerStone : MonoBehaviour
    {
        public GameObject[] prefabs;

        public GameObject Spawn()
        {
            var prifab = GetRandomPrefab();

            if (prifab == null )
            {
                return null;
            }
            return Instantiate(prifab, transform.position, Quaternion.identity);
        }
        private GameObject GetRandomPrefab()
        {
            if (prefabs.Length == 0)
            {
                return null;
            }
            
            int index = Random .Range(0, prefabs.Length);
            return prefabs[index];
        }
    }
}
