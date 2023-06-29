
class Program
{

    public static string[] surnames = new string[5];
    public static void Main(string[] arghs)
    {

        Console.WriteLine("Введите 5 фамилий");

        for (int i = 0; i < surnames.Length; i++)
        {
            surnames[i] = Console.ReadLine();
        }

        NumberReader numberReader = new NumberReader();
        numberReader.EnteredNumberEvent += SortSurnamesByNumber;

        while (true)
        {
            try
            {
                numberReader.Read();
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение");
            }
        }

    
    }

    static void SortSurnames()
    {

        Array.Sort(surnames);
        foreach (string surname in surnames)
        {
            Console.WriteLine(surname);
        }

    }

    static void SortSurnamesBackwards()
    {

        Array.Sort(surnames);
        Array.Reverse(surnames);
        foreach (string surname in surnames)
        {
            Console.WriteLine(surname);
        }

    }

    static void SortSurnamesByNumber(int number)
    {
        switch(number)
        {
            case 1: SortSurnames(); break;
            case 2: SortSurnamesBackwards(); break;

        }

    }    
}

public class NumberReader
{
    public delegate void EnteredNumberDelegate(int number);
    public event EnteredNumberDelegate EnteredNumberEvent;

    public void Read()
    {
        Console.WriteLine("Введите 1 для того, чтобы сортировать фамилии по алфавитному порядку или 2 - наоборот");

        int number = Convert.ToInt32(Console.ReadLine());
        if (number != 1 && number != 2) throw new FormatException();
        EnteredNumber(number);
    }

    protected virtual void EnteredNumber(int number)
    {
        EnteredNumberEvent?.Invoke(number);
    }

}