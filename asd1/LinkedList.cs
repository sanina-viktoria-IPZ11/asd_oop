namespace ConsoleApp1
{

    public class LinkedList
    {
        public LinkedList Next;
        public int Data;
        public LinkedList(int data, LinkedList next)
        {
            Data = data;
            Next = next;
        }
    }
}