using System;
using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Xml.Linq;

namespace NikoLab22102022
{
    class Number
    {
        public string Value { get; }
        public int Base { get; }

        public Number(string value, int @base)
        {
            Value = value;
            Base = @base;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Эта программа сделана Кожурковым Георгием Львовичем из группы При-102");
                Console.WriteLine("Примечание: Данная программа не поддерживает операции с числами большими 2 147 483 647");
                Console.WriteLine("Алфавит для 50-ричной системы счисления: 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmn");

                Console.WriteLine();
                Console.WriteLine("Нажмите 1 чтобы из любой системы счисления перевести в любую систему счисения");
                Console.WriteLine("Нажмите 2 чтобы перевести любое число меньше или равное 5000 из десятичной системы счисления в римскую систему счисления");
                Console.WriteLine("Нажмите 3 чтобы перевести любое число меньше или равное 5000 из римской системы счисления в десятичную систему счисления");
                Console.WriteLine("Нажмите 4 чтобы проссумировать два числа в одной системе счисления");
                Console.WriteLine("Нажмите 5 чтобы отнять одно число от другого в одной системе счисления");
                Console.WriteLine("Нажмите 6 чтобы перемножить два числа в одной системе счисления");
                Console.Write("Введите операцию:");

                string operation = Console.ReadLine().Trim();
                Console.WriteLine();

                try
                {
                    if (operation == "1")
                    {
                        ConverterStart();
                    }
                    else if (operation == "2")
                    {
                        ToRomanStart();
                    }
                    else if (operation == "3")
                    {
                        RomanToDecimalStart();
                    }
                    else if (operation == "4")
                    {
                        SumStart();
                    }
                    else if (operation == "5")
                    {
                        StartVichet();
                    }
                    else if (operation == "6")
                    {
                        MultiplicationStart();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Мы не можем сделать эту операцию");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine();
                    Console.Write("Ошибка:");
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
                Console.WriteLine("Вы хотите продолжить работу с Калькулятором, введите 1 если да, и любой другой символ если нет");
                string operationEnd = Console.ReadLine();
                if (operationEnd != "1")
                {
                    Console.Clear();
                    Console.WriteLine("Калькулятор закончил работу");
                    break;
                }
                Console.Clear();
            }
        }

        private static void SumStart()
        {
            Console.WriteLine("Введите через пробел два числа, которые вы хотите сложить, и систему счисления этих чисел");

            string sumReadLine = Console.ReadLine().Trim();
            string[] sumSplit = sumReadLine.Split(" ");

            if (sumSplit.Length < 3)
            {
                throw new ArgumentException("Вы не ввели все числа");
            }
            if (sumSplit.Length >= 4)
            {
                throw new ArgumentException("Вы ввели лишние числа");
            }

            if (int.TryParse(sumSplit[2], out int Base))
                Base = Base;
            else
                Console.WriteLine("Ваше число, обозначающее систему счисления некоректно");

            Number numSum1 = new Number(sumSplit[0], Base);
            Number numSum2 = new Number(sumSplit[1], Base);

            Console.WriteLine(CorrectSum(numSum1, numSum2));
        }

        private static void MultiplicationStart()
        {
            Console.WriteLine("Введите через пробел два числа, которые вы хотите перемножить, и систему счисления этих чисел");

            string mulReadLine = Console.ReadLine().Trim();
            string[] mulSplit = mulReadLine.Split(" ");

            if (mulSplit.Length < 3)
            {
                throw new ArgumentException("Вы не ввели все числа");
            }
            if (mulSplit.Length >= 4)
            {
                throw new ArgumentException("Вы ввели лишние числа");
            }

            if (int.TryParse(mulSplit[2], out int Base))
                Base = Base;
            else
                Console.WriteLine("Ваше число, обозначающее систему счисления некоректно");


            Number numMul1 = new Number(mulSplit[0], Base);
            Number numMul2 = new Number(mulSplit[1], Base);

            Console.WriteLine(Multiplication(numMul1, numMul2));
        }


        static uint RomanToDecimal(string romNumber)
        {

            string rumalf = string.Join(" ", rum);

            Console.WriteLine("Идем по числу {0} слева на право и последовательно переводим элементы этого числа из римских цифр в десятичные числа",romNumber);
            foreach (char rom in romNumber)
            {
                if (!rumalf.Contains(rom))
                {
                    throw new ArgumentException("Ваше число в римской системе счисления не корректно");
                }
            }
            uint res = 0;
            for (int i = 0; i < romNumber.Length; i++)
            {
                if (i != romNumber.Length - 1)
                {
                    string CmLike = string.Join("", romNumber[i], romNumber[i + 1]);

                    if (rumalf.Contains(CmLike))
                    {
                        Console.WriteLine("Число {0} в римской системе счисления это число {1} в десятичной системе счисления", CmLike, nums[Array.IndexOf(rum, CmLike)]);
                        res += nums[Array.IndexOf(rum, CmLike)];
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Число {0} в римской системе счисления это число {1} в десятичной системе счисления", romNumber[i], nums[Array.IndexOf(rum, romNumber[i].ToString())]);
                        res += nums[Array.IndexOf(rum, romNumber[i].ToString())];
                    }
                }
                else
                {
                    Console.WriteLine("Число {0} в римской системе счисления это число {1} в десятичной системе счисления", romNumber[i], nums[Array.IndexOf(rum, romNumber[i].ToString())]);
                    res += nums[Array.IndexOf(rum, romNumber[i].ToString())];
                }

            }
            Console.Write("Суммируем полученные числа и получаем ");
            if (res > 5000)
            {
                throw new ArgumentException("Число должно быть меньше или равно 5000");
            }
            return res;
        }
        private static uint[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static string[] rum = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        private static void RomanToDecimalStart()
        {
            Console.WriteLine("Введите ваше число в римской системе счисления");
            Console.WriteLine("Для справки: \"I\":1,\"IV\":4,\"V\":5,\"IX\":9,\"X\":10,\"XL\":40,\"L\":50,\"XC\":90,\"C\":100,\"CD\":400,\"D\":500,\"CM\":900,\"M\":1000");
            Console.WriteLine();
            string numberRom = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine(RomanToDecimal(numberRom.Trim()));

        }

        private static void ToRomanStart()
        {
            Console.WriteLine("Введите ваше число в десятичной системе счиления меньшее 5000, которое вы хотите перевести в римскую систему счисления");

            if (uint.TryParse(Console.ReadLine().Trim(), out uint number))
                Console.WriteLine(ToRoman(number));
            else
                Console.WriteLine("Ваше число некоректно");
        }

        private static void ConverterStart()
        {
            Console.WriteLine("Введите через пробел число, которое вы хотите перевести из одной системы счисления в другую,");
            Console.WriteLine("систему счисления введенного числа и систему счисления в которую вы хотите перевести введенное число");

            string readLine = Console.ReadLine().Trim();
            string[] splitted = readLine.Split(" ");

            if (splitted.Length < 3)
            {
                throw new ArgumentException("Вы не ввели все числа");
            }
            if (splitted.Length >= 4)
            {
                throw new ArgumentException("Вы ввели лишние числа");
            }


            Number num = new Number(splitted[0], int.Parse(splitted[1]));
            Console.WriteLine(ConvertNotation(num, int.Parse(splitted[2])));
        }

        public static Number Multiplication(Number number1, Number number2)
        {

            StringBuilder Multiplication = new StringBuilder();

            string num1 = number1.Value;
            string num2 = number2.Value;

            int base1 = number1.Base;

            int NumD1 = FromAnyToDec(num1, base1);
            int NumD2 = FromAnyToDec(num2, base1);
            int len = 0;
            string maxNum = "";
            string minNum = "";

            if (NumD1 < NumD2)
            {
                len = num1.Length;
                minNum = num1;
                maxNum = num2;
            }
            else
            {
                len = num2.Length;
                minNum = num2;
                maxNum = num1;
            }

            minNum = new string(minNum.Reverse().ToArray());

            string res1 = "";
            for (int i = 0; i < len; i++)
            {
                int digit2 = DigitConvertor(minNum[i], base1);

                string mul1 = "";

                for (int j = 0; j < digit2; j++)
                {
                    mul1 = Sum(new Number(mul1, base1), new Number(maxNum, base1)).Value;
                }
                string mn = "";
                for (int j = 0; j < i; j++)
                {
                    mn += "0";
                }
                Console.WriteLine(mul1 + mn);
                res1 = Sum(new Number(res1, base1), new Number(mul1 + mn, base1)).Value;
            }

            return new Number(res1.ToString(), number1.Base);
        }

        public static Number CorrectSum(Number number1, Number number2)
        {

            StringBuilder sum = new StringBuilder();

            string num1 = number1.Value;
            string num2 = number2.Value;

            int base1 = number1.Base;

            int NumD1 = FromAnyToDec(num1, base1);
            int NumD2 = FromAnyToDec(num2, base1);
            int len = 0;
            string maxNum = "";
            string minNum = "";

            if (NumD1 > NumD2)
            {
                len = num1.Length;
                maxNum = num1;
                minNum = num2;
            }
            else
            {
                len = num2.Length;
                maxNum = num2;
                minNum = num1;
            }


            maxNum = new string(maxNum.Reverse().ToArray());
            minNum = new string(minNum.Reverse().ToArray());

            int des = 0;
            for (int i = 0; i < len; i++)
            {
                int res = 0;
                int digit1 = DigitConvertor(maxNum[i], base1);
                int digit2 = 0;
                if (i < minNum.Length)
                    digit2 = DigitConvertor(minNum[i], base1);

                res = des + digit1 + digit2;

                if (res >= base1)
                {
                    sum.Append(ConvertToSymbol(res - base1));
                    if (i == len - 1)
                    {
                        sum.Append("1");
                    }
                    else
                    {
                        des = 1;
                    }
                }
                else
                {
                    des = 0;
                    sum.Append(ConvertToSymbol(res));
                }
            }
            string res1 = sum.ToString();
            res1 = new string(res1.Reverse().ToArray());

            return new Number(res1.ToString(), number1.Base);
        }

        
        public static void StartVichet()
        {
            Console.WriteLine("Введите через пробел два числа, которые вы хотите отнять друг от друга, и систему счисления этих чисел");

            string vichetReadLine = Console.ReadLine().Trim();
            string[] vichetSplit = vichetReadLine.Split(" ");
            Console.WriteLine();
            if (vichetSplit.Length < 3)
            {
                throw new ArgumentException("Вы не ввели все числа");
            }
            if (vichetSplit.Length >= 4)
            {
                throw new ArgumentException("Вы ввели лишние числа");
            }

            if (int.TryParse(vichetSplit[2], out int Base))
                Base = Base;
            else
                Console.WriteLine("Ваше число, обозначающее систему счисления некоректно");


            Number numVichet1 = new Number(vichetSplit[0], Base);
            Number numVichet2 = new Number(vichetSplit[1], Base);



            CorrectVichet(numVichet1, numVichet2);
        }

        private static void CorrectVichet(Number numVichet1, Number numVichet2)
        {
            string number1 = numVichet1.Value;
            string number2 = numVichet2.Value;
            int baze = numVichet2.Base;
            int NumD1 = FromAnyToDec(number1, baze);
            int NumD2 = FromAnyToDec(number2, baze);

            string num1 = number1;
            string num2 = number2;
            if (NumD1 > NumD2)
            {
                number1 = num1;
                number2 = num2;
            }
            else
            {
                number1 = num2;
                number2 = num1;
            }

            List<char> charList1 = number1.ToCharArray().ToList();
            List<char> charList2 = number2.ToCharArray().ToList();

            Console.Write(" ");
            Console.WriteLine(number1);
            Console.WriteLine("-");
            Console.Write(" ");
            for (int i = 0; i < charList1.Count - charList2.Count; i++)
            {
                Console.Write("0");
            }
            Console.WriteLine(number2);
            Console.Write(" ");
            for (int i = 0; i < charList1.Count; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            List<int> numberList1 = charList1.Select(c => (int)Alphabet.IndexOf(c)).ToList();
            List<int> numberList2 = charList2.Select(c => (int)Alphabet.IndexOf(c)).ToList();
            int j;

            Console.WriteLine("Производим поразрядное вычитание:");

            for (int i = numberList1.Count - 1; i >= 0; i--)
            {
                j = i - (numberList1.Count - numberList2.Count);

                if (j >= 0)
                {
                    Console.WriteLine("В разряде {0}, мы вычитаем из {1} {2} и получаем:", i + 1, numberList1[i], numberList2[j]);
                    numberList1[i] -= numberList2[j];
                }

                if (i >= 1)
                {
                    Console.WriteLine(String.Join(" ", numberList1));
                }

                while (numberList1[i] < 0)
                {
                    Console.WriteLine("Т.к. до этого мы получили отрицательное число " +
                        "производим заём из следующего разряда и увеличиваем {0} на {1} и получаем {2}", numberList1[i], baze, numberList1[i] + baze);

                    numberList1[i] += baze;
                    numberList1[i - 1]--;
                    Console.WriteLine(String.Join(" ", numberList1));
                }
            }
            if (numberList1.Count == numberList2.Count)
            {
                Console.WriteLine(String.Join(" ", numberList1));
            }
            Console.WriteLine();
            Console.WriteLine("Выведем получившийся ответ в заданной системе счисления:");
            Console.WriteLine();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < numberList1.Count; i++)
            {
                result.Append(Alphabet[numberList1[i]]);
            }
            Console.Write(" ");
            Console.WriteLine(number1);
            Console.WriteLine("-");
            Console.Write(" ");

            for (int i = 0; i < charList1.Count - charList2.Count; i++)
            {
                Console.Write("0");
            }
            Console.WriteLine(number2);
            Console.Write(" ");
            for (int i = 0; i < charList1.Count; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.Write(" ");

            Console.WriteLine(result.ToString());
        }

        public static Number Sum(Number number1, Number number2)
        {

            StringBuilder sum = new StringBuilder();

            string num1 = number1.Value;
            string num2 = number2.Value;

            int base1 = number1.Base;

            int len = 0;
            string maxNum = "";
            string minNum = "";

            if (num1.Length > num2.Length)
            {
                len = num1.Length;
                maxNum = num1;
                minNum = num2;
            }
            else
            {
                len = num2.Length;
                maxNum = num2;
                minNum = num1;
            }


            maxNum = new string(maxNum.Reverse().ToArray());
            minNum = new string(minNum.Reverse().ToArray());

            int des = 0;
            for (int i = 0; i < len; i++)
            {
                int res = 0;
                int digit1 = DigitConvertor(maxNum[i], base1);
                int digit2 = 0;
                if (i < minNum.Length)
                    digit2 = DigitConvertor(minNum[i], base1);

                res = des + digit1 + digit2;

                if (res >= base1)
                {
                    sum.Append(ConvertToSymbol(res - base1));
                    if (i == len - 1)
                    {
                        sum.Append("1");
                    }
                    else
                    {
                        des = 1;
                    }
                }
                else
                {
                    des = 0;
                    sum.Append(ConvertToSymbol(res));
                }
            }
            string res1 = sum.ToString();
            res1 = new string(res1.Reverse().ToArray());

            return new Number(res1.ToString(), number1.Base);
        }
        private static string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static int DigitConvertor(char digit, int Base)
        {
            int result;
            if (digit >= '0' && digit <= '9')
                result = digit - '0';
            else if (digit >= 'A' && digit <= 'Z')
                result = digit - 'A' + 10;
            else if (digit >= 'a' && digit <= 'z')
                result = digit - 'a' + (('Z' - 'A') + 1) + 10;
            else throw new ArgumentException("Введённое число некоректно");

            if (result > Base)
                throw new ArgumentException("Число содрежит символ не из данной системы счисления");
            return result;
        }

        static string ToRoman(uint number)
        {
            if (number > 5000)
                throw new ArgumentException("Число должно быть меньше или равно 5000");

            Console.WriteLine("Последовательно отнимаем от числа {0} максимальные римские цифры, такие что их разность с числом {0}>=0",number);

            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i < nums.Length && number != 0; i++)
            {
                while (number >= nums[i])
                {   
                    Console.WriteLine("Максимальным числом из римской системы счисления, разница которого с числом {0} >=0 будет число {1}", number, rum[i]);
                    number -= nums[i];
                    result.Append(rum[i]);

                }
            }
            Console.Write("Записываем полученные числа из римской системы счисления в одно число и получаем ");
            return result.ToString();
        }

        static int RightFromAnyToDec(string number, int baze)
        {
            Console.WriteLine();

            Console.WriteLine("Перeводим число {0} из {1} системы счисления в десятичную систему счисления",number, baze);

            Console.WriteLine();

            Console.WriteLine("Последовательно проходимся по числу {0} с лева на право и строим его в десятичной системе счисления",number);
            if (baze > 50)
                throw new ArgumentException("Система счисления должна быть меньше или равна 50");

            long result = 0;
            int digitsCount = number.Length;
            int num;
            number = new string(number.Reverse().ToArray());
            for (int i = 0; i < digitsCount; i++)
            {
                char c = number[i];

                if (c >= '0' && c <= '9')
                    num = c - '0';
                else if (c >= 'A' && c <= 'Z')
                    num = c - 'A' + 10;
                else if (c >= 'a' && c <= 'z')
                    num = c - 'a' + (('Z' - 'A') + 1) + 10;
                else throw new ArgumentException("Строка содержит символ не корректный для данной системы счисления");

                if (num >= baze)
                    throw new ArgumentException("Строка содержит символ не корректный для данной системы счисления");

                Console.Write("Добавим к числу {0} {1}*{2}^{3} и получим ",result,num,baze,i);

                
                result += num * (long)Math.Pow(baze,i);

                Console.WriteLine(result);
                
                if (result > 2147483647)
                {
                    throw new ArgumentException("Ваше число слишком большое, см. примечание");
                }
            }

            Console.WriteLine("Мы получили наше число в десятичной системе счисления: {0}",result);
            return (int)result;
        }

        static int FromAnyToDec(string number, int baze)
        {
            if (baze > 50)
                throw new ArgumentException("Система счисления должна быть меньше или равна 50");

            long result = 0;
            int digitsCount = number.Length;
            int num;

            for (int i = 0; i < digitsCount; i++)
            {
                char c = number[i];

                if (c >= '0' && c <= '9')
                    num = c - '0';
                else if (c >= 'A' && c <= 'Z')
                    num = c - 'A' + 10;
                else if (c >= 'a' && c <= 'z')
                    num = c - 'a' + (('Z' - 'A') + 1) + 10;
                else throw new ArgumentException("Строка содержит символ не корректный для данной системы счисления");

                if (num >= baze)
                    throw new ArgumentException("Строка содержит символ не корректный для данной системы счисления");

                result *= baze;
                result += num;

                if (result > 2147483647)
                {
                    throw new ArgumentException("Ваше число слишком большое, см. примечание");
                }
            }

            return (int)result;
        }
        static string FromDecToAny(int number, int baze)
        {
            if (baze > 50)
                throw new ArgumentException("Система счисления должна быть меньше или равна 50");
            StringBuilder builder = new StringBuilder();

            do
            {
                int mod = number % baze;
                char c = ConvertToSymbol(mod);
                builder.Append(c);
                number /= baze;
            } while (number >= baze);

            if (number != 0)
            {
                builder.Append(ConvertToSymbol(number));
            }

            return string.Join("", builder.ToString().Reverse());
        }

        static string RightFromDecToAny(int number, int baze)
        {
            Console.WriteLine();

            Console.WriteLine("Переводим число {0} из десятичной системы счисления в {1} систему счисления", number, baze);
            if (baze > 50)
                throw new ArgumentException("Система счисления должна быть меньше или равна 50");
            StringBuilder builder = new StringBuilder();

            Console.WriteLine("Последовательно находим остатки от деления числа {0} на число {1}, до тех пор пока деление возможно", number, baze);
            do
            {
                int mod = number % baze;
                char c = ConvertToSymbol(mod);
                Console.WriteLine("Остаток от деления числа {0} на {1} равен {2}",number,baze, mod);
                builder.Append(c);
                number /= baze;
            } while (number >= baze);

            Console.WriteLine("Т.к. деление числа {0} на число {1} больше невозможно, то последним остатком будет само число {0}", number, baze);
            if (number != 0)
            {   

                builder.Append(ConvertToSymbol(number));
            }
            Console.WriteLine();
            Console.WriteLine("Записываем получившиеся остатки от деления задом на перёд, попутно переводя их в элементы {0} системы счисления",baze);
            Console.Write("Итоговый ответ: ");
            return string.Join("", builder.ToString().Reverse());
        }
        private static char ConvertToSymbol(int mod)
        {
            char a = 'A';
            char s = 'a';
            if (mod >= 0 && mod <= 9)
                return (char)('0' + mod);
            if (mod >= 10 && mod < 36)
                return (char)('A' + mod - 10);
            if (mod >= 36 && mod <= 62)
                return (char)('a' + mod - 36);
            throw new ArgumentException("ERROR - YOU WILL GO TO THE WORKUTA");
        }


        public static Number ConvertNotation(Number number, int targetBaze)
        {
            int dec = RightFromAnyToDec(number.Value, number.Base);
            string targetValue = RightFromDecToAny(dec, targetBaze);
            return new Number(targetValue, targetBaze);
        }
    }
}