using System.Diagnostics;

namespace microsoft_questions.geeks4geeks
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