using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    private BallController player;
    public GameObject endGamePanel;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BallController>();
        endGamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Square" || other.gameObject.tag == "Triangle")
        {
            player.gameState = BallController.GameState.endGame;
            endGamePanel.SetActive(true);
        }
    }

    public void Retry(){
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit(){
        Application.Quit();
    }
}
