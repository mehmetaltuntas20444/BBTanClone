using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public enum GameState
    {
        aim,
        fire,
        wait,
        endShot,
        endGame
    }

    public GameState gameState;
    public Rigidbody2D ball;
    private Vector2 mouseStarPosition;
    private Vector2 mouseEndPosition;
    public bool clicked;
    public bool dragged;
    public bool canInteract;
    private float playerVelocityX;
    private float playerVelocityY;
    public float speed;
    public GameObject arrow;
    private GameManager gameManager;
    public Vector3 ballLaunchPosition;
    public Vector2 tempVelocity;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        canInteract = true;
        gameState = GameState.aim;
        gameManager.ballsInScene.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.aim:
                if (Input.GetMouseButtonDown(0) && canInteract)
                {
                    MouseClicked();
                }
                if (Input.GetMouseButtonDown(0) && canInteract)
                {
            MouseDragged();
                }
                if (Input.GetMouseButtonUp(0) && canInteract)
                {
                MouseRelease();
                }
                break;
            
            case GameState.fire:
                break;
            case GameState.wait:
                if (gameManager.ballsInScene.Count ==1)
                {
                gameState = GameState.endShot;
                }
                break;
            case GameState.endShot:
                for (int i = 0; i < gameManager.bricksInScene.Count; i++)
                {
                    gameManager.bricksInScene [i].GetComponent<BrickMovementController>().currentState = BrickMovementController.brickState.move;
                }
                gameManager.PlaceBricks();
                gameState = GameState.aim;
                break;
            case GameState.endGame:
                break;
            default:
                break;
        }
        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            MouseClicked();
        }
         if (Input.GetMouseButtonDown(0) && canInteract)
        {
            MouseDragged();
        }
          if (Input.GetMouseButtonUp(0) && canInteract)
        {
           MouseRelease();
        }
    }

    public void MouseClicked(){
        mouseStarPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void MouseDragged(){
        arrow.SetActive(true);
        Vector2 tempMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float diffX = mouseStarPosition.x - tempMousePosition.x;
        float diffY = mouseStarPosition.y - tempMousePosition.y;
        if (diffY <=0)
        {
            diffY = .01f;
        }
        float theta = Mathf.Rad2Deg *  Mathf.Atan(diffX/diffY);
        arrow.transform.rotation = Quaternion.Euler(0f,0f,-theta);

    }

    public void MouseRelease(){
        arrow.SetActive(false);
        mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerVelocityX = (mouseStarPosition.x - mouseEndPosition.x);
        playerVelocityY = (mouseStarPosition.y - mouseEndPosition.y);
        Vector2 tempVelocity = new Vector2 (playerVelocityX, playerVelocityY).normalized;
        ball.velocity = speed * tempVelocity;
        if (ball.velocity == Vector2.zero)
        {
            return;
        }
        ballLaunchPosition = transform.position;
        gameState = GameState.fire;
        }
}
