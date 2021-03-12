using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{

    [SerializeField] float timeToSpawn = 1f;
    [SerializeField] GameObject pipe1;
    [SerializeField] GameObject pipe2;
    [SerializeField] float height;

    private int pipeNum = 0;
    private Coroutine spawnPipesCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator SpawnPipes()
    {
        while (true)
        {
            if (pipeNum == 0)
            {
                CreateAndMove(pipe1);
            }
            else if (pipeNum == 1)
            {
                CreateAndMove(pipe2);
            }
            yield return new WaitForSeconds(timeToSpawn);
            pipeNum = 1 - pipeNum;
        }
    }

    public void StartSpawning()
    {
        spawnPipesCoroutine = StartCoroutine(SpawnPipes());
    }

    private void CreateAndMove(GameObject pipe)
    {
        GameObject newPipe = Instantiate(pipe);
        Vector3 randFactor = new Vector3(0, Random.Range(-height, height), 0);
        newPipe.transform.position = transform.position + randFactor;
        Destroy(newPipe, 3f); // 5f - Время до уничтоженния объекта-трубы (5c)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
