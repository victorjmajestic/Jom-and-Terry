using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    [SerializeField] private GameObject cat;
    [SerializeField] private GameObject mouse;
    public Queue<GameObject> cleanQueue = new Queue<GameObject>();
    private List<GameObject> alreadyDone = new List<GameObject>();
    private NavMeshAgent agent;
    public float secondsToClean = 5f;
    public bool lookingForMouse = false;
    public bool cleaning = false;

    private GameObject cleanObject = null;
    private GameObject destinationGO = null;

    public void startCleaning(GameObject other)
    {
        if (other != destinationGO)
        {
            alreadyDone.Add(other);
        }

        cleanObject = other;
        StartCoroutine(clean());
    }

    private void findMouse()
    {
        Vector3 nextLocation = mouse.transform.position;
        agent.SetDestination(nextLocation);
        lookingForMouse = true;
    }

    private IEnumerator clean()
    {
        agent.ResetPath();
        cleaning = true;

        yield return new WaitForSeconds(secondsToClean);

        cleaning = false;

        findNextObject();
    }

    private void findNextObject()
    {
        bool continuing = true;
        while(continuing)
        {
            if(cleanQueue.Count < 1)
            {
                continuing = false;
                findMouse();
            }
            else
            {
                if (cleanObject != destinationGO)
                {
                    agent.SetDestination(destinationGO.transform.position);
                    continuing = false;
                }
                else
                {
                    if (alreadyDone.Contains(cleanQueue.Peek()))
                    {
                        GameObject done = cleanQueue.Dequeue();
                        alreadyDone.Remove(done);
                    }
                    else
                    {
                        continuing = false;
                        destinationGO = cleanQueue.Dequeue();
                        Vector3 nextLocation = destinationGO.transform.position;
                        agent.SetDestination(nextLocation);
                    }
                }
            }
        }
        
    }

    public void addToQueue(GameObject newItem)
    {
        
        cleanQueue.Enqueue(newItem);
        if (lookingForMouse)
        {
            StartCoroutine(endLookForMouse());
        }
    }

    private IEnumerator endLookForMouse()
    {
        lookingForMouse = false;
        agent.ResetPath();

        yield return new WaitForSeconds(1f);
        destinationGO = cleanQueue.Dequeue();
        agent.SetDestination(destinationGO.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        StartCoroutine(clean());
    }

    // Update is called once per frame
    void Update()
    {
    }
}
