using UnityEngine;
using System.Collections;

public class CMonsterGen : MonoBehaviour {

    public GameObject MonsterPrefab;

    float x;
    float z;

    void Start ()
    {
        StartCoroutine("MonsterGenStartCoroutine");
	}
	
    IEnumerator MonsterGenStartCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(10f);
            x = Random.Range(-10, 10);
            z = Random.Range(-10, 10);

            Instantiate(MonsterPrefab, new Vector3(transform.position.x + x, 0, transform.position.z + z), Quaternion.identity);
        }
        
    }

	// Update is called once per frame
	void Update () {
	
	}
}
