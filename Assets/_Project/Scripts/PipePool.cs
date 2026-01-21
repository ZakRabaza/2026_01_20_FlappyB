using System;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    [SerializeField] 
    private GameObject _pipePrefab;
    
    [SerializeField] 
    private int _poolSize = 10;
    
    [SerializeField] 
    private float _spawnInterval = 4f;
    
    [SerializeField] 
    private float _spawnX = 10f; 

    private List<GameObject> _pipePool;
    
    private float _timer; 

    private int _currentIndex = 0;

    void Start()
    {
        _pipePool = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++) 
        { 
            GameObject pipe = Instantiate(_pipePrefab);
            pipe.GetComponent<PipeController>().Init();
            pipe.SetActive(false); 
            _pipePool.Add(pipe); 
        }
    }

    void Update()
    {
        _timer += Time.deltaTime; 
        if (_timer >= _spawnInterval) 
        { 
            SpawnPipe(); 
            _timer = 0f; 
        }
    }

    void SpawnPipe()
    {
        GameObject pipe = _pipePool[_currentIndex]; 

        pipe.transform.position = new Vector2(_spawnX, 0f);
        pipe.GetComponent<PipeController>().EditPipeAttributes();
        pipe.SetActive(true); 
        
        _currentIndex++; 
        if (_currentIndex >= _poolSize) 
            _currentIndex = 0; 
    }
    }
