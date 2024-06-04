using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class RickWalkAnimationScript : StateMachineBehaviour
{
    Detector detector;
    Enemy enemy;

    public float speed;
    public float runSpeed;

    public float attackRange;


    private Transform player;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        detector = animator.transform.GetChild(0).GetComponent<Detector>();
        enemy = animator.GetComponent<Enemy>();
        player = GameObject.FindWithTag("Player").transform;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!detector.chasing)
        {
            if (detector.way == -1)
            {
                animator.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                animator.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            Vector2 direction = new Vector2(speed, 0);
            animator.transform.Translate(direction * Time.deltaTime);
        }
        else
        {
            enemy.LookAtPlayer();
            if (Mathf.Abs(detector.distance) > attackRange)
            {

                Vector2 target = new Vector2(player.position.x, animator.transform.position.y);
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, runSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("Attack", true);
            }
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
