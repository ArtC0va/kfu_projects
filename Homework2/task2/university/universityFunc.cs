namespace Homework2.university
{
    public static class UniversityFunc
    {
        public static void PrintOnScreen(Worker worker)
        {
            Console.WriteLine($"{worker.Id} data: \nName: {worker.Name} \nUniversity: {worker.University} \n");
        }
    }
}