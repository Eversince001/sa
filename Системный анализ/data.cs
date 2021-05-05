using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Системный_анализ
{
    public class data
    {
        public List<List<string>> solutions = new List<List<string>>();
        public List<List<string>> experts = new List<List<string>>();
        public List<List<string>> Problems = new List<List<string>>();
        public List<string> Formulations = new List<string>();
        public List<List<bool>> ready = new List<List<bool>>();
        public List<List<List<List<string>>>> Research = new List<List<List<List<string>>>>();
        public List<List<List<string>>> ResearchA = new List<List<List<string>>>();

        public List<List<string>> solutionsA = new List<List<string>>();
        public List<string> ProblemsA = new List<string>();
        public List<string> FormulationsA = new List<string>();
        public double S = 1;

        public List<List<List<List<List<string>>>>> Matrix = new List<List<List<List<List<string>>>>>();
        public List<List<List<List<double>>>> MatrixX = new List<List<List<List<double>>>>();

        public List<List<string>> exp = new List<List<string>>();

        public void Load()
        {
            string path = Directory.GetCurrentDirectory();

            if (File.Exists(path + @"\matrix.json"))
            {
                string jsonMatrix = File.ReadAllText(path + @"\matrix.json");
                if (jsonMatrix.Length != 0)
                    Matrix = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<List<List<List<string>>>>>>(jsonMatrix);
            }

            if (File.Exists(path + @"\matrixX.json"))
            {
                string jsonMatrixX = File.ReadAllText(path + @"\matrixX.json");
                if (jsonMatrixX.Length != 0)
                    MatrixX = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<List<List<double>>>>>(jsonMatrixX);
            }

            if (File.Exists(path + @"\EXP.json"))
            {
                string jsonEXP = File.ReadAllText(path + @"\EXP.json");
                if (jsonEXP.Length != 0)
                    exp = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<string>>>(jsonEXP);
            }

            if (File.Exists(path + @"\problems.json"))
            {
                string jsonProblems = File.ReadAllText(path + @"\problems.json");
                if (jsonProblems.Length != 0)
                    Problems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<string>>>(jsonProblems);
            }

            if (File.Exists(path + @"\solutions.json"))
            {
                string jsonSolutions = File.ReadAllText(path + @"\solutions.json");
                if (jsonSolutions.Length != 0)
                    solutions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<string>>>(jsonSolutions);
            }

            if (File.Exists(path + @"\experts.json"))
            {
                string jsonExperts = File.ReadAllText(path + @"\experts.json");
                if (jsonExperts.Length != 0)
                    experts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<string>>>(jsonExperts);
            }

            if (File.Exists(path + @"\formulations.json"))
            {
                string jsonFormulations = File.ReadAllText(path + @"\formulations.json");
                if (jsonFormulations.Length != 0)
                    Formulations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(jsonFormulations);
            }

            if (File.Exists(path + @"\results.json"))
            {
                string jsonResults = File.ReadAllText(path + @"\results.json");
                if (jsonResults.Length != 0)
                    Research = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<List<List<string>>>>>(jsonResults);
            }

            if (File.Exists(path + @"\ready.json"))
            {
                string jsonReady = File.ReadAllText(path + @"\ready.json");
                if (jsonReady.Length != 0)
                    ready = Newtonsoft.Json.JsonConvert.DeserializeObject<List<List<bool>>>(jsonReady);
            }

            string tmp = "1";
            if (File.Exists(path + @"\S.txt"))
            {
                tmp = File.ReadAllText(path + @"\S.txt");
                S = Convert.ToDouble(tmp);
            }

        }

        public void Save()
        {
            string path = Directory.GetCurrentDirectory();
            string jsonMatrix = Newtonsoft.Json.JsonConvert.SerializeObject(Matrix, Formatting.Indented);
            string jsonMatrixX = Newtonsoft.Json.JsonConvert.SerializeObject(MatrixX, Formatting.Indented);
            string jsonProblems = Newtonsoft.Json.JsonConvert.SerializeObject(Problems, Formatting.Indented);
            string jsonSolutions = Newtonsoft.Json.JsonConvert.SerializeObject(solutions, Formatting.Indented);
            string jsonExperts = Newtonsoft.Json.JsonConvert.SerializeObject(experts, Formatting.Indented);
            string jsonFormulations = Newtonsoft.Json.JsonConvert.SerializeObject(Formulations, Formatting.Indented);
            string jsonReady = Newtonsoft.Json.JsonConvert.SerializeObject(ready, Formatting.Indented);
            string jsonResults = Newtonsoft.Json.JsonConvert.SerializeObject(Research, Formatting.Indented);
            string jsonEXP = Newtonsoft.Json.JsonConvert.SerializeObject(exp, Formatting.Indented);

            File.WriteAllText(path + @"\matrix.json", jsonMatrix);

            File.WriteAllText(path + @"\matrixX.json", jsonMatrixX);

            File.WriteAllText(path + @"\EXP.json", jsonEXP);

            File.WriteAllText(path + @"\problems.json", jsonProblems);

            File.WriteAllText(path + @"\solutions.json", jsonSolutions);

            File.WriteAllText(path + @"\experts.json", jsonExperts);

            File.WriteAllText(path + @"\formulations.json", jsonFormulations);

            File.WriteAllText(path + @"\results.json", jsonResults);

            File.WriteAllText(path + @"\ready.json", jsonReady);

            File.WriteAllText(path + @"\S.txt", S.ToString());

            
        }


    }
}

