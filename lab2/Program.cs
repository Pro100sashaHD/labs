using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    public static void Main()
    {
        string str = Console.ReadLine().Replace(" ", "");
        string num_buffer = "";
        List<int> nums = new List<int>();
        List<char> ops = new List<char>();
        int i = 0;
        for (; i < str.Length; i++)
        {
            if (int.TryParse(Char.ToString(str[i]), out _))
            {
                num_buffer += Char.ToString(str[i]);
            }
            else
            {
                ops.Add(str[i]);
                nums.Add(int.Parse(num_buffer));
                num_buffer = "";
            }
        }
        if (!string.IsNullOrEmpty(num_buffer))
        {
            nums.Add(int.Parse(num_buffer));
        }
        foreach (char op in ops)
        {
            Console.Write(op.ToString() + " ");
        }
        Console.WriteLine();
        foreach (int num in nums)
        {
            Console.Write(num.ToString() + " ");
        }
        Console.WriteLine();
        Console.WriteLine(GetAnswer(nums, ops));
    }

    static int GetAnswer(List<int> nums, List<char> ops)
    {
        while (ops.Count > 0)
        {
            int multiplyId = ops.IndexOf('*');
            int devideId = ops.IndexOf('/');
            int opid = 0;
            if (Math.Max(multiplyId, devideId) < 0 & Math.Min(multiplyId, devideId) < 0)
            {
                opid = 0;
            }
            else if (Math.Min(multiplyId, devideId) < 0 & Math.Max(multiplyId, devideId) >= 0)
            {
                opid = Math.Max(multiplyId, devideId);
            }

            else
            {
                opid = Math.Min(multiplyId, devideId);
            }
            char op = ops[opid];
            int num1 = nums[opid];
            int num2 = nums[opid + 1];
            int result = Calculator(op, num1, num2);
            ops.RemoveAt(opid);
            nums.RemoveAt(opid + 1);
            nums.RemoveAt(opid);
            nums.Insert(opid, result);
        }
        return nums[0];
    }
    static int Calculator(char op, int a, int b)
    {
        switch (op)
        {
            case '+': return a + b;
            case '-': return a - b;
            case '*': return a * b;
            default: return a / b;
        }
    }
}
