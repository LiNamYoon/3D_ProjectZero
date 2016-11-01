using UnityEngine;
using System.Collections;

public class CPlayerAnimation : MonoBehaviour {

    CPlayerStat _state;
    Animator _animator;

    void Awake()
    {
        _state = GetComponent<CPlayerStat>();
        _animator = GetComponent<Animator>();
    }
	
    public void PlayAnimation(CPlayerStat.State state)
    {
        if (_state._state == CPlayerStat.State.Die) return;

        

        _state._state = state;

        switch (state)
        {
            case CPlayerStat.State.Attack:
                _animator.SetBool("Run", false);
                _animator.SetTrigger("Right Punch Attack");                
                break;

            case CPlayerStat.State.Move:              
                _animator.SetBool("Run", true);
                _animator.SetBool("Spin Attack", false);
                _animator.SetBool("Defend", false);
                break;

            case CPlayerStat.State.Die:
                _animator.SetBool("Run", false);
                _animator.SetTrigger("Die");
                break;

            case CPlayerStat.State.SkillA:
                _animator.SetBool("Run", false);
                _animator.SetBool("Spin Attack", true);
                break;

            case CPlayerStat.State.SkillB:
                _animator.SetBool("Run", false);
                _animator.SetTrigger("Cast Spell");                
                break;

            case CPlayerStat.State.SkillC:
                _animator.SetBool("Run", false);
                _animator.SetBool("Defend", true);
                
                break;

            case CPlayerStat.State.Idle:
                _animator.SetBool("Run", false);
                _animator.SetBool("Victory", true);
                break;


        }
    }
}
