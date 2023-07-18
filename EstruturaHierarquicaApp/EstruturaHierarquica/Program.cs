using System;
using System.Collections.Generic;

class Program
{
    private static int  arrauCount = 0;
    static Dictionary<string, List<string>> Hierarquia(List<string[]> pares)
    {
        Dictionary<string, List<string>> arvore = new Dictionary<string, List<string>>();
        HashSet<string> nos = new HashSet<string>();

        foreach (var par in pares)
        {
            string pai = par[0];
            string filho = par[1];

            ValidarHierarquia(arvore, pai, filho);

            arvore[pai].Add(filho);
            nos.Add(pai);
            nos.Add(filho);
        }

        if (!nos.Any())
        {
            throw new Exception("E4");
        }

        return arvore;
    }

    private static void ValidarHierarquia(Dictionary<string, List<string>> arvore, string pai, string filho)
    {
        if (!arvore.ContainsKey(pai))
        {
            arvore[pai] = new List<string>();
        }

        //Verificar se a mais de 2 filhos
        if (arvore[pai].Count >= 2)
        {
            throw new Exception("E1");
        }

        if (ExisteCicloPresente(arvore, pai, filho))
        {
            throw new Exception("E2");
        }

        if (ExisteRaizMultiplas(arvore, filho))
        {
            throw new Exception("E3");
        }
    }

    static bool ExisteCicloPresente(Dictionary<string, List<string>> arvore, string pai, string filho)
    {
        if (!arvore.ContainsKey(filho))
        {
            return false;
        }

        foreach (var neto in arvore[filho])
        {
            if (neto == pai || ExisteCicloPresente(arvore, pai, neto))
            {
                return true;
            }
        }

        return false;
    }

    static bool ExisteRaizMultiplas(Dictionary<string, List<string>> arvore, string filho)
    {
        foreach (var listaFilhos in arvore.Values)
        {
            if (listaFilhos.Contains(filho))
            {
                return true;
            }
        }

        return false;
    }

    static void Main()
    {
        var arraysEntrada = new List<List<string[]>>
        {
            new List<string[]>
            {
                new string[] { "A", "B" },
                new string[] { "A", "C" },
                new string[] { "B", "G" },
                new string[] { "C", "H" },
                new string[] { "E", "F" },
                new string[] { "B", "D" },
                new string[] { "C", "E" }
            },
                new List<string[]>
            {
                new string[] { "D", "E" },
                new string[] { "A", "B" },
                new string[] { "C", "F" },
                new string[] { "E", "G" },
                new string[] { "A", "C" }
            },
                new List<string[]>
            {
                new string[] { "A", "B" },
                new string[] { "A", "C" },
                new string[] { "B", "D" },
                new string[] { "D", "C" }
            }
        };
       
        try
        {
           
            foreach (var array in arraysEntrada)
            {
                arrauCount++;
                Dictionary<string, List<string>> results = Hierarquia(array);
                
                Console.WriteLine($"Array - {arrauCount}");
                Console.WriteLine();
                foreach (var result in results)
                {
                    Console.Write($"{result.Key}: ");
                    Console.WriteLine(string.Join(", ", result.Value));                 
                }
                Console.WriteLine();
            }
           
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Array - {arrauCount}");
            Console.WriteLine(ex.Message);
        }
    }
}
