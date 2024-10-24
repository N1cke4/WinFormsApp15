namespace WinFormsApp15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // �����, ����� ���������������� ���������� �����
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text; // �����, ��������� ����� �� ���������� ����

            // ���������, �������� �� ��������� �������� ������
            if (int.TryParse(input, out int number))
            {
                // �����, ���� ��� �����, ������������ � �������
                label1.Text = ConvertToRoman(number);
            }
            else
            {
                // �����, ���� ��� �� �����, �������� �������������� ��� ������� �����
                label1.Text = ConvertToArabic(input).ToString();
            }
        }

        private string ConvertToRoman(int number)
        {
            // �����, ��� ������ ������� ���� � �� ��������
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

            string result = ""; // �����, ��� ��������� ��� �������� �����
            foreach (var item in romanNumerals)
            {
                // �����, ���� ����� ������ ��� ����� �������� ������� �����
                while (number >= item.Item1)
                {
                    result += item.Item2; // �����, ��������� ������� ����� � ����������
                    number -= item.Item1; // ����� ��������� �����
                }
            }
            return result; // �����, ���������� ������� �����
        }

        private int ConvertToArabic(string roman)
        {
            // �����, ��� ������� ������� ���� � �� ��������
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

            int total = 0; // �����, ���������� ��� �������� ����� ��������� �����
            for (int i = 0; i < roman.Length; i++)
            {
                // �����, ���� ������� �������� ������ ����������, �������� ���
                if (i + 1 < roman.Length && romanNumerals[roman[i]] < romanNumerals[roman[i + 1]])
                {
                    total -= romanNumerals[roman[i]];
                }
                else
                {
                    total += romanNumerals[roman[i]]; // �����, ����� ��������� ���
                }
            }
            return total; // �����, ���������� �������� �����
        }
    }
}
