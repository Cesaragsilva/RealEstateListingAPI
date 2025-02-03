namespace OptimizingCode
{
    public class BinarySearch
    {
        private static readonly char[] Gsm7Chars = @" !""#$%&'()*+,-./0123456789:;<=>?
@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_abcdefghijklmnopqrstuvwxyz{|}~¡£¥§¿ÄÅÆÇÉÑÖOÜßàäåæèéìñòöoùü€"
        .ToCharArray();

        //Complexity: 𝑂(n)
        //Binary Search finds the values comparing it with the middle value in a sorted list actually,
        //including all the rest iterations narrowing down the search range and thereby improving performance to find out a value..
        public static int IndexOfAnyButGsm7Char(string str, int startIndex, int count)
        {
            if (str.Length == 0) return -1;

            Array.Sort(Gsm7Chars);

            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (Array.BinarySearch(Gsm7Chars, str[i]) < 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
