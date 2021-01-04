using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    [SerializeField]
    private Transform ShaftMiningLocation;
    [SerializeField] private Transform shaftDepositLocation;

    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            MoveMiner(ShaftMiningLocation.position);
        }
    }

    public override void MoveMiner(Vector3 NewPosition)
    {
        base.MoveMiner(NewPosition);
        Anim.SetTrigger("Walking");
    }

    protected override void CollectGold()
    {
        float collectTime = CollectCapacity / CollectPerSecond;

        Anim.SetTrigger("Minning");
        StartCoroutine(IECollect(CollectCapacity, collectTime));

    }

    protected override IEnumerator IECollect(int CollectGold,float collectTime)
    {
        yield return new WaitForSeconds(collectTime);
        //Update Current Gold
        currentGold = CollectGold;
        ChangeGoal();
        RotateMiner(direction:-1);
        MoveMiner(shaftDepositLocation.position);
    }

    protected override void DepositGold()
    {
        // Add CurrentGold to the Deposit(class)
        // Update some Values
        currentGold = 0;
        ChangeGoal();
        RotateMiner(1);
        MoveMiner(ShaftMiningLocation.position);
    }
}
