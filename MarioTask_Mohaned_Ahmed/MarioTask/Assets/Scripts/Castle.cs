using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{

    public GameObject firework;
    public Vector2 fireworkPosition = new Vector2(125, -8);

    public Animator flag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(firework, fireworkPosition, Quaternion.identity);
            flag.SetBool("AtCastle", true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
