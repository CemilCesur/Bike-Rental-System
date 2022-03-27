using System;
using System.Collections.Generic;
using System.Text;

namespace Proje3
{
        class DurakNode
        {
            private Durak dataItem; 
                               
            public DurakNode(Durak key) 
            { dataItem = key; }
            
            public Durak getKey()
            { return dataItem; }
            
            public void setKey(Durak id)
            { dataItem = id; }
            
        }


        class DurakHeap
        {
            private DurakNode[] heapDizi;
            private int maksBoyut; 
            private int anlıkBoyut;
                                     
            public DurakHeap(int maksboyut) 
            {
                maksBoyut = maksboyut;
                anlıkBoyut = 0;
                heapDizi = new DurakNode[maksBoyut]; 
            }
            
            public bool isEmpty()
            { return anlıkBoyut == 0; }
            
            public bool insert(Durak key)
            {
                if (anlıkBoyut == maksBoyut)
                    return false;
                DurakNode node = new DurakNode(key);
                heapDizi[anlıkBoyut] = node;
                trickleUp(anlıkBoyut++);
                return true;
            } 
              
            public void trickleUp(int indeks)
            {
                int parent = (indeks - 1) / 2;
                DurakNode altNode = heapDizi[indeks];

                while (indeks > 0 && heapDizi[parent].getKey().NB < altNode.getKey().NB)
                {
                    heapDizi[indeks] = heapDizi[parent]; 
                    indeks = parent;
                    parent = (parent - 1) / 2;
                } 
                heapDizi[indeks] = altNode;
            } 

            
            public DurakNode remove() 
            {
                DurakNode root = heapDizi[0];
                heapDizi[0] = heapDizi[--anlıkBoyut];
                trickleDown(0);
                return root;
            } 
              
            public void trickleDown(int indeks)
            {
                int enBüyükChild;
                DurakNode root2 = heapDizi[indeks]; 
                while (indeks < anlıkBoyut / 2) 
                { 
                    int leftChild = 2 * indeks + 1;
                    int rightChild = leftChild + 1;
                // 
                if (rightChild < anlıkBoyut && heapDizi[leftChild].getKey().NB < heapDizi[rightChild].getKey().NB)
                { enBüyükChild = rightChild; }
                else
                    enBüyükChild = leftChild;
                    
                    if (root2.getKey().NB >= heapDizi[enBüyükChild].getKey().NB)
                        break;
                    
                    heapDizi[indeks] = heapDizi[enBüyükChild];
                    indeks = enBüyükChild; 
                } 
                heapDizi[indeks] = root2; 
            } 

            

        }
    }
