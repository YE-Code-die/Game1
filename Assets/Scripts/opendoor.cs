using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    // Start is called before the first frame update
    private Door m_Door;
    void Start()
    {
        m_Door = GameObject.Find("door").GetComponent<Door>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Daniel")
        {
   //         m_Door.OpenDoor();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Daniel")
        {
     //       m_Door.CloseDoor();
        }
    }
}
