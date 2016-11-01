using UnityEngine;
using System.Collections;

public class CPlayerAttack : MonoBehaviour {

    CPlayerAnimation _anim;
    public Transform _normalAttackPoint;
    
    public float _delayTimeSkillA;
    public float _delayTimeSkillB;
    public float _delayTimeSkillC;

    string targetType;

    void Awake()
    {
        _anim = GetComponent<CPlayerAnimation>();
    }

    void Start()
    {
        if (gameObject.tag.Equals("Player"))
        {
            targetType = "Monster";
            
        }
        else if (gameObject.tag.Equals("Monster"))
        {
            targetType = "Player";
            
        }

    }


    public void NormalAttack(GameObject target)
    {        
        _anim.PlayAnimation(CPlayerStat.State.Attack);
        
    }
    public void NormalAttackEvent()
    {
        Debug.Log("공격시작");
        Collider[] col = Physics.OverlapSphere(_normalAttackPoint.position, 2f, 1<<LayerMask.NameToLayer(targetType));
        foreach (Collider target in col)
        {
            Debug.Log(target.name + "공격");
            target.SendMessage("Hit", 30f);
            target.SendMessage("HitPlayer", gameObject);
        }
    }


	public void OnSkillA()
    {
        _anim.PlayAnimation(CPlayerStat.State.SkillA);
        StartCoroutine("OnSkillACoroutine");
    }
    IEnumerator OnSkillACoroutine()
    {
        yield return new WaitForSeconds(_delayTimeSkillA);
        _anim.PlayAnimation(CPlayerStat.State.Move);
    }

    public void OnSkillB()
    {
        _anim.PlayAnimation(CPlayerStat.State.SkillB);
        StartCoroutine("OnSkillBCoroutine");
    }
    IEnumerator OnSkillBCoroutine()
    {
        yield return new WaitForSeconds(_delayTimeSkillB);
        _anim.PlayAnimation(CPlayerStat.State.Move);
    }

    public void OnSkillC()
    {
        _anim.PlayAnimation(CPlayerStat.State.SkillC);
        StartCoroutine("OnSkillCCoroutine");
    }
    IEnumerator OnSkillCCoroutine()
    {
        yield return new WaitForSeconds(_delayTimeSkillC);
        _anim.PlayAnimation(CPlayerStat.State.Move);
    }
}
