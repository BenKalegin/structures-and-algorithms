using System.Diagnostics;

namespace interview_questions.geeks4geeks.Trees
{
    [DebuggerDisplay("{" + nameof(Data) + "}")]
    class Node
    {
        internal int Data;
        internal Node Left, Right;

        internal Node(int item)
        {
            Data = item;
            Left = Right = null;
        }
    }
}