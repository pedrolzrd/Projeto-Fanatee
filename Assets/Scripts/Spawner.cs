using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
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

    //Objetos/Componentes
    [SerializeField]
    GameObject[] numbers;
    [SerializeField]
    LayerMask col; //layer para detectar onde a peça não pode spawnar

    private void Update()
    {
        
        timeCount += Time.deltaTime;

        if(spawned < maxSpawned)
        {
            if (timeCount > nextSpawn)
            {
                StartCoroutine(Spawn());
                timeCount = 0;
            }
        } 
    }

    //minSpawnValue deve ser sempre numeros negativos

    IEnumerator Spawn()
    {
        //Aleatoriza a posição de Spawn nos eixos X e Z, o Y sempre é 1 que é a altura.
        Vector3 spawnPos = new Vector3(Random.Range(minSpawnValueX, maxSpawnValueX), 1, Random.Range(minSpawnValueZ, maxSpawnValueZ));
        int randomIndex = Random.Range(0, numbers.Length);

        //Checagem se já tem um objeto no lugar onde deveria spawnar
        Collider[] collider = Physics.OverlapSphere(spawnPos, 1, col);
        while(collider.Length > 0)
        {
            //se houver, gera outra posição
            spawnPos = new Vector3(Random.Range(minSpawnValueX, maxSpawnValueX), 1, Random.Range(minSpawnValueZ, maxSpawnValueZ));

            yield return null;
        }

        Instantiate(numbers[randomIndex], spawnPos, Quaternion.Euler(-90, 180, 0));
        spawned++;
        
    }

    private void OnDrawGizmos()
    {
        Vector3 size = new Vector3(maxSpawnValueX, 1, maxSpawnValueZ);
        Gizmos.DrawWireCube(transform.position, size);
    }
}
