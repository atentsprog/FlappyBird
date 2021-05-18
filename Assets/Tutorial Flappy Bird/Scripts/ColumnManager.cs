using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColumnManager : MonoBehaviour
{
    [System.Serializable]
    public class TrapInfo
    {
        public GameObject trap;
        public float ratio;
        public float randomYmin;
        public float randomYmax;
    }

    public List<TrapInfo> traps;

    public float spawnDelay = 3;
    public float spawnDelayRandom = 1;
    public float spawnXPosition = 10f;

    IEnumerator Start()
    {
        while(GameManager.instance.gameover == false)
        {
            // 등장 시킬 트랩 선택.
            TrapInfo newTrap = GetNewTrapInfo();

            // 기둥 스폰(생성).
            Instantiate(newTrap.trap, new Vector3(spawnXPosition, Random.Range(newTrap.randomYmin, newTrap.randomYmax), 0), newTrap.trap.transform.rotation);

            yield return new WaitForSeconds(spawnDelay + Random.Range(-spawnDelayRandom, spawnDelayRandom));
        }
    }

    private TrapInfo GetNewTrapInfo()
    {
        //확률이 적용되지 안은 버전.
        //int selectedIndex = Random.Range(0, traps.Count);
        //return traps[selectedIndex];


        // 확률 적용한 버전.
        float allRatio = traps.Sum(x => x.ratio);
        float randomRatio = Random.Range(0, allRatio);

        float sumRatio = 0;
        foreach(var item in traps)
        {
            sumRatio += item.ratio;
            if (sumRatio > randomRatio)
                return item;
        }
        Debug.Assert(false, $"여기 오면 안됨 sumRatio:{sumRatio}, randomRatio:{randomRatio}");
        return null;
    }
}
