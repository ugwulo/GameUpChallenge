using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y > player.transform.position.y)
        {
            FindObjectOfType<AudioManager>().Play("whoosh");
            GameManager.numPassedRings++;
            Destroy(gameObject);
        }
    }
}
