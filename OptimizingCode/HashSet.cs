namespace OptimizingCode
{
    public class HashSet
    {
        private static readonly HashSet<char> Gsm7Chars = new(@" !""#$%&'()*+,-./0123456789:;<=>?
@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_abcdefghijklmnopqrstuvwxyz{|}~¡£¥§¿ÄÅÆÇÉÑÖOÜßàäåæèéìñòöoùü€");

        //Complexity: 𝑂(𝑛)
        //Behind the scenes, when using contains in a HashSet object, we will perform a hash search instead of a linear search. It will
        //improve the performance and decrease the compelixty 
        public static int IndexOfAnyButGsm7Char(string str, int startIndex, int count)
        {
            if (str.Length == 0) return -1;

            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (!Gsm7Chars.Contains(str[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
