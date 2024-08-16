using System.Net;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConceitosBasicosSemInterface 
{

    class Program 
    {
        public static void Main(string[] args) 
        {
            //VariablesAndDataTypes();
            //Operatores();
            ControlStructures();
        }
        #region VariablesAndDataTypes

        //   Variáveis e Tipos de Dados:
        //	  Declare variáveis para armazenar seu nome, idade, altura e se você gosta de programar(booleano).
        //	  Calcule sua idade daqui a 10 anos.
        //    Converta sua altura em centímetros para polegadas.
        public static void VariablesAndDataTypes() 
        {
            string name = "Pedro Fernandes de Miranda Silva";
            int age = 26;
            bool likesProgram = true;
            double personHeight = 1.85;

            Console.WriteLine($"Minha idade depois de 10 anos será {AgeAfter10Years(age)}");
            Console.WriteLine($"Minha altura em polegadas é {HeightCmToInches(personHeight)}");
            Console.WriteLine($"Meu nome invertido é {NomeInvertido(name)}");
            Console.WriteLine($"Meu nome invertido com LINQ é {NomeInvertido(name)}");
        }

        public static int AgeAfter10Years(int age) => age + 10;
        public static double HeightCmToInches(double personHeight) => (personHeight * 10) / 2.54;
        public static string NomeInvertido(string name)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = name.Length - 1; i >= 0; i--) 
            {
                sb.Append(name[i]);
            } 

            return sb.ToString();
            
        }
        /// <summary>
        ///  name.Reverse(): Inverte a ordem dos caracteres da string. retorna um IEnumerable<T>
        ///  ToArray() : Converte a sequência invertida em um array de caracteres. retorna uma array
        ///  new string (...): Cria uma nova string a partir do array de caracteres.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string NomeInvertidoToLINQ(string name) => new string(name.Reverse().ToArray());
        #endregion

        #region Operatores
        //Operadores:
        //    Crie um programa que calcule a área de um círculo, dado o raio.
        //    Escreva um programa que verifica se um número é par ou ímpar.
        //    Faça um programa que verifica se um ano é bissexto.
        public static void Operatores() 
        {
            ProgramCalcAreaCirculo();

            ProgramEvenOrOdd();

            ProgramLeapYear();
        }
        #region Programa que calcula área do circulo
        private static void ProgramCalcAreaCirculo()
        {
            //var pi = Math.PI;
            //Console.WriteLine("Pi como moeda: {0:C}", pi);
            //Console.WriteLine("Pi como porcentagem: {0:P}", pi);
            //Console.WriteLine("Pi em notação científica: {0:E}", pi);

            Console.WriteLine("Defina o raio do Circulo:");

            if (!int.TryParse(Console.ReadLine(), out int raio))
                Console.WriteLine("Raio invalido!");
            else
                Console.WriteLine($"A área do circulo é {raio} * {raio} * {Math.PI.ToString("F2")} = {CalcAreaCirculo(raio)}");
        }
        private static double CalcAreaCirculo(int raio) => raio * raio * double.Parse(Math.PI.ToString("F2"));
        #endregion

        #region Programa que verifica se é impar ou par
        private static void ProgramEvenOrOdd() 
        {
            Console.WriteLine("Digite um numero");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (isEven(number))
                    Console.WriteLine($"O {number} é par");
                else
                    Console.WriteLine($"O {number} é impar");
            }
            else
                Console.WriteLine("Você não digitou um numero valido!");
        }

        private static bool isEven(int number) => number % 2 == 0;
        #endregion

        #region Programa que verifica se o ano é bissexto
        private static void ProgramLeapYear() 
        {
            Console.WriteLine("Digite um ano, 4 digitos.");
            string year = Console.ReadLine();
            if (calcLeapYear(year))
                Console.WriteLine($"O ano {year} é um ano bissexto");
            else
                Console.WriteLine($"O ano {year} não é um ano bissexto");
        }

        private static bool calcLeapYear(string year)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(year[year.Length - 2]);
            sb.Append(year[year.Length - 1]);

            int last2numbersOfYear = int.Parse(sb.ToString());

            return MultiploDe4(last2numbersOfYear);
        }
        
        //As regras para um ano ser bissexto são:
        //Divisível por 4: A maioria dos anos divisíveis por 4 é bissexto.
        //Não divisível por 100: Exceto os anos seculares (terminados em 00), que não são bissextos, a menos que...
        //Divisível por 400: ... sejam divisíveis por 400.
        private static bool MultiploDe4(int number) => (number % 4 == 0 && number % 100 != 0) || number % 400 == 0;
        #endregion
        #endregion

        #region Control Structures

        //Estruturas de Controle:
        //Crie um programa que imprima os números de 1 a 100.
		//Faça um programa que calcule a soma dos números de 1 a N, onde N é um número informado pelo usuário.
        //Implemente um menu com as opções: soma, subtração, multiplicação e divisão.O usuário escolhe a operação e informa os números.
        public static void ControlStructures() 
        {
            // oneToOneHundred();
            SequenceSum();
        }

        private static void oneToOneHundred() 
        {
            int number = 1;
            while(number <= 100) 
            {
                if (number == 100)
                    Console.Write(number);
                else
                    Console.Write($"{number}, ");
                
                number++;
            }
        }

        private static void SequenceSum() 
        {
            Console.WriteLine("Informe um numero para fazer o calculo de 1 a N, onde N é o numero passado:");
            if (int.TryParse(Console.ReadLine(), out int N) || N > 1)
            {
                Console.WriteLine($"A soma de 1 a {N} = {Sum1toN(N)}");
                Console.WriteLine($"A soma de 1 a {N} com a formula de Gauss é = {Sum1toNGauss(N)}");
            }
            else
                Console.WriteLine("Numero digitado invalido!");
        }

        private static int Sum1toN(int N)
        {
            int result = 0;
            
            for (int i = 1; i <= N; i++) 
            {
                result += i;
            }
            return result;
        }

        private static int Sum1toNGauss(int N) => (1 + N) * (N / 2);
        #endregion
    }
}
