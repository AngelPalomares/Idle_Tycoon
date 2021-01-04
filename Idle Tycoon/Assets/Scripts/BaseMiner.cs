using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseMiner : MonoBehaviour
{
    private float MoveSpeed = 5f;
    private int initialCollectCapacity = 200;
    private float goldCollectPerSecond = 50f;

    public int currentGold { get; set; }

    public int CollectCapacity { get; set; }
    public float CollectPerSecond { get; set; }

    public bool IsTimeToCollect { get; set; }

    private void Awake()
    {
        IsTimeToCollect = true;
        currentGold = 0;
        CollectCapacity = initialCollectCapacity;
        CollectPerSecond = goldCollectPerSecond;
    }
    public virtual void MoveMiner(Vector3 NewPosition)
    {
        transform.DOMove(NewPosition, duration: 10f / MoveSpeed).OnComplete((() => 
        {
            if (IsTimeToCollect)
            {
                CollectGold();
            }
            else
            {
                DepositGold();
            }
        })).Play();
    }

    protected virtual void CollectGold()
    {

    }

    protected virtual IEnumerator IECollect(int CollectGold,float collectTime)
    {
        yield return null;
    }

    protected virtual void DepositGold()
    {

    }

    public void RotateMiner(int direction)
    {
        if(direction == 1)
        {
            transform.localScale = new Vector3(x: 1, y: 1, z: 1);
        }
        else
        {
            transform.localScale = new Vector3(x: -1, y: 1, z: 1);
        }
    }

    public void ChangeGoal()
    {
        IsTimeToCollect = !IsTimeToCollect;
    }
}
