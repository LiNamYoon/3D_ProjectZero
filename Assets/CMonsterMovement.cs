using UnityEngine;
using System.Collections;

public class CMonsterMovement : MonoBehaviour {

    NavMeshAgent _navMeshAgent;
    CPlayerAnimation _anim;
    CMonsterAttack _attack;
    GameObject Target;



    float _targetDistance;
    string targetType;
    
    void Awake()
    {
        _attack = GetComponent<CMonsterAttack>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<CPlayerAnimation>();
    }

    void Start ()
    {
        if(gameObject.tag.Equals("Player"))
        {
            targetType = "Monster";
            _targetDistance = 100f;
        }
        else if(gameObject.tag.Equals("Monster"))
        {
            targetType = "Player";
            _targetDistance = 7f;
        }     

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Target == null)
        {
            //_targetDistance = 100f;
            Debug.Log("플레이어 타겟 찾기");

            GameObject[] Monsters = GameObject.FindGameObjectsWithTag(targetType);

            if (Monsters.Length <= 0)
            {
                Debug.Log("게임종료");
                _anim.PlayAnimation(CPlayerStat.State.Idle);
            }

            foreach (GameObject Monster in Monsters)
            {
                float dis = Vector3.Distance(transform.position, Monster.transform.position);

                if (_targetDistance > dis)
                {
                    Debug.Log("플레이어 찾음");
                    _targetDistance = dis;
                    Target = Monster;
                }
            }
        }



        if (Target != null)
        {
            Vector3 targetPos = Target.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(targetPos);
            float dis = Vector3.Distance(transform.position, Target.transform.position);
            if (dis < 1)
            {
                
                _attack.NormalAttack(Target);
                _navMeshAgent.Stop();
                return;
            }
            else
            {
                _anim.PlayAnimation(CPlayerStat.State.Move);
            }

            _navMeshAgent.SetDestination(Target.transform.position);
            _navMeshAgent.Resume();


            if (CGameManager.getInstance.PlayerState(gameObject, "Attack")) return;


            _anim.PlayAnimation(CPlayerStat.State.Move);


        }

    }
}

