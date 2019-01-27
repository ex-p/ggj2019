﻿using UnityEngine;
using Random = UnityEngine.Random;

public class AIAgent : Agent
{
    public float RandomWalkingRadius;
    public bool IsInteracting;
    public LocomotionMap LocomotionMap;
    
    private ActionRepeater actionRepeater;

    protected override void Start()
    {
        base.Start();
        actionRepeater = new ActionRepeater(() => Random.Range(3, 7), GoToRandomPoint);
    }

    protected override void Update()
    {
        base.Update();
        actionRepeater.Tick(Time.deltaTime);
    }

    public void GoTo(Vector3 position)
    {
        NavMeshAgent.SetDestination(position);
    }

    public void GoToRandomPoint()
    {
        if (IsInteracting || LevelPoints.Instance.IsGameFinished) return;
        GoTo(LocomotionMap.GetRandomPoint());
    }
}