using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;

    Animator animator;
    Rigidbody physic;
    CapsuleCollider capsuleCollider;
    GamePlay.BallController ballController;
    Managers.InputManager inputManager;

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        ballController = GameObject.FindGameObjectWithTag("Ball").GetComponent<GamePlay.BallController>();
        inputManager = inputManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Managers.InputManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && inputManager.isTap)
        {
            if (gameObject.name == "Player 1" && ballController.throwDirection == Direction.Right)
            {
                //inputManager.isTap = false;
                physic.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                capsuleCollider.isTrigger = true;
                animator.SetTrigger("isJump");
            }

            else if (gameObject.name == "Player 2" && ballController.throwDirection == Direction.Left)
            {
                //inputManager.isTap = false;
                physic.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                capsuleCollider.isTrigger = true;
                animator.SetTrigger("isJump");
            }
        }

        if (other.CompareTag("Floor") && !inputManager.isTap)
        {
            capsuleCollider.isTrigger = false;
            inputManager.isTap = true;
        }
    }
}
