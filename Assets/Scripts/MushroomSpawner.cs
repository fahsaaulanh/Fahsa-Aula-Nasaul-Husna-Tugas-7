using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject objPrefab;
    [SerializeField] private List<GameObject> _mashrooms;
    [SerializeField] private Vector3 _spawnPos;
    [SerializeField] private Transform _parentSpawn;
    private int _mashroomPool = 20;
    private int _timeInterval = 3;
    private int timer = 0;

    private void Start()
    {
        SpawnMashrrom();
    }

    void FixedUpdate()
    {
        if (timer == 0)
            SpawnInit();
    }

    private void SpawnMashrrom()
    {
        for(int i = 0; i < _mashroomPool; i++)
        {
            var obj = Instantiate(objPrefab, _spawnPos, Quaternion.identity);
            obj.transform.parent = _parentSpawn;
            AddToPool(obj);
            _mashrooms.Add(obj);
        }
    }

    private void AddToPool (GameObject obj)
    {
        obj.transform.position = _spawnPos;
        obj.SetActive(false);
    }

    IEnumerator CountDown(GameObject mashroom)
    {
        for(int i = 0; i <= _timeInterval; i++)
        {
            timer++;
            yield return new WaitForSeconds(1);
        }

        if(timer > _timeInterval)
        {
            timer = 0;
            AddToPool(mashroom);
        }

    }

    private void SpawnInit()
    {
        for(int i = 0; i < 10; i++)
        {
            if(!_mashrooms[i].activeSelf)
            {
                _mashrooms[i].SetActive(true);
            }
            StartCoroutine(CountDown(_mashrooms[i]));
        }

    }
}
