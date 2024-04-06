using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class MyStack<T>
    {
        private int StackHead = -1;
        private T[] Stack= new T[1];
        public MyStack() { }
        public void Push(T newItem)
        {
            StackHead++;
            T[] newStack = new T[StackHead+1];
            for(int i = 0; i < StackHead; i++)
            {
                newStack[i] = Stack[i];
            }
            newStack[StackHead] = newItem;
            Stack = newStack;
        }
        public void Pop()
        {
            StackHead = StackHead - 1;
        }
        public T GetStackHead() {
            return Stack[StackHead];
        }
        public bool IsEmpty()
        {
            return StackHead == 0;
        }
    }
}
