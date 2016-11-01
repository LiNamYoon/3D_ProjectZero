using UnityEngine;
using System.Collections;

public class CPlayerMovement : MonoBehaviour {

    NavMeshAgent _navMeshAgent;
    CPlayerAnimation _anim;
    
    GameObject Target;
    float _targetDistance;
    CPlayerAttack _attack;
    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<CPlayerAnimation>();
        _attack = GetComponent<CPlayerAttack>();
    }

    

    void Update()
    {
        if(Target == null)
        {
            _targetDistance = 150f;
            Debug.Log("타겟 찾기");
            
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");

            if(Monsters.Length <= 0)
            {
                Debug.Log("게임종료");
                _anim.PlayAnimation(CPlayerStat.State.Idle);
            }

            foreach (GameObject Monster in Monsters)
            {
                float dis = Vector3.Distance(transform.position, Monster.transform.position);

                if (_targetDistance > dis)
                {
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
