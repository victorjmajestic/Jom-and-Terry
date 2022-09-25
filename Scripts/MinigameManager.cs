using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private GameObject Bedroom;
    [SerializeField] private GameObject Bathroom;
    [SerializeField] private GameObject TV;
    [SerializeField] private GameObject Kitchen;
    [SerializeField] private GameObject Office;
    [SerializeField] private GameObject dining;
    
    void Start()
    {
        
    }

    public void reset(Interactable which)
    {
        GameObject newUI = null;
        Destroy(which.minigameUI);

        switch (which.id)
        {
            case 0://kitchen
                
                newUI = Instantiate(Kitchen, transform);
                break;

            case 1://tv
                newUI = Instantiate(TV, transform);
                break;

            case 2://bathroom
                newUI = Instantiate(Bathroom, transform);
                break;

            case 3://bedroom
                newUI = Instantiate(Bedroom, transform);
                break;

            case 4:
                newUI = Instantiate(Office, transform);
                break;

            case 5:
                newUI = Instantiate(dining, transform);
                break;
        }

        which.minigameUI = newUI;
        newUI.GetComponent<Task>().setInteractable(which);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
