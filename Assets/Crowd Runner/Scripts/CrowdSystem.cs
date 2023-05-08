using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private Transform runnersParent;
    [SerializeField] private GameObject runnerPrefab;
    [Header("Settings")]
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    [SerializeField] private PlayerAnimator playerAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameState())
            return;

        placeRunners();
        if (runnersParent.childCount <= 0)
            GameManager.instance.SetGameState(GameManager.GameState.GameOver);
    }

    private void placeRunners()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childLocalPosition = getRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childLocalPosition;
        }

    }

    private Vector3 getRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }

    public float GetCrowdRadius()
    {
        return radius * Mathf.Sqrt(runnersParent.childCount);
    }

    public void ApplyBonus(Bonustype bonusType, int bonusAmount)
    {
        switch (bonusType)
        {
            case Bonustype.Addition:
                AddRunners(bonusAmount);
                break;
            case Bonustype.Product:
                int runnersToAdd = (runnersParent.childCount * bonusAmount) - runnersParent.childCount;
                AddRunners(runnersToAdd);
                break;
            case Bonustype.Difference:
                RemoveRunners(bonusAmount);
                break;
            case Bonustype.Division:
                int runnersToRemove = runnersParent.childCount - (runnersParent.childCount/bonusAmount);
                RemoveRunners(runnersToRemove);
                break;

        }
    }

    private void AddRunners(int amount)
    {
        for (int i = 0; i < amount; i++)
            Instantiate(runnerPrefab, runnersParent);
        playerAnimator.Run();
    }

    private void RemoveRunners(int amount)
    {
        if(amount > runnersParent.childCount)
                amount = runnersParent.childCount;

        int runnersAmount = runnersParent.childCount;
        for (int i = runnersAmount - 1; i >= runnersAmount - amount; i--)
        {
            Transform runnerToDestroy = runnersParent.GetChild(i);
            runnerToDestroy.SetParent(null);
            Destroy(runnerToDestroy.gameObject);
        }
            
    }
}
