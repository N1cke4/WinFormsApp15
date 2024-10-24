namespace WinFormsApp15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Игорь, здесь инициализируются компоненты формы
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text; // Игорь, считываем текст из текстового поля

            // Проверяем, является ли введенное значение числом
            if (int.TryParse(input, out int number))
            {
                // Игорь, если это число, конвертируем в римское
                label1.Text = ConvertToRoman(number);
            }
            else
            {
                // Игорь, если это не число, пытаемся конвертировать как римское число
                label1.Text = ConvertToArabic(input).ToString();
            }
        }

        private string ConvertToRoman(int number)
        {
            // Игорь, это список римских цифр и их значений
            var romanNumerals = new List<Tuple<int, string>>()
            {
                new Tuple<int, string>(1000, "M"),
                new Tuple<int, string>(900, "CM"),
                new Tuple<int, string>(500, "D"),
                new Tuple<int, string>(400, "CD"),
                new Tuple<int, string>(100, "C"),
                new Tuple<int, string>(90, "XC"),
                new Tuple<int, string>(50, "L"),
                new Tuple<int, string>(40, "XL"),
                new Tuple<int, string>(10, "X"),
                new Tuple<int, string>(9, "IX"),
                new Tuple<int, string>(5, "V"),
                new Tuple<int, string>(4, "IV"),
                new Tuple<int, string>(1, "I")
            };

            string result = ""; // Игорь, это результат для римского числа
            foreach (var item in romanNumerals)
            {
                // Игорь, пока число больше или равно значению римской цифры
                while (number >= item.Item1)
                {
                    result += item.Item2; // Игорь, добавляем римскую цифру к результату
                    number -= item.Item1; // здесь уменьшаем число
                }
            }
            return result; // Игорь, возвращаем римское число
        }

        private int ConvertToArabic(string roman)
        {
            // Игорь, вот словарь римских цифр и их значений
            var romanNumerals = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            int total = 0; // Игорь, переменная для хранения суммы арабского числа
            for (int i = 0; i < roman.Length; i++)
            {
                // Игорь, если текущее значение меньше следующего, вычитаем его
                if (i + 1 < roman.Length && romanNumerals[roman[i]] < romanNumerals[roman[i + 1]])
                {
                    total -= romanNumerals[roman[i]];
                }
                else
                {
                    total += romanNumerals[roman[i]]; // Игорь, иначе добавляем его
                }
            }
            return total; // Игорь, возвращаем арабское число
        }
    }
}
