using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{
    public bool locked = false;
    public GameObject currentUI;
    [SerializeField] private Human human;

    [SerializeField] Animator cat_animator;
    [SerializeField] private GameObject floorSpot;
    private bool canPee = true;
    public float cooldownTime = 10f;
    private int messCount = 5;

    /*PVS = pee, vomit scratch*/

    [SerializeField] private Sprite pee;
    [SerializeField] private Sprite vomit;
    [SerializeField] private Sprite scratch;

    [SerializeField] private Sprite PVScheckmark;  //checked boxes

    [SerializeField] private Image[] PVScheckboxes = new Image[5]; //unchecked boxes

    [SerializeField] public int movementspeed;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!locked)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
                cat_animator.SetBool("Left", true);
                cat_animator.SetBool("Right", false);
                cat_animator.SetBool("Front", false);
                cat_animator.SetBool("Back", false);
                cat_animator.SetBool("Pee", false);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                cat_animator.SetBool("Right", true);
                cat_animator.SetBool("Left", false);
                cat_animator.SetBool("Front", false);
                cat_animator.SetBool("Back", false);
                cat_animator.SetBool("Pee", false);
                transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
                
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * movementspeed * Time.deltaTime);
                cat_animator.SetBool("Right", false);
                cat_animator.SetBool("Left", false);
                cat_animator.SetBool("Front", false);
                cat_animator.SetBool("Back", true);
                cat_animator.SetBool("Pee", false);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * movementspeed * Time.deltaTime);
                cat_animator.SetBool("Right", false);
                cat_animator.SetBool("Left", false);
                cat_animator.SetBool("Front", true);
                cat_animator.SetBool("Back", false);
                cat_animator.SetBool("Pee", false);
            }
            else if (Input.GetKey(KeyCode.C))
            {
                cat_animator.SetBool("Right", false);
                cat_animator.SetBool("Left", false);
                cat_animator.SetBool("Front", false);
                cat_animator.SetBool("Back", false);

                if (canPee && messCount > 0)
                {
                    makeMess();
                    
                }
            }
            else {
                cat_animator.SetBool("Right", false);
                cat_animator.SetBool("Left", false);
                cat_animator.SetBool("Front", false);
                cat_animator.SetBool("Back", false);
                cat_animator.SetBool("Pee", false);
                cat_animator.SetBool("Vomit", false);
                cat_animator.SetBool("Scratch", false);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                locked = false;
                currentUI.GetComponent<Task>().endMinigame();
                currentUI.SetActive(false);
                
            }
        }

    }

    private void makeMess()
    {
        GameObject spot = Instantiate(floorSpot, transform.position, transform.rotation);
        PVScheckboxes[messCount - 1].sprite = PVScheckmark;
        int which = Random.Range(0, 3);

        switch (which)
        {
            case 0:
                cat_animator.SetBool("Pee", true);
                spot.GetComponent<SpriteRenderer>().sprite = pee;
                break;
            case 1:
                cat_animator.SetBool("Vomit", true);
                spot.GetComponent<SpriteRenderer>().sprite = vomit;
                break;
            case 2:
                cat_animator.SetBool("Scratch", true);
                spot.GetComponent<SpriteRenderer>().sprite = scratch;
                break;
        }
        Data.score = Data.score + 15;
        spot.GetComponent<Floorspot>().setHuman(human);
        canPee = false;
        messCount--;

        StartCoroutine(peeCooldown());
    }

    private IEnumerator peeCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canPee = true;
    }
}