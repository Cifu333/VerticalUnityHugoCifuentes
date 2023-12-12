using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class spawnerGrass : MonoBehaviour
{


    public GameObject prefab;
    public float gridX = 5f;
    public float gridY = 5f;
    public float spacing = 2f;

    private bool done;
        
    void Update()
    {
            
       
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag=="Player" && !done  )
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                Vector3 pos = new Vector3(x, 0, y) * spacing;
                Instantiate(prefab, pos, Quaternion.identity);
            }

        }done = true;
    }
    /*[SerializeField]
    GameObject spawner;

    public GameObject GetSpawn()
    {
        return spawner;
    }
    */

}
