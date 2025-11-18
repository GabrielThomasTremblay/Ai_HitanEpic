using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    private Rigidbody m_Rigidbody;
    [SerializeField] private GameObject[] m_PatrolPoint;
    [SerializeField] private int m_currPoint;
    [SerializeField] public int state;
    private int health = 3;
    private MeshRenderer m_Renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Renderer = GetComponent<MeshRenderer>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 5: //Dead
                m_Renderer.material.color = Color.black;
                break;
            case 1: //Alerter
                break;
            case 2: //Avertir
                break;
            case 3: //Ataquer
                break;
            case 4: //Fuir
                break;
            case 0: //Mort
                if (m_Agent.remainingDistance <= m_Agent.stoppingDistance)
                {
                    if (m_currPoint + 2 <= m_PatrolPoint.Length)
                    {
                        m_currPoint++;
                        m_Agent.SetDestination(m_PatrolPoint[m_currPoint].transform.position);
                    }
                    else if(m_PatrolPoint.Length > 0)
                    {
                        m_currPoint = 0;
                        m_Agent.SetDestination(m_PatrolPoint[m_currPoint].transform.position);
                    }
                }
                break;
        }

    }

    public void Damage(GameObject direction)
    {
        health--;
        if (health <= 0)
        {
            m_Agent.enabled = false;
            m_Rigidbody.isKinematic = false;
            m_Rigidbody.AddForce(direction.transform.forward * 3, ForceMode.Impulse);
            state = 5;
        }
    }

    
}
