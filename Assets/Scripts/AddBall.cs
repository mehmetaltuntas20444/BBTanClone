using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    private ExtraBallManager extraBallManager;
    // Start is called before the first frame update
    void Start()
    {
        extraBallManager = FindObjectOfType<ExtraBallManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Extra Ball")
        {
            extraBallManager.numberOfExtraBalls ++;
            this.gameObject.SetActive(false);
        }
    }
}
