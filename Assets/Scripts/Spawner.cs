using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner : MonoBehaviour
{
    //Variaveis
    [SerializeField]
    float nextSpawn;
    float timeCount;
    [SerializeField]
    int maxSpawnValue, minSpawnValue;
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
        Vector3 spawnPos = new Vector3(Random.Range(minSpawnValue, maxSpawnValue), 1, Random.Range(minSpawnValue, maxSpawnValue));
        int randomIndex = Random.Range(0, numbers.Length);

        //Checagem se já tem um objeto no lugar onde deveria spawnar
        Collider[] collider = Physics.OverlapSphere(spawnPos, 1, col);
        while(collider.Length > 0)
        {
            //se houver, gera outra posição
            spawnPos = new Vector3(Random.Range(minSpawnValue, maxSpawnValue), 1, Random.Range(minSpawnValue, maxSpawnValue));

            yield return null;
        }

        Instantiate(numbers[randomIndex], spawnPos, Quaternion.Euler(-90, 0, 0));
        spawned++;
        
    }

    private void OnDrawGizmos()
    {
        Vector3 size = new Vector3(maxSpawnValue, 1, maxSpawnValue);
        Gizmos.DrawWireCube(transform.position, size);
    }

    /*
    Vector3 RandomizePos()
    {
        Vector3 pos = new Vector3(Random.Range(minSpawnValue, maxSpawnValue), 1, Random.Range(minSpawnValue, maxSpawnValue));
        pos = transform.position;

        return pos;
    }
    */
}
