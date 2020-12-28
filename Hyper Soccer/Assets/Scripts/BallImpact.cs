using System.Collections;
using GamePlay;
using Managers;
using UnityEngine;

public class BallImpact : MonoBehaviour
{
    Animator player1Anim;
    Animator player2Anim;
    [SerializeField] private BallController ballController;
    void Start()
    {
        player1Anim = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Animator>();
        player2Anim = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GamePlay.PlayersController.GetInstance().speed = 0;
            if (ballController.throwDirection == Direction.Left)
            {
                player1Anim.SetTrigger("isFall");
                player2Anim.SetBool("isRunning", false);
            }
            else if (ballController.throwDirection == Direction.Right)
            {
                player1Anim.SetBool("isRunning", false);
                player2Anim.SetTrigger("isFall");
            }
            
            GameManager.GetInstance().isFailed = true;
            GameManager.GetInstance().ChangeState(StateType.FinalState);
        }
    }
}
