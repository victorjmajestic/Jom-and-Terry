using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavDirectional : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;

    const int idle = 0;
    const int up = 1;
    const int right = 2;
    const int down = 3;
    const int left = 4;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 desiredVel = agent.desiredVelocity;
        
        float dx = Mathf.Abs(desiredVel.x);
        float dy = Mathf.Abs(desiredVel.y);

        if(dx == 0f && dy == 0f)
        {
            anim.SetInteger("Direction", idle);
        }

        if(dx > dy)
        {
            //left or right
            if(desiredVel.x > 0)
            {
                anim.SetInteger("Direction", right);
            }
            else
            {
                anim.SetInteger("Direction", left);
            }
        }
        else
        {
            //up or down
            if(desiredVel.y > 0)
            {
                anim.SetInteger("Direction", up);
            }
            else
            {
                anim.SetInteger("Direction", down);
            }
        }
    }
}
