using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace HSJ
{
    public class NPCController : MonoBehaviour
    {
        private enum NPCState
        {
            Idle,
            Move,
            Sit,
            Select,
            Wait,
            Eat,
            Evaluation,
            Return
        }

        private NPCState state;

        private TMP_Text stateText;

        private CharacterController cc;

        private NavMeshAgent agent;

        private Animator anim;

        public GameObject player;
        public GameObject chair;

        private const float randomValue = 5.0f;
        private const float minDistance = 0.001f;
        private const float moveSpeed = 4.0f;

        private void Start()
        {
            cc = GetComponent<CharacterController>();
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            player = FindObjectOfType<PlayerController>().gameObject;
            stateText = GetComponentInChildren<TMP_Text>();
            state = NPCState.Idle;
        }

        private void Update()
        {
            stateText.text = state.ToString();
            stateText.transform.forward = player.transform.forward;

            UpdateFSM();
        }

        private void UpdateFSM()
        {
            switch (state)
            {
                case NPCState.Idle:
                    Idle();
                    break;
                case NPCState.Move:
                    Move();
                    break;
                case NPCState.Sit:
                    Sit();
                    break;
                case NPCState.Select:
                    StartCoroutine(Select());
                    break;
                case NPCState.Wait:
                    Wait();
                    break;
                case NPCState.Eat:
                    StartCoroutine(Eat());
                    break;
                case NPCState.Evaluation:
                    StartCoroutine(Evaluation());
                    break;
                case NPCState.Return:
                    StartCoroutine(Return());
                    break;
            }
        }

        private void Idle()
        {
            if (player.GetComponent<PlayerController>().State == PlayerController.PlayerState.Open)
            {
                state = NPCState.Move;
            }
        }

        private void Move()
        {
            if (Vector3.Distance(transform.position, chair.transform.position) > minDistance)
            {
                Vector3 direction = (chair.transform.position - transform.position).normalized;

                transform.forward = direction;

                cc.Move(direction * moveSpeed * Time.deltaTime);
            }
        }

        private void Sit()
        {
            if (player.GetComponent<PlayerController>().State == PlayerController.PlayerState.Order)
            {
                state = NPCState.Select;
            }
        }

        private IEnumerator Select()
        {
            yield return new WaitForSeconds(2.0f);

            state = NPCState.Wait;
        }

        private void Wait()
        {
            if (player.GetComponent<PlayerController>().State == PlayerController.PlayerState.Complete)
            {
                state = NPCState.Eat;
            }
        }

        private IEnumerator Eat()
        {
            yield return new WaitForSeconds(2.0f);

            state = NPCState.Evaluation;
        }

        private IEnumerator Evaluation()
        {
            yield return new WaitForSeconds(2.0f);

            state = NPCState.Return;
        }

        private IEnumerator Return()
        {
            yield return new WaitForSeconds(2.0f);

            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Chair"))
            {
                state = NPCState.Sit;
            }
        }
    }
}
