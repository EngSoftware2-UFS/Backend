using Biblioteca.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.Entities;

public partial class Emprestimo
{
    public ulong Id { get; set; }

    public DateTime DataEmprestimo { get; set; }

    public DateTime? DataDevolucao { get; set; }

    public DateTime PrazoDevolucao { get; set; }

    public int QuantidadeRenovacao { get; set; }

    public string Status { get; set; } = null!;

    public bool Inadimplencia { get; set; }

    public ulong AtendenteId { get; set; }

    public ulong ClienteId { get; set; }

    public virtual Atendente Atendente { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public void CriarEmprestimo(ulong atendenteId, ulong clienteId)
    {
        DataEmprestimo = DateTime.Now;
        PrazoDevolucao = DateTime.Now.AddDays(7);
        QuantidadeRenovacao = 2;
        AtendenteId = atendenteId;
        ClienteId = clienteId;
        Status = EStatusEmprestimo.ATIVO.ToString();
        DataDevolucao = null;
    }

    public void RenovarEmprestimo()
    {
        if (QuantidadeRenovacao > 0 && !Inadimplencia)
        {
            QuantidadeRenovacao -= 1;
            PrazoDevolucao = DateTime.Now.AddDays(7);
        }
        else throw new OperationCanceledException("Não é possível renovar este empréstimo.");
    }

    public void CancelarEmprestimo()
    {
        Status = EStatusEmprestimo.CANCELADO.ToString();
    }

    public void PagarMultaEDevolver()
    {
        Inadimplencia = false;
        Status = EStatusEmprestimo.DEVOLVIDO.ToString();
        DataDevolucao = DateTime.Now;
    }

    public void Devolver()
    {
        Status = EStatusEmprestimo.DEVOLVIDO.ToString();
        DataDevolucao = DateTime.Now;
    }

    public double calcularMulta()
    {
        const double valorMultaPorDia = 1.00;
        if (verificaInadimplencia())
        {
            var diasUltrapassados = (DateTime.Today - PrazoDevolucao.Date).TotalDays;
            double multa = diasUltrapassados * valorMultaPorDia;
            return multa;
        }

        return 0;
    }

    public bool verificaInadimplencia()
    {
        if (Status != EStatusEmprestimo.ATIVO.ToString()
            && Status != EStatusEmprestimo.ATRASADO.ToString())
            return false;

        if (Inadimplencia) 
            return true;

        if (PrazoDevolucao < DateTime.Now)
        {
            if (!Inadimplencia) Inadimplencia = true;
            return true;
        }

        return false;
    }
}
