using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CTextManager : MonoBehaviour {

    public Text _moneyText;
    public Text _levelText;
    public Text _remainingPointText;
    public Text _powerPointText;
    public Text _defensePointText;
    public Text _healthPointText;
    public Slider _expGage;
    public GameObject _player;

    void Awake()
    {
        Screen.SetResolution(1280, 720, true);
    }

    void Start()
    {
        _moneyText.text ="0";
    }

    public void MoneyGet(int money)
    {
        int _money = int.Parse(_moneyText.text);

        _money += money;

        _moneyText.text = _money.ToString();
    }

    void Update()
    {
        CPlayerStat _playerStat = _player.GetComponent<CPlayerStat>();
        _expGage.maxValue = _playerStat._levelupExp;
        _expGage.value = _playerStat._exp;

        _levelText.text = _playerStat._level.ToString() + "레벨";
        _remainingPointText.text = _playerStat._statPoint.ToString();
        _powerPointText.text = _playerStat._power.ToString();
        _defensePointText.text = _playerStat._defense.ToString();
        _healthPointText.text = _playerStat._health.ToString();
    }

}
