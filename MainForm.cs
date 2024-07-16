using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace SecondVersion
{
    public partial class MainForm : Form
    {
        List<FrequencyAnalysis> frequencyList = new List<FrequencyAnalysis>();  //лист, предназначенный для хранения символов и информации о них
        bool docForAnalysisChanged = false;    //флаг, указывающий происходили ли изменения в поле ввода (необходим для предупреждения о несохраненных входных данных)
        bool docChanged = false; //флаг, поднимающийся, если текст в поле ввода был изменен после проведения анализа (необходим для предупреждения пользователя в случае сохранения результатов, если пользователь забудет перерассчитать результаты анализа)
        string fileName;    //переменная для хранения имени файла, открываемого пользователем 
        string stringToPrint;   //переменная для хранения строки, данные из которой будут печататься
        int symbolAmount = 0;   //переменная для подсчета символов в проанализированном тексте

        public MainForm()
        {
            InitializeComponent();
        }

        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformationForm form = new InformationForm();   //при нажатии на кнопку справки создается новый объект формы справки и демонстрируется пользователю
            form.ShowDialog();
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {
            frequencyList.Clear();  //стирание записей прошлого анализа
            Dictionary<char, int> frequency = new Dictionary<char, int>();  //словарь для подсчета ключей и их значений
            symbolAmount = 0;   //переменная для подсчета общего числа анализируемых символов
            foreach (char symbol in richTextBoxForUserInput.Text)   //цикл для посимвольного анализа данных в поле ввода
            {
                char tempSymbol = symbol;   //записывается текущий символ
                int tempNum = (int)tempSymbol;  //и его номер в Юникоде
                if (Char.IsControl(tempSymbol)) //если символ относится к управляющим, цикл пропускает его
                    continue;

                if (tempNum >= 8234 && tempNum <= 8238 //если это символы переворота
                    || tempNum == 8206 || tempNum == 8207
                    || tempNum == 173)  //или мягкий дефис (т.е. символ, указывающий, где можно переносить слово)
                    continue;   //цикл пропускает и эти символы

                if (Char.IsWhiteSpace(tempSymbol) || tempNum == 8203)   //если текущий символ пробел (в том числе пробел нулевой ширины)
                    tempSymbol = ' ';   //то указываем, что это просто пробел

                if ((int)tempSymbol == 8209)    //если символ - это неразрывный дефис, записываем его как обычный дефис
                    tempSymbol = '-';

                if (!frequency.ContainsKey(tempSymbol)) //если в словаре еще нет текущего символа, добавляем его с ключом (абсолютной встречаемостью) равной 1
                    frequency.Add(tempSymbol, 1);
                else
                    frequency[tempSymbol]++;    //иначе увеличиваем значение у уже существующего в словаре символа на 1
                symbolAmount++; //увеличиваем количество проанализированных символов на 1
            }

            if (frequency.Count == 0)   //если в словаре нет записей, выводим ошибку, очищаем данные из таблицы, данные о количестве символов
            {
                MessageBox.Show("Нельзя проанализировать отсутствующий текст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewForResults.RowCount = 0;
                labelForNumber.Text = "не рассчитано";
                toolStripSaveResults.Enabled = false;   //делаем недоступной кнопку сохранения результатов анализа
                return; //и завершаем анализ
            }

            foreach (var item in frequency.OrderByDescending(x => x.Value)) //в упорядоченном по убыванию ключа (абсолютной частоты) словаре перебирается каждый элемент
            {
                string symbol;  //переменная для хранения строкового значения/определения символа
                string toolTip = $"Десятичный код в Юникоде: {(int)item.Key}";  //переменная, записывающая информацию о символе для подсказки
                if (item.Key == ' ')    //если встретился пробел, то вместо пустого графического отображения, будет слово, подсказка будет из этого же слова, так как пробелы могут быть разными, как и коды
                {
                    symbol = "Пробел";
                    toolTip = symbol;
                }
                else
                    symbol = item.Key.ToString();   //в ином случае символ будет преобразован к типу string
                if (item.Key == '-')    //пробел может быть как обычным, так и неразрывным, поэтому подсказка не отображает код
                    toolTip = "Дефис";
                FrequencyAnalysis temp = new FrequencyAnalysis(symbol, item.Value, Math.Round(((double)item.Value) / symbolAmount, 4) * 100, toolTip); //создание нового объекта с информацией о символе
                frequencyList.Add(temp);    //добавление объекта в лист
            }

            int i = 0;  //переменная для перебора строк в таблице
            dataGridViewForResults.RowCount = frequencyList.Count;  //указываем, что в таблице столько же колонок, сколько записей в листе
            foreach (FrequencyAnalysis symbolInfo in frequencyList) //для каждой записи в листе
            {
                dataGridViewForResults.Rows[i].Cells[0].Value = symbolInfo.Symbol;  //записываем в первую колонку сам символ
                dataGridViewForResults.Rows[i].Cells[0].ToolTipText = symbolInfo.ToolTipText;   //устанавливаем для этой колонки подсказку при наведении
                dataGridViewForResults.Rows[i].Cells[1].Value = symbolInfo.Absolutefrequency;   //записываем абсюлутную встречаемость во вторую колонку
                dataGridViewForResults.Rows[i].Cells[2].Value = symbolInfo.Relativefrequency + "%"; //и относительную в третьей
                i++;
            }
            labelForNumber.Text = symbolAmount.ToString();  //записываем над таблицей общее количество символов
            toolStripSaveResults.Enabled = true;    //делаем кнопку сохранения результатов доступной
            docChanged = false; //указываем, что после анализа текст в поле ввода не менялся
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)    //при нажатии на кнопку "Открыть"
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();   //создаем новый объект класса OpenFileDialog
                openFileDialog.DefaultExt = "txt";  //настраиваем фильтры, заголовок окна, запрещаем множественный выбор, задаем расширение файла по умолчанию
                openFileDialog.Filter = "текст|*.txt";
                openFileDialog.Title = "Открыть документ";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() != DialogResult.OK) //если пользователь не нажал на OK, ничего не делаем дальше
                    return;
                Text = "Символьный анализ текста: " + openFileDialog.FileName;  //записываем путь к файлу в шапке(заголовке) формы
                fileName = openFileDialog.FileName; //сохраняем путь к пользовательскому файлу
                
                StreamReader sr = new StreamReader(fileName, Encoding.Default);
                richTextBoxForUserInput.Text = sr.ReadToEnd(); //читаем файл, записывая в richTextBox текст этого файла
                richTextBoxForUserInput.SelectionStart = richTextBoxForUserInput.TextLength;    //перемещаем указатель, откуда пользователь начнет печатать, в конец
                sr.Close(); //закрываем поток
                docForAnalysisChanged = false; //указываем, что документ не изменялся
            }
            catch (Exception ex)    //при возникновении ошибок, выводим сообщение о них
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBoxForUserInput_TextChanged(object sender, EventArgs e)
        {
            docForAnalysisChanged = true;   //указываем, что текст для анализа изменялся после открытия/сохранения пользовательского файла
            docChanged = true;  //указываем, что текст в поле ввода изменялся после анализа
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!docForAnalysisChanged)    //если документ не изменялся (или сохранялся), просто позволяем программе закрыться
                    return;
                string message; //переменная для хранения сообщения пользователю
                if (fileName == null)   //если пользователь не открывал и не сохранял файл с текстом для анализа, просто вводя текст
                    message = "Сохранить анализируемый текст?";
                else
                    message = "Сохранить изменения в анализируемом тексте?";    //если пользователь открывал
                DialogResult dr = MessageBox.Show(message, "Вы покидаете программу", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); //выводим сообщение пользователю и записываем его ответ в переменную
                switch (dr)
                {
                    case DialogResult.Yes:  //если пользователь решил сохранить анализируемый текст, вызываем метод сохранения
                        SaveToolStripMenuItem_Click(sender, e);
                        break;
                    case DialogResult.No:   //не мешаем программе закрыться при отказе
                        break;
                    case DialogResult.Cancel:   //отменяем нажатие на кнопку закрытия при отмене
                        e.Cancel = true;
                        break;
                }
            }
            catch (Exception ex) //при возникновении ошибок, выводим сообщение о них
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != null)   //если путь к файлу имеется, сохраняем пользовательский файл
                SaveFile("user", fileName);
            else    //иначе
            {
                fileName = SaveDialog(); //вызываем метод, возвращающий путь к файлу, выбранный пользователем
                if (fileName == null)   //если ползователь не выбрал файл, прекращаем выполнение метода
                    return;
                Text = "Символьный анализ текста: " + fileName; //записываем в заголовок окна путь к файлу
                SaveFile("user", fileName); //вызываем метод сохранения файла
            }
            docForAnalysisChanged = false; //указываем, что документ не изменялся
        }

        private void SaveFile(string which, string file)
        {
            StreamWriter writer = new StreamWriter(file, false, Encoding.UTF8); //открываем поток для записи
            switch (which)
            {
                case "user":    //если сохраняется пользователский файл, в файл записываются данные из richTextBoxForUserInput
                    writer.Write(richTextBoxForUserInput.Text);
                    break;
                case "result":  //если сохраняется файл результатов анализа, в файле рисуется таблица с данными, а затем выводится уведомление об успешной записи
                    writer.WriteLine($"Общее число символов в проанализированном тексте равно {symbolAmount}.");
                    writer.WriteLine("-------------------------------------------------------------------------------------------------");
                    writer.WriteLine("| Символ\t\t| Абсолютная частота \t| Относительная частота \t|");
                    writer.WriteLine("-------------------------------------------------------------------------------------------------");
                    foreach (FrequencyAnalysis symbol in frequencyList)
                    {
                        if (symbol.Symbol != "Пробел")
                            writer.WriteLine($"| {symbol.Symbol} \t\t| {symbol.Absolutefrequency} \t\t\t| {symbol.Relativefrequency} \t\t\t|");
                        else
                            writer.WriteLine($"| {symbol.Symbol}  \t| {symbol.Absolutefrequency} \t\t\t| {symbol.Relativefrequency} \t\t\t|");
                    }
                    writer.WriteLine("-------------------------------------------------------------------------------------------------");
                    MessageBox.Show($"Результат был успешно записан по адресу {file}.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            writer.Close(); //закрываем поток
        }

        private string SaveDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();   //создаем новый объект класса SaveFileDialog
            saveFileDialog.DefaultExt = "txt";  //настраиваем фильтры, заголовок окна, запрещаем множественный выбор, задаем расширение файла по умолчанию
            saveFileDialog.Filter = "текст|*.txt";
            saveFileDialog.Title = "Сохранить документ";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) //если пользователь нажал ОК, возвращается путь к файлу, в противном слчае null
                return saveFileDialog.FileName;
            else 
                return null;
        }

        private void ResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = DialogResult.OK;  //создаем переменную для управления 
            if (docChanged) //если текст после анализа подвергался изменениям, но не был повторно проанализирован, выводим сообщение пользователю и записываем его ответ
                dr = MessageBox.Show("После анализа текст подвергался редактированию, так что данные об анализе могут быть устаревшими. Все равно сохранить?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (dr)
            {
                case DialogResult.Cancel:   //если пользователь отказался сохранять результаты, ничего не делаем
                    break;
                case DialogResult.OK:   //если пользователь все же решил сохранить результаты или если текст после анализа не изменялся
                    string printFile = SaveDialog();    //записываем в переменную путь к файлу, указанный пользователем
                    if (printFile == null)  //если пользователь ничего не указал, прекращаем выполнение метода
                        return;
                    SaveFile("result", printFile); //вызываем метод сохранения файла с результатами
                    //спрашиваем у пользователя, хочет ли тот распечтать файл, и если ответ не положительный, прекращаем выполнение метода
                    dr = MessageBox.Show("Распечатать сохраненный файл?", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr != DialogResult.Yes)
                        return;
                    StreamReader streamToPrint = new StreamReader(printFile, Encoding.Default); //открываем поток чтения файла по указанному пути
                    stringToPrint = streamToPrint.ReadToEnd();  //считываем текст из файла
                    streamToPrint.Close();  //закрываем поток

                    PrintDocument printDocument = new PrintDocument();
                    printDocument.PrintPage += printDocument_PrintPage; //делегируем печать страниц методу printDocument_PrintPage

                    PrintDialog printDialog = new PrintDialog();
                    printDialog.Document = printDocument;   //записываем в качестве документа для печати созданный прежде документ с делегатом
                    if (printDialog.ShowDialog() == DialogResult.OK)    //открываем окно печати и при нажатии на ОК
                    {
                        printDialog.Document.Print();   //печатаем документ
                        Activate(); //переводим фокус на форму анализа и выводим уведомление об успешной печати
                        MessageBox.Show("Результаты анализа успешно распечатаны.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Times New Roman", 11);   //задаем размер шрифта и сам шрифт
            int charactersOnPage = 0;   //переменная для количества символов на странице
            int linesPerPage = 0;   //переменная для количества строк на странице
            e.Graphics.MeasureString(stringToPrint, printFont, e.MarginBounds.Size,     //измеряет строку при ее отображении заданным шрифтом
                StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);   //и отформатированную по умолчанию, возвращая количество строк на странице и количество знаков в строке

            e.Graphics.DrawString(stringToPrint, printFont, Brushes.Black, e.MarginBounds);    //отрисовка строки черным цветом в пределах указанного прямоугольника   
            stringToPrint = stringToPrint.Substring(charactersOnPage);  //вырезаем из строки для печати отрисованное количество символов
            e.HasMorePages = stringToPrint.Length > 0;  //если остались еще символы в строке для печати, указываем, что надо печатать следующую страницу
        }
    }
}
