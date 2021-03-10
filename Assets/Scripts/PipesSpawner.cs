using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{

    [SerializeField] float timeToSpawn = 1f;
    [SerializeField] GameObject pipe;
    [SerializeField] float height;

    private Coroutine spawnPipesCorontine;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            GameObject newPipe = Instantiate(pipe);
            Vector3 randFactor = new Vector3(0, Random.Range(-height, height), 0);
            newPipe.transform.position = transform.position + randFactor;
            Destroy(newPipe, 5f); // 5f - Время до уничтоженния объекта-трубы (5c)
            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
