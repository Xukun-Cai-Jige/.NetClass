// See https://aka.ms/new-console-template for more information
/*
What are the six combinations of access modifier keywords and what do they do?
public: Accessible from anywhere
private: Accessible only in the same class
protected: Accesible only in the same class or subclass
Internal: Accesible only in the same assembly
protected internal: Accessible only in the same assembly or in subclass in different assembly
private protected: Accessible in the same assembly and only by subclass


What is the difference between the static, const, and readonly keywords when applied to a type member?
static belongs to type not instance.
const also belongs to type but the value cannot be changed
readonly belongs to type or instance and can be set in constructor

What does a constructor do?
a constructor helps initialize an instance

Why is the partial keyword useful?
It helps maintain the code by allowing developing the same class in different file.
It also allows parallel development

What is a tuple?
A tuple is a kind of data structrue which store fixed size of values with different types

What does the C# record keyword do?
It defines a reference type designed for immutable, value-based data models.

What does overloading and overriding mean?
Overloading means defining multiple methods with the same name but different signatures in one class
Overriding means redefine a methods in a derived class

What is the difference between a field and a property?
a field is directly accessible or controlled, while a property must use get or set to access or control

How do you make a method parameter optional?
by giving a default value when defining the method

What is an interface and how is it different from an abstract class?
An interface is a contract that specifies what membners a class or struct must implement, without providing any implementation details.
The key difference is that an abstract can include both abstract and concrete members, but an interface does not have concrete members

What accessibility level are members of an interface by default ?
public

True / False : Polymorphism allows derived classes to provide different implementations of the same method.
True

True/False: The override keyword is used to indicate that a method in a derived class is providing its own implementation.
True

True / False: The new keyword is used to indicate that a method in a derived class is providing its own implementation.
True

True / False: Abstract methods can be used in a normal (non-abstract) class.
False

True / False: Normal(non -abstract) methods can be used in an abstract class.
True

True / False: Derived classes can override methods that were virtual in the base class.
True

True / False: Derived classes can override methods that were abstract in the base class.
True

True / False: Derived classes must override the abstract methods from the base class.
True

True / False: In a derived class, you can override a method that was neither virtual nor abstract in the base class.
False

True / False: A class that implements an interface does not have to provide an implementation for all of the members of the interface.
False

True / False: A class that implements an interface is allowed to have other members in addition to the interface members.
True

True / False: A class can inherit from more than one base class.
False

True / False: A class can implement more than one interface.
True
*/

using System.Runtime.CompilerServices;

public abstract class Person {
    public int Id { get; set; }
    private int salary;
    public int Salary
        { get { return salary; } 
          set {
            if (value > 0)
            {
                salary = value;
            }
            else { throw new ArgumentOutOfRangeException(); }
            } 
        }
    public DateTime DateOfBirth { get; set; }
    public string[] Address { get; set; } = Array.Empty<string>();

}
public class Instructor : Person{
    public int DepartmentId { get; set; }
}
public class Course { }
public class Student : Person{
    // SelectedCourses is a list of Course objects
    public List<Course> SelectedCourses { get; set; } = new List<Course>();
}