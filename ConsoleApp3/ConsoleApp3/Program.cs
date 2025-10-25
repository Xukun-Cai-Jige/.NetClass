/*
1. Describe the problem generics address.
To do the same thing with different types of inputs, for each input we need to define
a differet method which would waste time.

2. How would you create a list of strings, using the generic List class?
List<string> myStrings = new List<string>();

3. How many generic type parameters does the Dictionary class have?
There are 2 parameters

4. True/False. When a generic class has multiple type parameters, they must all match.
False

5. What method is used to add items to a List object?
Add()

6. Name two methods that cause items to be removed from a List.
Remove() and RemoveAt()

7. How do you indicate that a class has a generic type parameter?
Use <> after the class name

8. True/False. Generic classes can only have one generic type parameter.
False

9. True/False. Generic type constraints limit what can be used for the generic type.
True

10. True/False. Constraints let you use the methods of the thing you are constraining to.
True
 */

public class MyStack<T> {
    private Stack<T> stack = new Stack<T>();

    public int Count() {
        return stack.Count();
    }

    public T Pop()
    {
        return stack.Pop();
    }

    public void Push(T obj)
    {
        stack.Push(obj);
    }
}

public class Program
{
    public static void Main()
    {
        MyStack<int> myStack = new MyStack<int>();
        myStack.Push(0);
        myStack.Push(1);
        Console.WriteLine(myStack.Count());
    }
}