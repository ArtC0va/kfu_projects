namespace Homework2.student
{
    public static class StudentFunc
    {
        public static T GetInfo<T>(string message, Func<string?, (bool isTrue, T value)> parseFunc)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();
                var result = parseFunc(input);
                if (result.isTrue)
                    return result.value;
                else
                    Console.WriteLine("This is not the real information");
            }
        }

        public static(string?, string?, Direction, byte, float, DateOnly) ToStudent(this Student student)
        {
            return (student.FullName, student.Id, student.Speciality, student.Level, student.MiddleMark, student.StartDate);
        }

        public static void PrintOnScreen(Student student)
        {
            Console.WriteLine($"Id - {student.Id} \nFull name - {student.FullName} \tLevel - {student.Level} \nStart educatin - {student.StartDate} on {student.Speciality} \tMiddle mark - {student.MiddleMark}");
        }

        public static string? EnterInfo(string? message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            return input;

        }
    }
}