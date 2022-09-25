using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //This is the script to be applied to interactables in the world. An object that can be used to start a minigame, or be cleaned up by the human
    //Remember to change the sprite in the renderer, and the collision box so that it makes sense with the object
    [SerializeField] GameObject cat;
    [SerializeField] GameObject human;
    [SerializeField] GameObject mouse;
    [SerializeField] MinigameManager manager;

    private InteractableState state = InteractableState.Ready;
    private bool highlighted = false;
    private SpriteRenderer spriteRenderer;
    public GameObject minigameUI;
    private int tasksCompleted = 0;
    public int tasksTotal = 2;
    private float secondsToClean = 0f;
    private float baseSecondsToClean = 5f;
    private float waitTime = 15f;

    public Color highlightColor;
    public Color readyColor;
    public int id;

    //This helps keep track of what can be done with this interactable
    private enum InteractableState
    {
        Ready,
        NeedsFixed,
        Cleaned
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;

        //This should make an object clickable and highlight it
        if(otherGO == cat && (state == InteractableState.Ready || state == InteractableState.NeedsFixed))
        {
            highlight();
        }

        //This lets the human know they are over an object that needs fixed, so they can stop moving
        if(otherGO == human && state == InteractableState.NeedsFixed)
        {
            letHumanClean();
            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject == human && state == InteractableState.NeedsFixed)
        {
            bool cleaningStatus = human.GetComponent<Human>().cleaning;
            if (!cleaningStatus)
            {
                letHumanClean();
            }
        }
    }

    private void letHumanClean()
    {
        human.GetComponent<Human>().secondsToClean = secondsToClean;
        human.GetComponent<Human>().startCleaning(this.gameObject);
        secondsToClean = 0f;
        if (tasksCompleted == tasksTotal)
        {
            state = InteractableState.Cleaned;
            StartCoroutine(resetSoon());
        }
        else
        {
            state = InteractableState.Ready;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (highlighted && other.gameObject == cat)
        {
            removeHighlight();
        }
    }

    private void highlight()
    {
        highlighted = true;
        spriteRenderer.color = highlightColor;
    }

    private void removeHighlight()
    {
        highlighted = false;
        if (tasksCompleted < tasksTotal)
            spriteRenderer.color = readyColor;
        else
            spriteRenderer.color = Color.white;
    }

    void OnMouseDown()
    {
        if (highlighted)
        {
            startMinigame();
        }
    }

    private void startMinigame()
    {
        minigameUI.SetActive(true);
        CatController catController = cat.GetComponent<CatController>();
        catController.locked = true;
        catController.currentUI = minigameUI;
    }

    public void minigameEnded(int completeness)
    {
        if(completeness > 0)
        {
            state = InteractableState.NeedsFixed;
            secondsToClean = baseSecondsToClean * (completeness - tasksCompleted);
            
            tasksCompleted += completeness;
            if(tasksCompleted >= tasksTotal)
            {
                human.GetComponent<Human>().addToQueue(this.gameObject);
                mouse.GetComponent<Mouse>().taskDone();
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = readyColor;
        minigameUI.GetComponent<Task>().setInteractable(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator resetSoon()
    {
        yield return new WaitForSeconds(waitTime);

        state = InteractableState.Ready;
        tasksCompleted = 0;
        manager.reset(this);
        spriteRenderer.color = readyColor;
    }
}

