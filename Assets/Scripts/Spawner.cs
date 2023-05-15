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
    GameObject peca;
    [SerializeField]
    LayerMask col; //layer para detectar onde a peça não pode spawnar

    private void Update()
    {
        
        timeCount += Time.deltaTime;

        if(spawned < maxSpawned)
        {
            if (timeCount > nextSpawn)
            {
                Debug.Log("Spawn");
                StartCoroutine(Spawn());
                timeCount = 0;
            }
        } 
    }

    //minSpawnValue deve ser sempre numeros negativos

    IEnumerator Spawn()
    {
        Debug.Log("Spawn2");
        Vector3 spawnPos = new Vector3(Random.Range(minSpawnValue, maxSpawnValue), 1, Random.Range(minSpawnValue, maxSpawnValue));

        //Checagem se já tem um objeto no lugar onde deveria spawnar
        Collider[] collider = Physics.OverlapSphere(spawnPos, 1, col);
        while(collider.Length > 0)
        {
            //se houver, gera outra posição
            spawnPos = new Vector3(Random.Range(minSpawnValue, maxSpawnValue), 1, Random.Range(minSpawnValue, maxSpawnValue));

            yield return null;
        }

        Instantiate(peca, spawnPos, Quaternion.identity);
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
