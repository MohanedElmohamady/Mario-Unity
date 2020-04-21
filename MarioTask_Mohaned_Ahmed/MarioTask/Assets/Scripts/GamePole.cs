using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePole : MonoBehaviour
{
    public Animator gamePole;
    public Animator mario;

    ScoreManager sm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            gamePole.SetBool("OnPole", true);
            mario.SetBool("OnPole", true);
            sm.FreezeConvertTimeToscore();
            sm.Win = true;
        }

    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            gamePole.SetBool("OnPole", true);
            mario.SetBool("OnPole", true);
            //collision.gameObject.GetComponent<PlayerController>().takeAwayControll = true;
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
