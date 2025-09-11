// See https://aka.ms/new-console-template for more information
/*
What type would you choose for the following “numbers”?


A person’s telephone number
string

A person’s height
float

A person’s age
int

A person’s gender (Male, Female, Prefer Not To Answer)
string

A person’s salary
int

A book’s ISBN
string

A book’s price
float

A book’s shipping weight
float

A country’s population
int

The number of stars in the universe
long

The number of employees in each of the small or medium businesses in the United Kingdom (up to about 50,000 employees per business)
int

What are the differences between value type and reference type variables? What is boxing and unboxing?
Value type stores data in the variable in the stack. Reference type stores the address of the data. Boxing converts value type into
reference typem, while unboxing converts reference type into value type.

What is meant by the terms managed resource and unmanaged resource in .NET?
The managed resource is managed and cleaned by .NET garbage collector while unmanaged resource requires manual control.

What is the purpose of the Garbage Collector in .NET?
To find useless objects and free the memory of these objects.

What happens when you divide an int variable by 0?
System.DivideByZeroException:“Attempted to divide by zero.”

What happens when you divide a double variable by 0?
∞

What happens when you overflow an int variable (assign a value beyond its range)?
It gives the wrong answer

What is the difference between x = y++; and x = ++y;?
x=y++ gives x initial value of y while x = ++y gives x value of initial value of y + 1

What is the difference between break, continue, and return when used inside a loop statement?
Break end the current loop and start the code after the loop. Continue end the current loop and start at the next iteration.
Return end the current function and return the desired value.

What are the three parts of a for statement and which of them are required?
The 3 parts are initialization, condition and iteration. None of them is required

What is the difference between the = and == operators?
= assigns value to a variable, == decides if the left part is equal to the right part.

Does the following statement compile? for ( ; true; ) ;
yes

What interface must an object implement to be enumerated by the foreach statement?
IEnumerable()
*/

//1.How can we find the minimum and maximum values, as well as the number of bytes, for the following data types: sbyte, byte, short, ushort, int, uint, long, ulong, float, double, and decimal?
solution1 s1 = new solution1();

solution2 s2 = new solution2();


/* infinite loop
 int max = 500;
for (byte i = 0; i < max; i++)
{
    Console.WriteLine(i);
}
 */
solution3 s3 = new solution3();
int[] nums = { 1, 2, 3, 5 };
int[] result = s3.TwoSum(nums, 5);
Console.WriteLine(string.Join(", ", result));
public class solution1 {
    public void printsbyte() {
        Console.WriteLine(sbyte.MinValue);
        Console.WriteLine(sbyte.MaxValue);
        Console.WriteLine(sizeof(sbyte));
    }
    public void printbyte()
    {
        Console.WriteLine(byte.MinValue);
        Console.WriteLine(byte.MaxValue);
        Console.WriteLine(sizeof(byte));
    }

    public void printshort()
    {
        Console.WriteLine(short.MinValue);
        Console.WriteLine(short.MaxValue);
        Console.WriteLine(sizeof(short));
    }

    public void printushort()
    {
        Console.WriteLine(ushort.MinValue);
        Console.WriteLine(ushort.MaxValue);
        Console.WriteLine(sizeof(ushort));
    }

    public void printint()
    {
        Console.WriteLine(int.MinValue);
        Console.WriteLine(int.MaxValue);
        Console.WriteLine(sizeof(int));
    }

    public void printuint()
    {
        Console.WriteLine(uint.MinValue);
        Console.WriteLine(uint.MaxValue);
        Console.WriteLine(sizeof(uint));
    }

    public void printlong()
    {
        Console.WriteLine(long.MinValue);
        Console.WriteLine(long.MaxValue);
        Console.WriteLine(sizeof(long));
    }

    public void printulong()
    {
        Console.WriteLine(ulong.MinValue);
        Console.WriteLine(ulong.MaxValue);
        Console.WriteLine(sizeof(ulong));
    }

    public void printfloat()
    {
        Console.WriteLine(float.MinValue);
        Console.WriteLine(float.MaxValue);
        Console.WriteLine(sizeof(float));
    }

    public void printdouble()
    {
        Console.WriteLine(double.MinValue);
        Console.WriteLine(double.MaxValue);
        Console.WriteLine(sizeof(double));
    }

    public void printdecimal()
    {
        Console.WriteLine(decimal.MinValue);
        Console.WriteLine(decimal.MaxValue);
        Console.WriteLine(sizeof(decimal));
    }
}

//2. Write a method in C# called FizzBuzz that takes an integer num and prints numbers from 1 up to num, but:

public class solution2 {
    public void FizzBuzz(int num) {
        for (int i = 1; i <= num; i++) {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");

            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else {
                Console.WriteLine(i);
            }
        }
    }
}

public class solution3 {
    public int[] TwoSum(int[] nums, int target)
    {
        int[] res = new int[2];
        for (int i = 0; i < nums.Length - 1; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[i] + nums[j] == target)
                {
                    res[0] = i;
                    res[1] = j;
                    return res;
                }
            }
        }
        throw new ArgumentException("No two sum solution found");
    }
}


