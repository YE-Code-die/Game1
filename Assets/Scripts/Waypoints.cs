using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode code;

    public UnitySteeringController controller1;

    public UnitySteeringController controller3;

    public UnitySteeringController controller2;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(this.code) == true)
        {
            this.controller1.Target = transform.position;
            this.controller2.Target= transform.position;
            this.controller3.Target = transform.position;
        }
    }
}
