namespace WordSearch_Intetics
{
    class Node
    {
        public int I { get; set; }
        public int J { get; set; }

        public Node(int row, int col)
        {
            I = row;
            J = col;
        }

        public override string ToString()
        {
            return $"[{I},{J}]";
        }
    }
}
