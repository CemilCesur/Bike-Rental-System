using System;
using System.Collections.Generic;
using System.Text;

namespace Proje3
{
    class Tree
    {
        private TreeNode root;
        public int sayi;


        public Tree() { root = null; }

        public TreeNode getRoot() { return root; }


        public void preOrder ( TreeNode localRoot)
        {
            if (localRoot != null) 
            {
                localRoot.displayNode();
                preOrder(localRoot.leftChild);
                preOrder(localRoot.rightChild);
            }
        }


        public void inOrder (TreeNode localRoot)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.leftChild);
                localRoot.displayNode();
                inOrder(localRoot.rightChild);
            }
        }


        public void postOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                postOrder(localRoot.leftChild);
                postOrder(localRoot.rightChild);
                localRoot.displayNode();
            }
        }

        public void preOrderMüşteriBulmak(TreeNode localRoot, int müşteriID)
        {
            if (localRoot != null)
            {
                localRoot.displayNode2(müşteriID);
                preOrderMüşteriBulmak(localRoot.leftChild, müşteriID);
                preOrderMüşteriBulmak(localRoot.rightChild, müşteriID);
            }
        }

        public void preOrderMüşteriEklemek(TreeNode localRoot, int müşteriID, String durakAdı)
        {
            if (localRoot != null)
            {
                localRoot.editNode(müşteriID, durakAdı);
                preOrderMüşteriEklemek(localRoot.leftChild, müşteriID, durakAdı);
                preOrderMüşteriEklemek(localRoot.rightChild, müşteriID, durakAdı);
            }
        }




        public void insert (Durak newdata, List<Müşteri> müşteriList)
        {
            TreeNode newNode = new TreeNode();
            newNode.data = newdata;
            newNode.müşteriler = müşteriList;

            if (root == null) { root = newNode; }
            else
            {
                TreeNode current = root;
                TreeNode parent;

                while (true)
                {
                    parent = current;
                    
                    if (string.Compare(current.data.durakAdı , newdata.durakAdı) > 0)
                    {
                        current = current.leftChild;
                        if(current==null) { parent.leftChild = newNode; return; }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current==null) { parent.rightChild = newNode; return; }
                    }
                }
            }
        }



    }
}
