using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TreeSharpPlus;
using RootMotion.FinalIK;
public class MoveController : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    public Camera camera;
    public GameObject ball;
    public InteractionObject ikBall;
    public FullBodyBipedEffector hand;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public Node Node_BallStop()
    {
        return new LeafInvoke(() => {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;

            return RunStatus.Success;
        });
    }
    protected Node PickUp(GameObject p)
    {
        return new Sequence(this.Node_BallStop(),
                            p.GetComponent<BehaviorMecanim>().Node_StartInteraction(hand, ikBall),
                            new LeafWait(1000),
                            p.GetComponent<BehaviorMecanim>().Node_StopInteraction(hand));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 hitPosition = hit.point;
                agent.destination = hitPosition;
                GameObject obj = hit.collider.gameObject;
                if (obj.tag == "win")
                {
                    PickUp(ball);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                GameObject obj = hit.collider.gameObject;
                if(obj.tag == "win")
                {
                    PickUp(ball);
                }
            }
        }

    }
}
