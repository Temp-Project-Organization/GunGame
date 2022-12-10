using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavEnemyAI : MonoBehaviour
{
    [SerializeField]                private List<Transform> wayPoints;             // ���� �������� �����ϱ� ���� List Type ����
    [SerializeField][Range(0, 100)] private float            patrolSpeed = 0.0f;   // ��ȸ �ӵ�
    // [SerializeField][Range(0, 100)] private float            runSpeed    = 0.0f; // �޸��� �ӵ�
    // [SerializeField][Range(0, 100)] private float            damping     = 1.0f; // ������

    private Transform    enemyTransform;
    private Animator     animator;
    private NavMeshAgent aiAgent;

    private int          index;

    private void Awake()
    {
        enemyTransform  = GetComponent<Transform>();    // �� ĳ������ Tansform Component�� ���� ��, ������ ����
        animator        = GetComponent<Animator>();
        aiAgent         = GetComponent<NavMeshAgent>(); // NavMeshAgent Component�� ������ �� ������ ����
        
        aiAgent.autoBraking    = false;                        // �������� ����������� �ӵ��� �����ϴ� �ɼ� ��Ȱ��ȭ
        // aiAgent.updateRotation = false;                     // �ڵ����� ȸ���ϴ� ��� ��Ȱ��ȭ
    }

    private void Start()
    {
        index = 0;
    }

    private void Update()
    {
        aiAgent.speed = patrolSpeed;
        aiAgent.destination = wayPoints[index].position;  // ���� �������� wayPoints Array���� ������ ��ġ�� ���� �������� ����
        animator.SetBool("IsMove", true);

        if (aiAgent.velocity.sqrMagnitude >= 0.04f         // NavMeshAgent�� �̵��ϰ� �ְ�, ������ ���� ���� ���
            && aiAgent.remainingDistance <= 1.0f)
        {
            index++;
        }

        if (index > 1)
        {
            index = 0;
        }
    }
}