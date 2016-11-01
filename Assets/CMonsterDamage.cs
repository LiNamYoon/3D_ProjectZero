using UnityEngine;
using System.Collections;

public class CMonsterDamage : MonoBehaviour {

    CPlayerAnimation _anim;
    public SkinnedMeshRenderer MonsterBase;
    float hp = 100f;
    GameObject takeHitPlayer;
    void Awake()
    {
        _anim = GetComponent<CPlayerAnimation>();
    }
    public void HitPlayer(GameObject player)
    {
        takeHitPlayer = player;
    }
	public void Hit(float damage)
    {
        
        hp -= damage;
        StartCoroutine("HitEffectCoroutine");
        Debug.Log(gameObject.name + "의 남은 체력 : " + hp.ToString());
        if (hp <= 0)
        {
            _anim.PlayAnimation(CPlayerStat.State.Die);
            Destroy(gameObject,2f);
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                if(takeHitPlayer.name == player.name)
                {
                    player.SendMessage("ExpUp", 10f);
                }
            }
        }
    }

    IEnumerator HitEffectCoroutine()
    {
        
        MonsterBase.material.color = Color.red;
        //MonsterBase color = Color.red;
        yield return new WaitForSeconds(0.5f);
        //MonsterBase.color = Color.white;
        MonsterBase.material.color = Color.white; ;
    }
}
