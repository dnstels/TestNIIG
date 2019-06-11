using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_NIIGaz
{
    class Program
    {
        static void Main(string[] args)
        {
            Attachment pril = new Attachment("Приложение -123");
            Attachment pril_1 = new Attachment("Приложение Я1");
            Attachment pril_2 = new Attachment("Ё");

            Attachment pril_3 = new Attachment();


            Console.WriteLine("Literel: {0} ", pril.lit);
            Console.WriteLine(">> {0}", pril);
                pril.getNexLit(); pril.getNexLit();
            Console.WriteLine(">> {0}", pril);
            Console.WriteLine("\n");
  
            Console.WriteLine(">> {0}", pril_1);
            Console.WriteLine(">> {0}", pril_1);
            Console.WriteLine("\n");
            
            Console.WriteLine(">> {0}", pril_2);
            Console.WriteLine("NexLiterel: {0} ", pril_2.getNexLit());
            Console.WriteLine(">> {0}", pril_2);
            Console.WriteLine("\n");
            
            Console.WriteLine("{0}", pril_3);
            Console.WriteLine("NexLiterel: {0} ", pril_3.getNexLit());
            pril_3.lit = "ё23";
            Console.WriteLine("{0}", pril_3);
            pril_3.getNexLit();
            Console.WriteLine("{0}", pril_3);
            Console.WriteLine("\n");
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    struct Attachment
    {
        public String lit;
        public Attachment(string lit)
        {
            if (lit == null) this.lit = "А";
            //3. Может быть получена из строки вида «Приложение А» и т.п.
            string[] split =lit.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length > 1)
            {
                this.lit = split[1].ToUpper();
            }
            else
            {
                this.lit = lit.ToUpper();
            }
            if (Int32.TryParse(this.lit, out int j))
            {
                if (j < 0) j *= (-1);
                if (j == 0) j++;
                this.lit = j.ToString();
            }
            else if (this.lit.Length > 1)
                this.lit = Char.ToString(this.lit.First());

        }
        public String getNexLit()// 2. метод для присвоения следующего номера приложения. Например, из «Приложения Б», получит «Приложение В» и т.д.
        {
            String str = this.ToString().Trim().Trim('"');
            str = str.Trim().Trim('-');
            string[] split = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            this.lit = split[1];
            Char vabc = abc();
            if (vabc == 'r')
            {
                char ch = getLit();
                if (ch == 'Ё' || ch == 'ё') ch = 'Ж';
                for (char c = (char)((ch+1)); c < 'Я'; c++)
                {
                    if (isPassR(c))
                    {
                        this.lit = Char.ToString(c);
                        return this.lit;
                    };
                }
                this.lit = Char.ToString('A');
                return this.lit;
            }
            else if (vabc != 'c')
            {
                char ch = getLit();

                for (char c = ch; c <= 'Z'; c++)
                {
                    ch = ++c;
                    if (isPassE(ch))
                    {
                        this.lit = Char.ToString(ch);
                        return this.lit;
                    };
                }
                this.lit = "1";
                return this.lit;
            }
            else if(vabc!='\0')
                {
                    Int32.TryParse(this.lit, out int j);
                if (j < 0) j *= (-1);
                    j++;
                    this.lit = j.ToString();
                    return this.lit;
                }
            this.lit="Ошибка";
            return this.lit;
        }
        public bool isPass()
        {
            Char vabc = abc();
            if (vabc == 'r')
            {
                return isPassR(getLit());
            }
            else if (vabc == 'e')
            {
                return isPassE(getLit());
            }
            else if (vabc != '\0')
            {
                return true;
            }
            return false;
        }
        public Char getLit()
        {
            if (this.lit == null)
            {
                this.lit = "А";
            }
            try
            {
                this.lit = this.lit.ToUpper();
                return Convert.ToChar(this.lit);
            }
            catch (FormatException)
            {
                //Console.WriteLine("getLit: '{0}' не в правильном формате для преобразования в Char.",this.lit);
            }
            catch (ArgumentNullException)
            {
                //Console.WriteLine("getLit: Нулевая строка не может быть преобразована в Char.");
            }
            return '\0';
        }
        public bool isPassR(Char c)
        {
            if (c != 'Ё' && c != 'З' && c != 'Й' && c != 'О' && c != 'Ч' && c != 'Ь' && c != 'Ы' && c != 'Ъ' && c != 'ё' && c != 'з' && c != 'й' && c != 'о' && c != 'ч' && c != 'ь' && c != 'ы' && c != 'ъ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Char abc()
        {
            if (Int32.TryParse(this.lit, out int j))
                return 'c';
            else
            {
                Char c = getLit();
                if ((c >= 'А' && c <= 'Я')|| (c >= 'а' && c <= 'я')) { return 'r'; }
                else if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')) { return 'e'; }
            }
            return '\0';
        }
        public bool isPassE(Char c)
        {
            if (c != 'i' && c != 'I' && c != 'o' && c != 'O')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()//1.При преобразовании в строку возвращает текст, удовлетворяющий требованиям.
        {
            if (lit == null) this.lit = "А";
            if (Int32.TryParse(this.lit, out int j))
            {
                if (j < 0) j *= (-1);
                if (j == 0) j++;
                this.lit = j.ToString();
            }
            else if (this.lit.Length > 1)
                this.lit = Char.ToString(this.lit.First());
            if (this.lit == "Ё" || this.lit == "ё") this.lit = "Ж";
            if (isPass())
            {
                 return "\"Приложение " + this.lit.ToUpper() + "\"";
            }
            else
            {
                this.lit=getNexLit();
                return "\"Приложение " + this.lit.ToUpper() + "\"";
            }
        }
    }
}
