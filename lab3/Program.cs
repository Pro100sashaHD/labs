using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;

class Program
{
    public static void Main()
    {
        string str = Console.ReadLine().Replace(" ", "");
        string num_buffer = "";
        List<float> nums = new List<float>();
        List<char> ops = new List<char>();
        int i = 0;
        for (; i < str.Length; i++)
        {
            if (int.TryParse(Char.ToString(str[i]), out _))
            {
                num_buffer += Char.ToString(str[i]);
            }
            else if (str[i] == ',' || str[i] == '.')
            {
                num_buffer += ',';
            }
            else
            {
                ops.Add(str[i]);
                if (!string.IsNullOrEmpty(num_buffer))
                {
                    nums.Add(float.Parse(num_buffer));
                }
                num_buffer = "";
            }
        }
        if (!string.IsNullOrEmpty(num_buffer))
        {
            nums.Add(float.Parse(num_buffer));
        }
        foreach (char op in ops)
        {
            Console.Write(op.ToString() + " ");
        }
        Console.WriteLine();
        foreach (float num in nums)
        {
            Console.Write(num.ToString() + " ");
        }
        Console.WriteLine();
        Console.WriteLine(GetAnswer(nums, ops, procedure(ops)));
    }
    static float GetAnswer(List<float> nums, List<char> ops, List<int> actions)
    {
        ops = Bracketsclear(ops);
        while (ops.Count > 0)
        {
            int currentmaximum = actions.Max();
            int opid = actions.IndexOf(currentmaximum);
            char op = ops[opid];
            float num1 = nums[opid];
            float num2 = nums[opid + 1];
            float result = Calculator(op, num1, num2);
            ops.RemoveAt(opid);
            nums.RemoveAt(opid + 1);
            nums.RemoveAt(opid);
            nums.Insert(opid, result);
            actions.RemoveAt(opid);
        }
        return nums[0];
    }
    static float Calculator(char op, float a, float b)
    {
        switch (op)
        {
            case '+': return a + b;
            case '-': return a - b;
            case '*': return a * b;
            default: return a / b;
        }
    }
    static int GetPriority(char a)
    {
        if (a == '+' || a == '-')
        {
            return 1;
        }
        else if (a == '*' || a == '*')
        {
            return 2;
        }
        else { return 0; }
    }
    static List<int> procedure(List<char> list)
    {
        string opstr = "";
        foreach (char op in list)
        {
            opstr += op.ToString();
        }
        int i = 0;
        string prstr = "";
        int currentpr = 0;
        for (; i < opstr.Length; i++)
        {
            char symbol = opstr[i];
            if (symbol == '(')
            {
                currentpr += 2;
                prstr += "";
            }
            else if (symbol == ')')
            {
                currentpr -= 2;
                prstr += "";
            }
            else
            {
                prstr += (currentpr + GetPriority(symbol)).ToString();
            }
        }
        List<int> procedurelist = new List<int>();
        for (int a = 0; a < prstr.Length; a++)
        {
            procedurelist.Add(int.Parse(prstr[a].ToString()));
        }
        return procedurelist;
    }
    static List<char> Bracketsclear(List<char> ops)
    {
        char RB = '(';
        ops.RemoveAll(x => x == RB);
        char LB = ')';
        ops.RemoveAll(x => x == LB);
        List<char> ops_without_brackets = new List<char>();
        ops_without_brackets = ops;
        return ops_without_brackets;
    }
}

