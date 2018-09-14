using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// commit 1
// commit 2
namespace epam
{
    public class Group
    {
        public int GroupID { get; set; }
    }
    public class Student:Group
    {
        public string First { get; set; }
        public string Last { get; set; }
        public List<int> Rating;
    }


    class Program
    {
        public static List<Student> students = new List<Student>
            {
                new Student {First="Елена", Last="Иванова", GroupID = 1, Rating= new List<int> {4, 5, 6, 7}}
            };
        static void Main(string[] args)
        {
            Console.WriteLine("Здаравствуйте");
            Console.WriteLine("В какой группе желаете посчитать средний балл? ");
            int id = Int32.Parse(Console.ReadLine());

            var studentQuery1 =
                from student in students
                let totalScore = student.Rating.Average()
                where student.GroupID == id
                select totalScore ;

            Console.WriteLine("Средние балы по ученикам: ");
            foreach (var s in studentQuery1)
            {
                Console.WriteLine(s);
            }

            double averageScore = studentQuery1.Average();
            Console.WriteLine("Средний балл группы = {0}", averageScore);
            Console.ReadLine();
        } 
    }
}
