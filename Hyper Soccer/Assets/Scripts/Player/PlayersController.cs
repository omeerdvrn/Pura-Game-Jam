using Managers;
using UnityEngine;

namespace GamePlay
{
    public class PlayersController : MonoBehaviour
    {
        #region Singleton

        private static PlayersController _instance;

        private void Awake()
        {
            _instance = this;
        }

        public static PlayersController GetInstance()
        {
            return _instance;
        }

        #endregion

        [HideInInspector] public bool isGameState;
        public float speed;

        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("ShootStateCollider"))
            {
                GameManager.GetInstance().ChangeState(StateType.ShootState);
            }
        }
    }
}

