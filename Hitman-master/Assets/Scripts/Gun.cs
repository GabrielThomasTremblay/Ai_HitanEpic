using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject m_bullet;
    [SerializeField] private InputActionAsset m_ActionAsset;
    private InputAction m_shoot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_shoot = m_ActionAsset.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_shoot.WasPressedThisFrame())
        {
            Instantiate(m_bullet, transform.position, transform.rotation);
        }
    }

}
