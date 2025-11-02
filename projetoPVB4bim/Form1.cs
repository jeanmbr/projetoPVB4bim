using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.InteropServices;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.IO;

namespace projetoPVB4bim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filePath = @"C:\pacientes.json";

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            int id = 1;
            float peso = 0;
            float altura = 0;
            string nome = "";
            String[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.Contains("\"Id\":"))
                {
                    int startIndex = line.IndexOf("\"Id\":") + 5;
                    string idString = line.Substring(startIndex).Trim();
                    idString = idString.Replace(",", "").Replace("}", "").Trim();
                    int currentId = int.Parse(idString);
                    if (currentId >= id)
                    {
                        id = currentId + 1;
                    }
                }
            }

            if (textBoxPeso.Text != "")
            {
                peso = float.Parse(textBoxPeso.Text);
                if (peso <= 30 || peso >= 300)
                {
                    MessageBox.Show("O peso deve estar entre 30 quilogramas e 300 quilogramas!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("É necessário informar o peso do paciente!");
                return;
            }

            if (textBoxAltura.Text != "")
            {
                altura = float.Parse(textBoxAltura.Text);
                if (altura < 0.53 || altura > 2.51)
                {
                    MessageBox.Show("A altura deve estar entre 0,53m e 2,51m!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("É necessário informar a altura do paciente!");
                return;
            }

            if (textBoxNome.Text != "")
            {
                nome = textBoxNome.Text;
                if (nome.Length < 3)
                {
                    MessageBox.Show("O nome precisa conter pelo menos 3 caracteres!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("É necessário informar o nome do paciente!");
                return;
            }

            float imc = peso / (altura * altura);
            string classification = "";

            if (imc < 18.5)
            {
                classification = "Magreza";
            }
            else if (imc <= 24.9)
            {
                classification = "Saudável";
            }
            else if (imc <= 29.9)
            {
                classification = "Sobrepeso";
            }
            else if (imc <= 34.9)
            {
                classification = "Obesidade Grau I";
            }
            else if (imc <= 39.9)
            {
                classification = "Obesidade Grau II";
            }
            else
            {
                classification = "Obesidade Grau III";
            }

            string json =
                "    {\n" +
                "        \"Id\": " + id.ToString() + ",\n" +
                "        \"Nome\": \"" + nome + "\",\n" +
                "        \"Peso (Kg)\": " + peso.ToString().Replace(",", ".") + ",\n" +
                "        \"Altura (m)\": " + altura.ToString().Replace(",", ".") + ",\n" +
                "        \"IMC\": " + imc.ToString().Replace(",", ".") + ",\n" +
                "        \"Classificação\": \"" + classification + "\"\n" +
                "    }";

            string fileContent = File.ReadAllText(filePath);

            if (fileContent.Trim() == "[]" || fileContent.Trim() == "")
            {
                fileContent = "[\n" + json + "\n]";
            }
            else
            {
                if (fileContent.Trim().EndsWith("]"))
                {
                    fileContent = fileContent.TrimEnd(']');
                }
                fileContent += ",\n" + json + "\n]";
            }

            File.WriteAllText(filePath, fileContent);
            MessageBox.Show("Paciente " + nome + " cadastrado com sucesso!");
            textBoxAltura.Clear();
            textBoxNome.Clear();
            textBoxPeso.Clear();
            textBoxDados.Clear();
            listBoxID.Items.Add(id);
        }

        private void textBoxPeso_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (listBoxID.Text != "")
            {
                id = int.Parse(listBoxID.Text);
            }
            else
            {
                MessageBox.Show("É necessário selecionar um ID!");
                return;
            }

            String[] lines = File.ReadAllLines(filePath);
            bool found = false;
            string nome = "";
            float peso = 0;
            float altura = 0;
            float imc = 0;
            string classification = "";

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.Contains("\"Id\":"))
                {
                    int startIndex = trimmedLine.IndexOf("\"Id\":") + 5;
                    string idString = trimmedLine.Substring(startIndex).Trim();
                    idString = idString.Replace(",", "").Replace("}", "").Replace("]", "").Trim();

                    int currentId = int.Parse(idString);

                    if (currentId == id)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                    continue;
                }

                if (found == true && trimmedLine.StartsWith("\"Nome\":"))
                {
                    int valueStart = trimmedLine.IndexOf(':');
                    if (valueStart != -1)
                    {
                        valueStart = trimmedLine.IndexOf('"', valueStart);
                    }

                    if (valueStart != -1)
                    {
                        int startIndex = valueStart + 1;
                        int valueEnd = trimmedLine.LastIndexOf('"');

                        int length = valueEnd - startIndex;
                        nome = trimmedLine.Substring(startIndex, length).Trim();
                    }
                    continue;
                }

                if (found == true && trimmedLine.StartsWith("\"Peso (Kg)\":"))
                {
                    int startIndex = trimmedLine.IndexOf(":") + 1;
                    string weightString = trimmedLine.Substring(startIndex).Trim();
                    weightString = weightString.Replace(",", "").Replace("}", "").Replace("]", "").Replace(".", ",");
                    peso = float.Parse(weightString);
                    continue;
                }

                if (found == true && trimmedLine.StartsWith("\"Altura (m)\":"))
                {
                    int startIndex = trimmedLine.IndexOf(":") + 1;
                    string heightString = trimmedLine.Substring(startIndex).Trim();
                    heightString = heightString.Replace(",", "").Replace("}", "").Replace("]", "").Replace(".", ",");
                    altura = float.Parse(heightString);
                    continue;
                }

                if (found == true && trimmedLine.StartsWith("\"IMC\":"))
                {
                    int startIndex = trimmedLine.IndexOf(":") + 1;
                    string imcString = trimmedLine.Substring(startIndex).Trim();
                    imcString = imcString.Replace(",", "").Replace("}", "").Replace("]", "").Replace(".", ",");
                    imc = float.Parse(imcString);
                    continue;
                }

                if (found == true && trimmedLine.StartsWith("\"Classificação\":"))
                {
                    int valueStart = trimmedLine.IndexOf(':');
                    if (valueStart != -1)
                    {
                        valueStart = trimmedLine.IndexOf('"', valueStart);
                    }

                    if (valueStart != -1)
                    {
                        int startIndex = valueStart + 1;
                        int valueEnd = trimmedLine.LastIndexOf('"');

                        int length = valueEnd - startIndex;
                        classification = trimmedLine.Substring(startIndex, length).Trim();
                    }
                    break;
                }
            }

            if (found == true)
            {
                textBoxDados.Text =
                     "- ID: " + id.ToString() + Environment.NewLine +
                     "- Nome: " + nome + Environment.NewLine +
                     "- Peso: " + peso.ToString("0.00") + Environment.NewLine +
                     "- Altura: " + altura.ToString("0.00") + Environment.NewLine +
                     "- IMC: " + imc.ToString("0.00") + Environment.NewLine +
                     "- Classificação: " + classification;
            }
            else
            {
                MessageBox.Show("ID não encontrado!");
            }
        }

        private void listBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAltura_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            int id = 0;
            string newName = "";
            float newWeight = 0;
            float newHeight = 0;

            if (listBoxID.Text != "")
            {
                id = int.Parse(listBoxID.Text);
            }
            else
            {
                MessageBox.Show("É necessário selecionar um ID para a alteração!");
                return;
            }

            if (textBoxPeso.Text != "")
            {
                newWeight = float.Parse(textBoxPeso.Text);
                if (newWeight <= 30 || newWeight >= 300)
                {
                    MessageBox.Show("O peso deve estar entre 30 quilogramas e 300 quilogramas!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("É necessário informar o peso do paciente!");
                return;
            }

            if (textBoxAltura.Text != "")
            {
                newHeight = float.Parse(textBoxAltura.Text);
                if (newHeight < 0.53 || newHeight > 2.51)
                {
                    MessageBox.Show("A altura deve estar entre 0,53m e 2,51m!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("É necessário informar a altura do paciente!");
                return;
            }

            if (textBoxNome.Text != "")
            {
                newName = textBoxNome.Text;
                if (newName.Length < 3)
                {
                    MessageBox.Show("O nome deve conter pelo menos 3 caracteres!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Informe o nome do paciente!");
                return;
            }

            float newImc = newWeight / (newHeight * newHeight);
            string newClassification = "";

            if (newImc < 18.5)
            {
                newClassification = "Magreza";
            }
            else if (newImc <= 24.9)
            {
                newClassification = "Saudável";
            }
            else if (newImc <= 29.9)
            {
                newClassification = "Sobrepeso";
            }
            else if (newImc <= 34.9)
            {
                newClassification = "Obesidade Grau I";
            }
            else if (newImc <= 39.9)
            {
                newClassification = "Obesidade Grau II";
            }
            else
            {
                newClassification = "Obesidade Grau III";
            }

            String[] lines = File.ReadAllLines(filePath);
            bool found = false;
            bool updated = false;

            string weightString = newWeight.ToString().Replace(",", ".");
            string heightString = newHeight.ToString().Replace(",", ".");
            string imcString = newImc.ToString().Replace(",", ".");

            for (int i = 0; i <= lines.Length - 1; i++)
            {
                string trimmedLine = lines[i].Trim();

                if (trimmedLine.Contains("\"Id\":"))
                {
                    int startIndex = trimmedLine.IndexOf("\"Id\":") + 5;
                    string idString = trimmedLine.Substring(startIndex).Trim();
                    idString = idString.Replace(",", "").Replace("}", "").Replace("]", "").Trim();

                    int currentId = int.Parse(idString);

                    if (currentId == id)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                }

                if (found == true && trimmedLine.StartsWith("\"Nome\":"))
                {
                    lines[i] = "        \"Nome\": \"" + newName + "\",";
                    updated = true;
                }

                if (found == true && trimmedLine.StartsWith("\"Peso (Kg)\":"))
                {
                    lines[i] = "        \"Peso (Kg)\": " + weightString + ",";
                    updated = true;
                }

                if (found == true && trimmedLine.StartsWith("\"Altura (m)\":"))
                {
                    lines[i] = "        \"Altura (m)\": " + heightString + ",";
                    updated = true;
                }

                if (found == true && trimmedLine.StartsWith("\"IMC\":"))
                {
                    lines[i] = "        \"IMC\": " + imcString + ",";
                    updated = true;
                }

                if (found == true && trimmedLine.StartsWith("\"Classificação\":"))
                {
                    lines[i] = "        \"Classificação\": \"" + newClassification + "\"";
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                File.WriteAllLines(filePath, lines);
                textBoxDados.Clear();
                textBoxAltura.Clear();
                textBoxNome.Clear();
                textBoxPeso.Clear();
                MessageBox.Show("O registro com o ID " + id.ToString() + " foi alterado com sucesso!");
            }
            else
            {
                MessageBox.Show("Houve um erro na alteração do registro!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (line.Contains("\"Id\":"))
                {
                    int startIndex = line.IndexOf("\"Id\":") + 5;
                    string idString = line.Substring(startIndex).Trim();
                    idString = idString.Replace(",", "").Replace("}", "").Trim();
                    int currentId = int.Parse(idString);
                    listBoxID.Items.Add(currentId);
                }
            }
        }

        private void textBoxDados_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (listBoxID.Text != "")
            {
                id = int.Parse(listBoxID.Text);
            }
            else
            {
                MessageBox.Show("É necessário selecionar um ID para a exclusão!");
                return;
            }

            String[] lines = File.ReadAllLines(filePath);

            int linesToKeep = lines.Length;
            bool deleteLine = false;
            bool found = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string trimmedLine = lines[i].Trim();
                if (trimmedLine.StartsWith("{"))
                {
                    deleteLine = false;
                }
                if (trimmedLine.Contains("\"Id\":"))
                {
                    int startIndex = trimmedLine.IndexOf("\"Id\":") + 5;
                    string idString = trimmedLine.Substring(startIndex).Trim();
                    idString = idString.Replace(",", "").Replace("}", "").Replace("]", "").Trim();
                    int currentId = int.Parse(idString);
                    if (currentId == id)
                    {
                        deleteLine = true;
                        found = true;
                        linesToKeep -= 8;
                        break;
                    }
                }
                if (!deleteLine)
                {
                    linesToKeep++;
                }
            }

            if (found == false)
            {
                MessageBox.Show("O ID " + id.ToString() + " não foi encontrado para sua exclusão!");
                return;
            }

            String[] keepJsonLines = new String[linesToKeep];
            int newArrayIndex = 0;
            deleteLine = false;
            int deletedLinesCount = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string trimmedLine = lines[i].Trim();

                if (trimmedLine.StartsWith("{"))
                {
                    if (deletedLinesCount > 0)
                    {
                        deletedLinesCount = 0;
                    }
                    deleteLine = false;
                }

                if (trimmedLine.Contains("\"Id\":"))
                {
                    int startIndex = trimmedLine.IndexOf("\"Id\":") + 5;
                    string idString = trimmedLine.Substring(startIndex).Trim().Replace(",", "").Replace("}", "").Replace("]", "").Trim();
                    int currentId = int.Parse(idString);
                    if (currentId == id)
                    {
                        deleteLine = true;
                        deletedLinesCount = 8;
                        if (newArrayIndex > 0 && keepJsonLines[newArrayIndex - 1].Trim().StartsWith("{"))
                        {
                            newArrayIndex--;
                        }
                    }
                }

                if (deleteLine)
                {
                    deletedLinesCount--;
                    if (deletedLinesCount <= 0)
                    {
                        deleteLine = false;
                    }
                }

                if (!deleteLine)
                {
                    if (newArrayIndex < linesToKeep)
                    {
                        keepJsonLines[newArrayIndex] = lines[i];
                        newArrayIndex++;
                    }
                }
            }

            if (newArrayIndex > 0)
            {
                int lastIndex = newArrayIndex - 1;
                string lastLine = keepJsonLines[lastIndex];

                if (lastLine.Trim().EndsWith("},"))
                {
                    keepJsonLines[lastIndex] = lastLine.TrimEnd().Replace(",", "");
                }
            }

            File.WriteAllLines(filePath, keepJsonLines);
            listBoxID.Items.Remove(id);
            MessageBox.Show("ID " + id.ToString() + " excluído com sucesso!");
        }

        private void buttonHtml_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\pacientes.json";
            string reportPath = @"C:\relatorio.html";

            int[] imcCounts = new int[6];
            string tableRows = "";
            string[] lines = File.ReadAllLines(filePath);

            int currentId = 0;
            string currentName = "";
            float currentWeight = 0;
            float currentHeight = 0;
            float currentImc = 0;
            string currentClassification = "";

            for (int i = 0; i < lines.Length; i++)
            {
                string trimmedLine = lines[i].Trim();

                if (trimmedLine.Contains("\"Id\":"))
                {
                    string value = trimmedLine.Replace("\"Id\":", "").Replace(",", "").Trim();
                    value = value.Replace("}", "").Replace("]", "").Trim();
                    if (float.TryParse(value, out float tempId))
                    {
                        currentId = (int)tempId;
                        currentName = ""; currentWeight = 0; currentHeight = 0; currentImc = 0; currentClassification = "";
                    }
                }
                else if (trimmedLine.Contains("\"Nome\":"))
                {
                    string value = trimmedLine.Replace("\"Nome\":", "").Replace(",", "").Trim();
                    currentName = value.Replace("\"", "").Trim();
                }
                else if (trimmedLine.Contains("\"Peso (Kg)\":"))
                {
                    string value = trimmedLine.Replace("\"Peso (Kg)\":", "").Replace(",", "").Trim();
                    if (float.TryParse(value.Replace(".", ","), out currentWeight)) { }
                }
                else if (trimmedLine.Contains("\"Altura (m)\":"))
                {
                    string value = trimmedLine.Replace("\"Altura (m)\":", "").Replace(",", "").Trim();
                    if (float.TryParse(value.Replace(".", ","), out currentHeight)) { }
                }
                else if (trimmedLine.Contains("\"IMC\":"))
                {
                    string value = trimmedLine.Replace("\"IMC\":", "").Replace(",", "").Trim();
                    if (float.TryParse(value.Replace(".", ","), out currentImc)) { }
                }
                else if (trimmedLine.Contains("\"Classificação\":"))
                {
                    int valueStart = trimmedLine.IndexOf(':');
                    if (valueStart != -1)
                    {
                        valueStart = trimmedLine.IndexOf('"', valueStart);
                    }
                    if (valueStart != -1)
                    {
                        int startIndex = valueStart + 1;
                        int valueEnd = trimmedLine.LastIndexOf('"');
                        int length = valueEnd - startIndex;
                        if (length > 0)
                        {
                            currentClassification = trimmedLine.Substring(startIndex, length).Trim();
                        }
                    }

                    if (currentId > 0 && currentImc > 0)
                    {
                        if (currentImc < 18.5f) imcCounts[0]++;
                        else if (currentImc <= 24.9f) imcCounts[1]++;
                        else if (currentImc <= 29.9f) imcCounts[2]++;
                        else if (currentImc <= 34.9f) imcCounts[3]++;
                        else if (currentImc <= 39.9f) imcCounts[4]++;
                        else imcCounts[5]++;

                        string formattedImc = currentImc.ToString("0.00").Replace(",", ".");
                        string formattedWeight = currentWeight.ToString("0.00").Replace(",", ".");
                        string formattedHeight = currentHeight.ToString("0.00").Replace(",", ".");

                        string row = "<tr><td>" +
                                     currentId.ToString() +
                                     "</td><td>" +
                                     currentName +
                                     "</td><td>" +
                                     formattedWeight +
                                     "</td><td>" +
                                     formattedHeight +
                                     "</td><td>" +
                                     formattedImc +
                                     "</td><td>" +
                                     currentClassification +
                                     "</td></tr>\n";

                        tableRows += row;
                        currentId = 0;
                    }
                }
            }

            string chartData = imcCounts[0].ToString() + ", " +
                              imcCounts[1].ToString() + ", " +
                              imcCounts[2].ToString() + ", " +
                              imcCounts[3].ToString() + ", " +
                              imcCounts[4].ToString() + ", " +
                              imcCounts[5].ToString();

            int maxCount = 0;
            for (int i = 0; i < imcCounts.Length; i++)
            {
                if (imcCounts[i] > maxCount)
                    maxCount = imcCounts[i];
            }
            int chartRangeMax = maxCount > 50 ? maxCount + 5 : 50;
            string chartRangeMaxString = chartRangeMax.ToString();

            string html =
            "<!DOCTYPE html>\n" +
            "<html lang=\"en\">\n" +
            "<head>\n" +
            "    <meta charset=\"UTF-8\">\n" +
            "    <title>Relatório de IMC</title>\n" +
            "    <script src='https://cdn.plot.ly/plotly-2.27.0.min.js'></script>\n" +
            "    <style>\n" +
            "        body { font-family: Arial, sans-serif; }\n" +
            "        table { width: 80%; margin: 20px auto; border-collapse: collapse; }\n" +
            "        th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }\n" +
            "        th { background-color: #f2f2f2; }\n" +
            "    </style>\n" +
            "</head>\n" +
            "<body>\n" +
            "    <center><h2>Análise de Classificação do Índice de Massa Corporal</h2></center>\n" +
            "    <center><div id='myDiv' style=\"width: 500px; height:500px;\">Gráfico de Classificação</div></center>\n" +
            "    \n" +
            "    <div id='data-table'>\n" +
            "        <center><h3>Dados de Registros</h3></center>\n" +
            "        <table>\n" +
            "            <thead>\n" +
            "                <tr>\n" +
            "                    <th>ID</th>\n" +
            "                    <th>Nome</th>\n" +
            "                    <th>Peso (Kg)</th>\n" +
            "                    <th>Altura (m)</th>\n" +
            "                    <th>IMC</th>\n" +
            "                    <th>Classificação</th>\n" +
            "                </tr>\n" +
            "            </thead>\n" +
            "            <tbody>\n" +
                                 tableRows +
            "            </tbody>\n" +
            "        </table>\n" +
            "    </div>\n" +
            "    \n" +
            "    <script>\n" +
            "        var data =\n" +
            "        [\n" +
            "            {\n" +
            "                type: 'scatterpolar',\n" +
            "                r: [" + chartData + "],\n" +
            "                theta: ['Magreza', 'Saudável', 'Sobrepeso', 'OBG-I', 'OBG-II', 'OBG-III'],\n" +
            "                fill: 'toself'\n" +
            "            }\n" +
            "        ];\n" +
            "        var layout = \n" +
            "        {\n" +
            "            polar: {\n" +
            "                radialaxis: {\n" +
            "                    visible: true,\n" +
            "                    range: [0, " + chartRangeMaxString + "]\n" +
            "                }\n" +
            "            },\n" +
            "            showlegend: false\n" +
            "        };\n" +
            "        Plotly.newPlot(\"myDiv\", data, layout);\n" +
            "    </script>\n" +
            "</body>\n" +
            "</html>";

            File.WriteAllText(reportPath, html);
            MessageBox.Show("O relatório foi gerado com sucesso!");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //exibe a mensagem "Nome: " em cima da textBoxNome
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //exibe a mensagem "Peso: " em cima da textBoxPeso
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //exibe a mensagem "Dados do paciente: " em cima da listbox de pacientes cadastrados
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //exibe a mensagem "Altura: " em cima da textbox de inserir a altura
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //exibe o título do projeto
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //exibe a mensagem "Lista de Pacientes: " em cima da listbox de pacientes
        }
    }
}