using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        GamePlay.BallController ballController;
        [HideInInspector] public bool isTap;

        private void Start()
        {
            isTap = true;
            ballController = GameObject.FindGameObjectWithTag("Ball").GetComponent<GamePlay.BallController>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !ballController.isThrow && isTap)
            {
                if (ballController.throwDirection == Direction.Left)
                    ballController.throwDirection = Direction.Right;
                else
                    ballController.throwDirection = Direction.Left;
                isTap = false;
                ballController.isThrow = true;
            }
        }
    }

}
