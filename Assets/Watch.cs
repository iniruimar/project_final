using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace Panda.Examples.Shooter
{
    public class Watch : MonoBehaviour
    {
        
        [SerializeField]
        private NavMeshAgent agent;

        [SerializeField]
        private NavMeshAgent other_agent;

        [SerializeField]
        Transform playerTransform;

        [SerializeField]
        Vector3 start_dest;
        Unit self;
        Vector3 destination = Vector3.zero;
        
        // Use this for initialization
        void Start()
        {
            
            self = GetComponent<Unit>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        [Task]
        public bool CanSee(){
            
            RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, playerTransform.position - transform.position, out hit)){
                if(hit.collider.gameObject.CompareTag("Player")){
                    return true;
                }

            }

            return false;
        }

        [Task]
        bool SetDestination_Player()
        {
            destination = playerTransform.position;
            return true;
        }

        [Task]
        bool MoveToDestination()
        {
            agent.SetDestination(destination);
            return true;
        }

        [Task]
        bool MoveOtherAgent()
        {
            other_agent.SetDestination(destination);
            return true;
        }

        [Task]
        public bool GoBack(){
            destination = start_dest;
            return true;
        }
        
    }
}
