using System.Collections;
using System;
using UnityEngine;
using TreeSharpPlus;

public class TestTree : MonoBehaviour
{
    // Start is called before the first frame update
    public BehaviorMecanim Wanderer;
    public BehaviorMecanim Friend;

    protected Node EyeContact(Val<Vector3> WandererPos, Val<Vector3> FriendPos)
    {
        Vector3 height = new Vector3(0.0f, 1.85f, 0.0f);
        Val<Vector3> WandererHead = Val.V(() => WandererPos.Value + height);
        Val<Vector3> FriendHead = Val.V(() => FriendPos.Value + height);
        return new SequenceParallel(
            Friend.Node_HeadLook(WandererHead),
            Wanderer.Node_HeadLook(FriendHead));
     }
    //protected Node Converse()
    //{
        //return new Sequence(
          //  Wanderer.Node_Gesture("acknowledgeing)),

    //}
    protected Node EyeContack(Val<Vector3> WandererPos, Val<Vector3> FriendPos)
    {
        return new Race(
            this.EyeContact(WandererPos, FriendPos));
    }

    protected Node ApproachAndOrient(Val<Vector3> WandererPos, Val<Vector3> FriendPos)
    {
        return new Sequence(
            Friend.Node_GoToUpToRadius(WandererPos, 1.0f),
            new SelectorParallel(
                Friend.Node_OrientTowards(WandererPos),
                Wanderer.Node_OrientTowards(FriendPos)));
    }
    public Node ConversationTree()
    {
        Val<Vector3> WandererPos = Val.V(() => Wanderer.transform.position);
        Val<Vector3> FriendPos = Val.V(() =>Friend.transform.position);
        return new Sequence(
            this.ApproachAndOrient(WandererPos, FriendPos),
            this.EyeContact(WandererPos, FriendPos));
    }
    // Update is called once per frame
    void Update()
    {
      //  if(Input.GetKeyDown(KeyCode.R) == true)
        //{
         //   BehaviorEvent.Run(
           //     this.ConversationTree(), Wanderer, Friend);
        //}
    }
}
