using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace EquationSolver
{
    public abstract class Solution
    {
        public abstract string CalculateRoots();
        public abstract string PrintRoots();
    }

    public class Linear : Solution
    {
        private double a, b;

        public Linear(double a_val, double b_val)
        {
            a = a_val;
            b = b_val;
        }

        public override string CalculateRoots()
        {
            if (a == 0)
            {
                
                return "Not a linear equation";
            }
            double root = -b / a;
            return root.ToString();
        }

        public override string PrintRoots()
        {
            return "Linear Equation: " + a + "x + " + b + " = 0";
        }
    }

    public class Square : Solution
    {
        private double a, b, c;

        public Square(double a_val, double b_val, double c_val)
        {
            a = a_val;
            b = b_val;
            c = c_val;
        }

        public override string CalculateRoots()
        {
            double discriminant = b * b - 4 * a * c;
            if (discriminant > 0)
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
               
                return "Roots: " + root1 + ", " + root2;
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
               
                return "Root: " + root;
            }
            else
            {
               
                return "No real roots";
            }
        }

        public override string PrintRoots()
        {
            return "Quadratic Equation: " + a + "x^2 + " + b + "x + " + c + " = 0";
        }
    }

    public class Series
    {
        private List<Solution> solutions;

        public Series()
        {
            solutions = new List<Solution>();
        }

        public void AddSolution(Solution sol)
        {
            solutions.Add(sol);
        }

        public void PrintCharacteristics()
        {
            foreach (Solution sol in solutions)
            {
                sol.PrintRoots();
                sol.CalculateRoots();
            }
        }

        public void SortSolutions()
        {
            solutions.Sort((sol1, sol2) => sol1.ToString().CompareTo(sol2.ToString()));
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Solution sol in solutions)
                {
                    writer.WriteLine(sol.PrintRoots());
                    writer.WriteLine(sol.CalculateRoots());
                    writer.WriteLine();
                }
            }
            MessageBox.Show("Data saved to " + filename);
        }

        public void LoadFromFile(string filename)
        {
            // Implement loading from file
        }
    }
}
