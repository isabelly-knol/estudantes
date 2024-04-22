using System;
using System.Collections.Generic;

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public int CalcularIdade()
    {
        DateTime hoje = DateTime.Today;
        int idade = hoje.Year - DataNascimento.Year;
        if (DataNascimento.Date > hoje.AddYears(-idade))
            idade--;
        return idade;
    }
}

public class Estudante : Pessoa
{
    public string Matricula { get; set; }
    public string Curso { get; set; }
    public List<double> Notas { get; set; }

    public double CalcularMedia()
    {
        if (Notas == null || Notas.Count == 0)
        {
            return 0;
        }
        double soma = 0;
        foreach (var nota in Notas)
        {
            soma += nota;
        }
        return soma / Notas.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Estudante estudante = new Estudante();
        estudante.Nome = "João";
        estudante.DataNascimento = new DateTime(2000, 5, 15);
        estudante.Matricula = "2024001";
        estudante.Curso = "Engenharia";
        estudante.Notas = new List<double> { 8.5, 7.2, 6.9 };

        Console.WriteLine("Informações do Estudante:");
        Console.WriteLine($"Nome: {estudante.Nome}");
        Console.WriteLine($"Idade: {estudante.CalcularIdade()} anos");
        Console.WriteLine($"Matrícula: {estudante.Matricula}");
        Console.WriteLine($"Curso: {estudante.Curso}");
        Console.WriteLine($"Notas: {string.Join(", ", estudante.Notas)}");
        Console.WriteLine($"Média: {estudante.CalcularMedia()}");

        Console.ReadLine();
    }
}