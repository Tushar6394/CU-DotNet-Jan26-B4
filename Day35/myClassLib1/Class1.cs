// library code 
namespace MyLibrary
{
    public class MyMath
    {
        public int GetSum(params int[] nums)
        {
            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }
            return sum;
        }


        public int GetMultiply(int n1, int n2)
        {
            return n1 * n2;
        }

    }
}