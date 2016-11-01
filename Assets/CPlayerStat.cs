using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CPlayerStat : MonoBehaviour {

	public enum State
    {
        Idle, Attack, Move, Die, SkillA, SkillB, SkillC
    };

    public State _state;


    public int _level;
    public float _exp;
    public float _levelupExp;

    public int _statPoint;

    public int _power;      // 공격력 증가
    public int _defense;    // 방어력 증가
    public int _health;     //  체력 증가


    public void ExpUp(float exp)
    {
        _exp += exp;
        if(_levelupExp <= _exp)
        {
            _exp = 0;
            _level++;
            _levelupExp += (_levelupExp * 0.1f);
            _statPoint += 4;
        }

    }

}


