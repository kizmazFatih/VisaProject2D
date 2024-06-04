using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Detector : MonoBehaviour
{
    public bool chasing = false;
    public float way;
    public float rayDistance;
    public float distance;
    private Transform self;
    private Transform player;


    void Start()
    {
        self = this.transform.parent.transform.GetChild(1).transform;
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        distance = transform.position.x - player.transform.position.x;
        RaycastHit2D hit = Physics2D.Raycast(self.position, self.right, rayDistance);

        if (hit.collider != null)
        {

            Debug.DrawLine(self.position, self.position + (self.right * rayDistance), Color.red);
            if (hit.collider.tag == "Player")
            {

                chasing = true;
            }
            else if (Mathf.Abs(distance) > 4)
            {
                chasing = false;
            }
        }





    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            way *= -1;
        }

    }
}
