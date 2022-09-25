using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Mouse : MonoBehaviour
{
    [SerializeField] private GameObject humanGO;
    public GameObject[] taskList = new GameObject[2];
    private int taskIndex = 0;
    private Human human;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        human = humanGO.GetComponent<Human>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        toNextTask();
    }

    public void taskDone()
    {
        taskIndex++;

        if (taskIndex >= taskList.Length)
        {
            taskIndex = 0;
        }

        toNextTask();

    }

    private void toNextTask()
    {
        Debug.Log("On to task " + taskIndex);
        agent.ResetPath();
        Vector3 nextLocation = taskList[taskIndex].transform.position;
        agent.SetDestination(nextLocation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == humanGO && human.lookingForMouse)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("GameOver");
        }
    }
}
