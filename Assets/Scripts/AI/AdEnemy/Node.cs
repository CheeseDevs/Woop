using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }
    public class Node
    {
        protected NodeState state;
        public Node parent;
        protected List<Node> children = new List<Node>();
        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();


        public Node()
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach(Node child in children)
            {
                _Attatch(child);
            }
        }

        private void _Attatch(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public object GetDAta(string key)
        {
            object value = null;
            if (_dataContext.TryGetValue(key, out value))
            {
                return value;
            }

            Node node = parent;
            while (node != null)
            {
                value = node.GetDAta(key);
                if (value != null)
                {
                    return value;
                }
                node = node.parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                {
                    return true;
                }
                node = node.parent;
            }
            return false;
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;

    }

    public abstract class Tree: MonoBehaviour
    {
        private Node _root = null;

        protected void Start()
        {
           
        }

        private void Update()
        {
            if (_root != null)
            {
                _root.Evaluate();
            }
        }

        protected abstract Node SetupTree();
    }

    public class Sequence: Node
    {
        public Sequence(): base()
        {

        }
        public Sequence(List<Node> children): base(children)
        {

        }

        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }
            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }

    public class Selector: Node
    {
        public Selector() : base()
        {

        }
        public Selector(List<Node> children) : base(children)
        {

        }

        public override NodeState Evaluate()
        {
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.FAILURE:
                        continue;
                    default:
                        continue;
                }
            }
            state = NodeState.FAILURE;
            return state;
        }
    }
}




