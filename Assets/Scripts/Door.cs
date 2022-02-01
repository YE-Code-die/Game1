using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform door;
    void Start()
    {
        door = GameObject.Find("Door").GetComponent<Transform>();

    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Daniel")
        {
            door.Rotate(Vector3.forward ,90);
        }
        
    }
     public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Daniel")
        {
            door.Rotate(Vector3.forward, -90);
        }
    }
}
