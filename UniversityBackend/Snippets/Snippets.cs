using System; 
using System.Collections;
using System.Linq;
using System.Text;


namespace LinQSnippets
{

    public class Snippets
    {

        public static void BasicLinQ()
        {
            string[] cars = { "Volswagen Golf", " VolswagenCalifornia", "Seat Panda", "Audi A3", "Audi A4", "Audi A5" };
            var carlist = from car in cars select car;
            foreach (var car in carlist)
            {
                Console.WriteLine(car);
            }
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }


        }
        //Number Examples

        public static void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var processedNumberList = numbers.Select(num => num * 3).Where(num => num != 9).OrderBy(num => num);


        }
        public static void SearchExamples()
        {
            List<string> textlist = new List<string> { "a", "b", "c", "d", "2", "fe", "edef" };

            var first = textlist.First();

            var firstC = textlist.First(text => text.Equals("c"));

            var firstD = textlist.First(text => text.Contains("d"));


            //Si no tiene z te pondra algo por defecto
            var firstOrDefault = textlist.FirstOrDefault(text => text.Equals("z"));


            var lastOrDefault = textlist.LastOrDefault(text => text.Equals("f"));

            //Single Values

            var uniqueTexts = textlist.Single();
            var uniqueTextsDef = textlist.SingleOrDefault();

            int[] evenNumbers = { 1, 3, 5, 7, 9 };
            int[] oddNumbers = { 0, 2, 4, 6, 8 };
            int[] otheroddNumbers = { 0, 2, 4, 6, 8 };

            var myEvenNumbers = oddNumbers.Except(otheroddNumbers);

        }
        static public void MultipleSelect()
        {
            string[] myOpinions =
            {"a1, b",
            "c2 , d",
            "e3 , f"
            };
            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split());

            var enterprises = new[]
                {
                new Enterprise()
                {
                    id =1,
                    name="CodeWars",
                    employees= new []
                    {
                        new Employee()
                        {
                            id=1,
                            name="Alvaro",
                            email="Hola@gmail.com",
                            salary=3000
                        },new Employee()
                        {
                            id=2,
                            name="Jorge",
                            email="Hola1@gmail.com",
                            salary=30001
                        },new Employee()
                        {
                            id=3,
                            name="Patt",
                            email="Hola3@gmail.com",
                            salary=3000000
                        }
                    }
                },new Enterprise()
                {
                    id =2,
                    name="FoodWars",
                    employees= new []
                    {
                        new Employee()
                        {
                            id=1,
                            name="Ana",
                            email="Hoaala@gmail.com",
                            salary=30002
                        },new Employee()
                        {
                            id=2,
                            name="Claudia",
                            email="Hola21@gmail.com",
                            salary=300
                        },new Employee()
                        {
                            id=3,
                            name="Patto",
                            email="Hola23@gmail.com",
                            salary=1500
                        }
                    }
                } };
            //Obtener Todos los empleados

            var employeeList = enterprises.SelectMany(enterprises => enterprises.employees);

            //Saber si tenemos una lista vacia

            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.employees.Any());

            //All has employees de 1000e

            bool hasEmployeeGSalary = enterprises.Any(enterprise => enterprise.employees.Any(employee => employee.salary >= 1000));
            }

        public static void linQCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "d", "c" };

            //Inner Join

            var commonResult = from element in firstList join element2 in secondList
                               on element equals element2 select new {element,element2};

            var commonResult2 = firstList.Join(
                secondList,element=>element
                ,element2=>element2,
                (element,element2)=>new {element,element2});

            //Outer Join, Left

            var leftOuterjoin = from element in firstList
                                join element2 in secondList on element equals element2
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { element = element };

            //Comparativa entre las dos
            var leftJoin = from element in firstList
                           from element2 in secondList.Where(s => s == element).DefaultIfEmpty()
                           select new {element = element,element2= element2};

            
            var rightOuterjoin = from element in secondList
                                join element2 in firstList on element equals element2
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { element = element };

            //Union
            var unionList = leftOuterjoin.Union(rightOuterjoin);


        }
        public static void SkipTakeLinq()
        {
            var mylist = new[]
            {
                1,2,3,4,5,6,7,8,9,0
            };
            var skipTwoFirst = mylist.Skip(2);
            var skipLastTwo = mylist.SkipLast(2);

            var skipWhile4 = mylist.SkipWhile(num => num < 4);

            //Take contrario a skip

            var takeFirstTwo = mylist.Take(2);
            var takeFirstTwoL = mylist.TakeLast(2);
            var takeFirstTwoW = mylist.TakeWhile(num => num < 4);


        }
    } }


        
            
    
