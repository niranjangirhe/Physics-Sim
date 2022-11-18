using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int count;
    [SerializeField] private float max_dis;
    [SerializeField] private bool do2D;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<count;i++)
        {
            GameObject.Instantiate(prefab, transform.position+new Vector3(Random.Range(-max_dis,max_dis), Random.Range(-max_dis, max_dis)*(do2D?0:1), Random.Range(-max_dis, max_dis)), Quaternion.identity,transform.parent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
