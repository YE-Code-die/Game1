using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameVisible()
    {
        Vector3 position = transform.position;
        position.x = Random.Range(-20f, 15f);
        position.z = Random.Range(-20f, 9f);
        transform.position = position;
    }
}
