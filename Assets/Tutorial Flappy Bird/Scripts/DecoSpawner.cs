using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoSpawner : MonoBehaviour
{

    [System.Serializable]
    public class DecoInfo
    {
        public GameObject go;
        public float scaleMin = 1;
        public float scaleMax = 1;
    }

    public List<DecoInfo> decoInfos;

    public float interval = 2;
    public float randomInterval = 1.5f;
    public float xPosition = 13f;
    IEnumerator Start()
    {
        while (true)
        {
            while (Time.timeScale == 0)
                yield return null;

            // 스폰 시키기.
            var spawnInfo = decoInfos[Random.Range(0, decoInfos.Count)];

            var go = spawnInfo.go;
            var pos = go.transform.position;
            pos.x = xPosition;
            var newGo = Instantiate(go, pos, go.transform.rotation);
            newGo.transform.localScale *= Random.Range(spawnInfo.scaleMin, spawnInfo.scaleMax);


            // 스폰후 시간 쉬기
            float intervalTime = interval + Random.Range(-randomInterval, randomInterval);
            yield return new WaitForSeconds(intervalTime);
        }
    }

}
