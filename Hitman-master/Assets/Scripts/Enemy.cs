using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    [SerializeField] private GameObject[] m_PatrolPoint;
    [SerializeField] private int m_currPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Agent.remainingDistance <= m_Agent.stoppingDistance)
        {
            if (m_currPoint + 1 <= m_PatrolPoint.Length)
            {
                m_currPoint++;
                m_Agent.SetDestination(m_PatrolPoint[m_currPoint].transform.position);
            }
            else 
            {
                m_currPoint = 0;
                m_Agent.SetDestination(m_PatrolPoint[m_currPoint].transform.position);
            }
        }
    }

    
}
