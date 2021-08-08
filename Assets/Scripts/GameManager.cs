using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject squareBrick;
    public GameObject triangleBrick;
    public GameObject extraBallPower;
    public GameObject levelSpawner;
    public GameObject increaseDamage;
    public int numberOfBricksToStart;
    public int level;
    public List<GameObject> bricksInScene;
    public ObjectPool objectPool;
    public List<GameObject> ballsInScene;
    public int numberOfExtraBallInRaw = 0;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
        level=1;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int brickToCreate = Random.Range(0,6);
             if (brickToCreate == 0)
            {
            bricksInScene.Add(Instantiate (squareBrick, spawnPoints [i].position, Quaternion.identity));
            }else if (brickToCreate == 1)
            {
            bricksInScene.Add(Instantiate (squareBrick, spawnPoints [i].position, Quaternion.identity));
            }else if (brickToCreate == 2 && numberOfExtraBallInRaw == 0)
            {
            bricksInScene.Add(Instantiate (extraBallPower, spawnPoints [i].position, Quaternion.identity));
            numberOfExtraBallInRaw++;
            }
            else if (brickToCreate == 3)
            {
            bricksInScene.Add(Instantiate (levelSpawner, spawnPoints [i].position, Quaternion.identity));
            }
            else if (brickToCreate == 4)
            {
            bricksInScene.Add(Instantiate (increaseDamage, spawnPoints [i].position, Quaternion.identity));
            }
        }
        numberOfExtraBallInRaw=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaceBricks(){
        level++;
        foreach (Transform position in spawnPoints)
        {
            int brickToCreate = Random.Range(0,6);
             if (brickToCreate == 0)
            {
                GameObject brick = objectPool.GetPooledObject("Square");
                bricksInScene.Add(brick);
                if (brick != null)
                {
                    brick.transform.position = position.position;
                    brick.transform.rotation = Quaternion.identity;
                    brick.SetActive(true);
                }
            }else if (brickToCreate == 1)
            {
                GameObject brick = objectPool.GetPooledObject("Triangle");
                bricksInScene.Add(brick);
                if (brick != null)
                {
                    brick.transform.position = position.position;
                    brick.transform.rotation = Quaternion.identity;
                    brick.SetActive(true);
                }
            }
            else if (brickToCreate == 2 && numberOfExtraBallInRaw == 0)
            {
                GameObject ball = objectPool.GetPooledObject("ballPowerUp");
                bricksInScene.Add(ball);
                if (ball != null)
                {
                    ball.transform.position = position.position;
                    ball.transform.rotation = Quaternion.identity;
                    ball.SetActive(true);
                }
            }
            else if (brickToCreate == 3)
            {
                GameObject levelSpawner = objectPool.GetPooledObject("levelSpawner");
                bricksInScene.Add(levelSpawner);
                if (levelSpawner != null)
                {
                    levelSpawner.transform.position = position.position;
                    levelSpawner.transform.rotation = Quaternion.identity;
                    levelSpawner.SetActive(true);
                }
            }
             else if (brickToCreate == 4)
            {
                GameObject increaseDamage = objectPool.GetPooledObject("increaseDamage");
                bricksInScene.Add(increaseDamage);
                if (increaseDamage != null)
                {
                    increaseDamage.transform.position = position.position;
                    increaseDamage.transform.rotation = Quaternion.identity;
                    increaseDamage.SetActive(true);
                }
            }
        }
        numberOfExtraBallInRaw = 0;
    }

}
