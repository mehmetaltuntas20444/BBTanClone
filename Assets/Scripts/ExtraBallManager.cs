using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraBallManager : MonoBehaviour
{
    private BallController ballController;
    private GameManager gameManager;
    public float ballWaitTime;
    private float ballWaitTimeSeconds;
    public int numberOfExtraBalls;
    public int numberOfBallsToFire;
    public ObjectPool objectPool;
    public Text numberOfBallsText;
    // Start is called before the first frame update
    void Start()
    {
        ballController= FindObjectOfType<BallController>();
        gameManager = FindObjectOfType<GameManager>();
        ballWaitTimeSeconds = ballWaitTime;
        numberOfExtraBalls = 0;
        numberOfBallsToFire = 0;
        numberOfBallsText.text = "" + 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfBallsText.text = "" + (numberOfExtraBalls +1);
        if (ballController.gameState == BallController.GameState.fire || ballController.gameState == BallController.GameState.wait)
        {
            if (numberOfBallsToFire >0)
            {   ballWaitTimeSeconds-=Time.deltaTime;
                if (ballWaitTimeSeconds <= 0)
                {
                    GameObject ball = objectPool.GetPooledObject("Extra Ball");
                    if(ball != null){
                        ball.transform.position = ballController.ballLaunchPosition;
                        ball.SetActive(true);
                        gameManager.ballsInScene.Add(ball);
                        ball.GetComponent<Rigidbody2D>().velocity= 12 * ballController.tempVelocity;
                        ballWaitTimeSeconds = ballWaitTime;
                        numberOfBallsToFire--;
                    }
                    ballWaitTimeSeconds = ballWaitTime;
                }
            }
        }
        if (ballController.gameState == BallController.GameState.endShot)
        {
            numberOfBallsToFire = numberOfExtraBalls;
        }
    }
}
