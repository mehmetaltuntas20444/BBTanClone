using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStop : MonoBehaviour
{

    public Rigidbody2D ball;
    public BallController ballControl;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D( Collision2D other) {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Extra Ball")
        {
            ball.velocity = Vector2.zero;
            ballControl.canInteract = true;
            ballControl.gameState = BallController.GameState.wait;
        }
        if (other.gameObject.tag == "Extra Ball")
        {
            gameManager.ballsInScene.Remove(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
