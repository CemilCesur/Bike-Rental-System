using System;
using System.Collections.Generic;
using System.Text;

namespace Proje3
{
    class Node
    {
        private int dataItem; 

        public Node(int key) 
        { dataItem = key; }
 
        public int getKey()
        { return dataItem; }

        public void setKey(int id)
        { dataItem = id; }

    }


    class Heap
    {
        private Node[] heapDizi;
        private int maksBoyut; 
        private int anlıkBoyut; 

        public Heap(int maksboyut) 
        {
            maksBoyut = maksboyut;
            anlıkBoyut = 0;
            heapDizi = new Node[maksBoyut]; 
        }

        public bool isEmpty()
        { return anlıkBoyut == 0; }

        public bool insert(int key)
        {
            if (anlıkBoyut == maksBoyut)
                return false;
            Node node = new Node(key);
            heapDizi[anlıkBoyut] = node;
            trickleUp(anlıkBoyut++);
            return true;
        } 

        public void trickleUp(int indeks)
        {
            int parent = (indeks - 1) / 2;
            Node altNode = heapDizi[indeks];

            while (indeks > 0 && heapDizi[parent].getKey() < altNode.getKey())
            {
                heapDizi[indeks] = heapDizi[parent]; // move it down
                indeks = parent;
                parent = (parent - 1) / 2;
            } 
            heapDizi[indeks] = altNode;
        } 


        public Node remove() 
        { 
            Node root = heapDizi[0];
            heapDizi[0] = heapDizi[--anlıkBoyut];
            trickleDown(0);
            return root;
        } 

        public void trickleDown(int indeks)
        {
            int enBüyükChild;
            Node root2 = heapDizi[indeks]; 
            while (indeks < anlıkBoyut / 2) 
            { 
                int leftChild = 2 * indeks + 1;
                int rightChild = leftChild + 1;

                if (rightChild < anlıkBoyut && heapDizi[leftChild].getKey() < heapDizi[rightChild].getKey())
                { enBüyükChild = rightChild; }
                else
                    enBüyükChild = leftChild;

                if (root2.getKey() >= heapDizi[enBüyükChild].getKey())
                    break;

                heapDizi[indeks] = heapDizi[enBüyükChild];
                indeks = enBüyükChild; 
            } 
            heapDizi[indeks] = root2; 
        }
    }
}
