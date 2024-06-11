using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    public bool hasTarget;
    [SerializeField] private bool isRotating;
    [SerializeField] private float rotationSpeed;

    void Start()
    {
        target = FindObjectOfType<CharacterMovement>().transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        FollowPlayer();

        if (isRotating)
        {
            transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
        }
    }

    private void FollowPlayer()
    {
        if (hasTarget)
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            GameController.Instance.LooseGame();
        }
    }
}
