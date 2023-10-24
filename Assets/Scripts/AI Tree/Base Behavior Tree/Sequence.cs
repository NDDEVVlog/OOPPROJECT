using System.Collections.Generic;

namespace BehaviorTree
{
    //Sequence nodes execute their children from left to right.
    //They stop executing when one of their children fails.
    //If a child fails, then the Sequence fails. If all the Sequence's children succeed, then the Sequence succeeds.
    public class Sequence : Node
    {   
        public Sequence() : base() { } //Calling base class constructor in C#
        public Sequence(List<Node> children) : base(children)
        {

        }
        public override NodeState Evalute()
        {
            bool anyChildIsRunning = false;
            foreach (Node child in children) //not in order
            {
                switch (child.Evalute())// call evalute of a child
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state; // break out the function at this time
                    case NodeState.SUCCESS:
                        continue; // continue the other Ob action
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;

                }
            }
            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;

            //create a Selector then analyst this
        }


    }
}