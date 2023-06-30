using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace Panda.Examples.Shooter
{
    public class Patroller : MonoBehaviour
    {
        public WaypointPath waypointPath;
        [SerializeField]
        private NavMeshAgent agent;

        [SerializeField]
        Transform playerTransform;

        Unit self;
        int waypointIndex;
        Vector3 destination = Vector3.zero;

        // Use this for initialization
        void Start()
        {
            waypointIndex = 0;
            self = GetComponent<Unit>();
        }

        // Update is called once per frame
        void Update()
        {

        }


        [Task]
        bool NextWaypoint()
        {
            if (waypointPath != null)
            {
                waypointIndex++;
                if( Task.isInspected )
                    ThisTask.debugInfo = string.Format("i={0}", waypointArrayIndex);
            }
            return true;
        }

        [Task]
        bool SetDestination_Waypoint()
        {
            bool isSet = false;
            if (waypointPath != null)
            {
                var i = waypointArrayIndex;
                var p = waypointPath.waypoints[i].position;
                isSet = self.SetDestination(p);
            }
            return isSet;
        }

        [Task]
        public bool SetDestination_Waypoint(int i)
        {
            bool isSet = false;
            if (waypointPath != null)
            {
                var p = waypointPath.waypoints[i].position;
                isSet = self.SetDestination(p);
            }
            return isSet;
        }

        [Task]
        public void MoveTo(int i)
        {
            SetDestination_Waypoint(i);
            self.MoveTo_Destination();
            self.WaitArrival();
        }

        [Task]
        public void LookAt(int i)
        {
            self.SetTarget( waypointPath.waypoints[i].transform.position);
            self.AimAt_Target();
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
        bool SetDestination_Random()
        {
            destination = Random.insideUnitSphere * 5;
            destination.y = 0.0f;

            return true;
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

        int waypointArrayIndex
        {
            get
            {
                int i = 0;
                if( waypointPath.loop)
                {
                    i = waypointIndex % waypointPath.waypoints.Length;
                }
                else
                {
                    int n = waypointPath.waypoints.Length;
                    i = waypointIndex % (n*2);

                    if( i > n-1 )
                        i = (n-1) - (i % n); 
                }

                return i;
            }
        }
    }
}
