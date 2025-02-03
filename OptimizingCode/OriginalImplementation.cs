namespace OptimizingCode
{
    public class OriginalImplementation
    {
        private static readonly char[] Gsm7Chars = @" !""#$%&'()*+,-./0123456789:;<=>?
@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_abcdefghijklmnopqrstuvwxyz{|}~¡£¥§¿ÄÅÆÇÉÑÖOÜßàäåæèéìñòöoùü€".ToCharArray();

        //Complexity: O(n^2)
        //Behind the scenes, when using contains on a simple array, a linear search is executed, comparing each element by default.
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