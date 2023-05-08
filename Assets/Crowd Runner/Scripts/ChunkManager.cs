using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{

    public static ChunkManager instance;


    [Header("Elements")]
    [SerializeField] private LevelSO[] levels;
    private GameObject finishLine;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;    
    }
    void Start()
    {

        //CreateOrderedLevel();
        GenerateLevel();
        finishLine = GameObject.FindWithTag("Finish");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateLevel()
    {
        int currentLevel = GetLevel();

        currentLevel = currentLevel % levels.Length;

        LevelSO level = levels[currentLevel];

        CreateLevel(level.chunks);
    }

    private void CreateLevel(Chunk[] levelChunks)
    {
        Vector3 chunkposition = Vector3.zero;

        for (int i = 0; i < levelChunks.Length; i++)
        {
            Chunk chunktocreate = levelChunks[i];

            if (i > 0)
                chunkposition.z += chunktocreate.GetLength() / 2;
            Chunk chunkistance = Instantiate(chunktocreate, chunkposition, Quaternion.identity, transform);

            chunkposition.z += chunkistance.GetLength() / 2;
        }
    }


        //private void CreateOrderedLevel()
        //{
        //    Vector3 chunkPosition = Vector3.zero;

        //    for (int i = 0; i < levelChunks.Length; i++)
        //    {
        //        Chunk chunkToCreate = levelChunks[i];

        //        if (i > 0)
        //            chunkPosition.z += chunkToCreate.GetLength() / 2;
        //        Chunk chunkIstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

        //        chunkPosition.z += chunkIstance.GetLength() / 2;
        //    }

        //}
        //private void CreateRandomLevel()
        //{
        //    Vector3 chunkPosition = Vector3.zero;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Chunk chunkToCreate = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];

        //        if (i > 0)
        //            chunkPosition.z += chunkToCreate.GetLength() / 2;
        //        Chunk chunkIstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

        //        chunkPosition.z += chunkIstance.GetLength() / 2;
        //    }
        //}

        public float GetFinishZ()
    {
        return finishLine.transform.position.z;
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("level", 0);
    }
}
