using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTimeSpawner : MonoBehaviour
{
    //Variaveis
    [SerializeField]
    float nextSpawn;
    float timeCount;

    [SerializeField]
    int maxSpawnValueX, minSpawnValueX;

    [SerializeField]
    int maxSpawnValueZ, minSpawnValueZ;
    [SerializeField]
    int maxSpawned; //Valor maximo de bolinhas spawnadas
    [HideInInspector]
    public int spawned;

    [SerializeField]
    GameObject powerUp;
    [SerializeField]
    LayerMask col; //layer para detectar onde a pe�a n�o pode spawnar


    private void Update()
    {
        timeCount += Time.deltaTime;

        if (spawned < maxSpawned)
        {
            if (timeCount > nextSpawn)
            {
                StartCoroutine(Spawn());
                timeCount = 0;
            }
        }
    }

    IEnumerator Spawn()
    {
        //Aleatoriza a posi��o de Spawn nos eixos X e Z, o Y sempre � 1 que � a altura.
        Vector3 spawnPos = new Vector3(Random.Range(minSpawnValueX, maxSpawnValueX), 1, Random.Range(minSpawnValueZ, maxSpawnValueZ));


        //Checagem se j� tem um objeto no lugar onde deveria spawnar
        Collider[] collider = Physics.OverlapSphere(spawnPos, 1, col);
        while (collider.Length > 0)
        {
            //se houver, gera outra posi��o
            spawnPos = new Vector3(Random.Range(minSpawnValueX, maxSpawnValueX), 1, Random.Range(minSpawnValueZ, maxSpawnValueZ));

            yield return null;
        }

        Instantiate(powerUp, spawnPos, Quaternion.Euler(-90, 180, 0));
        spawned++;

    }
}
