using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject cube;
    [SerializeField] private GameObject myCube;
    private GameObject _createdCube;
    public Transform[] spawnLocations;

    public ObjectPool pool { get; set; }

    private void Awake()
    {
        myCube = (GameObject) AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cube.prefab");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTentacle()
    {
        Tentacle tentacle = pool.
    }

    public void SummonCube()
    {
        _createdCube = Instantiate(myCube);
    }

    public void DestroyCube()
    {
        Destroy(_createdCube);
    }
}
