using UnityEngine;
using System.Collections;

public class CMonsterAttack : MonoBehaviour {

    CPlayerAnimation _anim;
    public Transform _normalAttackPoint;
    public float _damage;
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
        
        Collider[] col = Physics.OverlapSphere(_normalAttackPoint.position, 2f, 1 << LayerMask.NameToLayer(targetType));
        foreach (Collider target in col)
        {
            
            //target.SendMessage("Hit", _damage);
        }
    }

}
