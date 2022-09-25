using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyAndDoor : MonoBehaviour
{

    [SerializeField] public GameObject key;
    [SerializeField] public GameObject exit;

    public void grabKey()
    {
        GameObject.Find("Key").SetActive(false);
        GameObject.Find("Door").SetActive(false);
    }

    public void gameSuccess()
    {
        SceneManager.LoadScene("GameCompleted");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == key)
        {
            grabKey();
            Debug.Log("You grabbed the key");
        }
        else if (other.gameObject == exit)
        {
            gameSuccess();
        }
    }

    void Start()
    {
        GameObject.Find("Key").SetActive(false);
    }
}
