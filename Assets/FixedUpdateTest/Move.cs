using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ListItemMonobehaviour<Move>
{
    public float speed = 1;
    public enum UpdateType
    {
        Update,
        FixedUpdate,
    }
    public UpdateType updateType = UpdateType.Update;
    private UpdateType previousUpdateType;

    public enum MoveType
    {
        등속도,
        가속도,
    }
    public MoveType moveType = MoveType.등속도;
    private Vector3 originalPos;

    public enum DeltaTimeType
    {
        TimeDeltaTime,
        TimeFixedDeltaTime,
    }
    private DeltaTimeType deltaTimeType = DeltaTimeType.TimeDeltaTime;
    private float acceleration;

    private new void Awake()
    {
        base.Awake();
        originalPos = transform.position;
        previousUpdateType = updateType;
    }

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (previousUpdateType != updateType)
        {
            previousUpdateType = updateType;
            if (updateType == UpdateType.FixedUpdate)
                deltaTimeType = DeltaTimeType.TimeDeltaTime;
            else
                deltaTimeType = DeltaTimeType.TimeFixedDeltaTime;
        }

        if (updateType != UpdateType.Update)
            return;

        MovePosition();
    }

    private float startTime;
    public void Reset()
    {
        enabled = true;
        startTime = Time.time;
        acceleration = 0;
        transform.position = originalPos;
    }

    private void FixedUpdate()
    {
        if (updateType != UpdateType.FixedUpdate)
            return;

        MovePosition();
    }

    private void MovePosition()
    {
        float moveDistance = GetMoveDistance();
        transform.Translate(moveDistance, 0, 0);

        float checkDistance = 20;
        if (transform.position.x > checkDistance)
        {
            Debug.Log($"{name}, {Application.targetFrameRate}프레임 에서 {checkDistance}거리 돌파 시간:{Time.time - startTime}");
            enabled = false;
        }
    }

    private float GetMoveDistance()
    {
        float deltaTime = deltaTimeType == DeltaTimeType.TimeDeltaTime ? Time.deltaTime : Time.fixedDeltaTime;

        if(moveType == MoveType.등속도)
            return speed * deltaTime;

        switch (moveType)
        {
            case MoveType.등속도:
                return speed * deltaTime;
            case MoveType.가속도:
                acceleration += speed * deltaTime; // <- 더하는 횟수가 증가 <- delta타임을 곱해도 FPS에 따라 누적횟수가 다르기 때문에 다른 결과 보임
                return acceleration;
            default:
                Debug.Assert(true, $"구현하지 않은 타입 {moveType}");
                return 0; 
        }
    }
}
