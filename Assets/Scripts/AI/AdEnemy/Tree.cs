using UnityEngine;

namespace BT
{
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
}




