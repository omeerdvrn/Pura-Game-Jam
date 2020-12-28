using System.Collections;
using UnityEngine;

namespace Managers
{
    public class FinalStateScript : MonoBehaviour
    {
        [SerializeField] private Animator Player1Anim;
        [SerializeField] private Animator Player2Anim;
        [SerializeField] GamePlay.BallController ballController;

        [SerializeField] private GameObject WinPanel, LosePanel;
        private void OnEnable()
        {
            StartCoroutine(WaitAndCheck());
        }

        IEnumerator WaitAndCheck()
        {
            yield return new WaitForSeconds(3f);
            if (GameManager.GetInstance().isFailed)
            {
                LosePanel.SetActive(true);
            }
            else
            {
                WinPanel.SetActive(true);
                if (ballController.throwDirection == Direction.Right)
                {
                    Player2Anim.SetBool("isVictory", true);
                }
                else
                {
                    Player1Anim.SetBool("isVictory", true);
                }
            }
        }

        private void OnDisable()
        {
            if (GameManager.GetInstance().isFailed)
            {
                LosePanel.SetActive(false);
            }
            else
            {
                WinPanel.SetActive(false);
               
            }
        }
    }
}

