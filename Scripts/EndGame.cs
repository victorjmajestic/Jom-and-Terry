using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    [SerializeField] public Text highScore;

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Data.score = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (Data.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Data.score);
        }
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
