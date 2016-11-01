using UnityEngine;
using System.Collections;

public class CGameManager : MonoBehaviour {

    

    private static CGameManager instance;

    public static CGameManager getInstance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public CFollowCamera _followCamera;
    public CTextManager _textManager;

    void Start()
    {
        Player = Players[0];
        _followCamera._target = Players[0];
        _textManager._player = Players[0];
    }


    public GameObject[] Players;
    GameObject Player;
    CPlayerStat _state;

    public void Player1ButtonClick()
    {
        Player = Players[0];
        _followCamera._target = Players[0];
        _textManager._player = Players[0];
    }
    public void Player2ButtonClick()
    {
        Player = Players[1];
        _followCamera._target = Players[1];
        _textManager._player = Players[1];
    }




    public void ButtonClickSkillA()
    {
        Player.SendMessage("OnSkillA");
    }

    public void ButtonClickSkillB()
    {
        Player.SendMessage("OnSkillB");
    }

    public void ButtonClickSkillC()
    {
        Player.SendMessage("OnSkillC");
    }

    

    public bool PlayerState(GameObject player, string IsState)
    {
        _state = player.GetComponent<CPlayerStat>();
        
        if (_state._state == CPlayerStat.State.Attack ||
            _state._state == CPlayerStat.State.SkillA ||
            _state._state == CPlayerStat.State.SkillB ||
            _state._state == CPlayerStat.State.SkillC)
        {
            if(IsState == "Attack")
            {
                return true;
            }
        }
        return false;
    }
}
