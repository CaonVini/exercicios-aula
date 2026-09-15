using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("\nExercicio 1");
        Animal cachorro = new Cachorro("Rex");
        Animal gato = new Gato("Mimi");
        cachorro.EmitirSom();
        gato.EmitirSom();

        Console.WriteLine("\nExercicio 2");
        Veiculo carro = new Carro();
        Veiculo moto = new Moto();
        Veiculo caminhao = new Caminhao();
        carro.Abastecer();
        carro.Mover();
        moto.Mover();
        caminhao.Mover();

        Console.WriteLine("\nExercicio 3");
        new PagamentoPix().Pagar(100);
        new PagamentoCartao().Pagar(200);
        new PagamentoBoleto().Pagar(300);

        Console.WriteLine("\nExercicio 4");
        Funcionario gerente = new Gerente("Ana", 5000);
        Funcionario desenvolvedor = new Desenvolvedor("Carlos", 3500);
        Console.WriteLine($"Salario do gerente: R$ {gerente.CalcularSalario():F2}");
        Console.WriteLine($"Salario do desenvolvedor: R$ {desenvolvedor.CalcularSalario():F2}");

        Console.WriteLine("\nExercicio 5");
        IAutenticacao admin = new LoginAdmin();
        IAutenticacao cliente = new LoginCliente();
        Console.WriteLine($"Login admin: {admin.Login("admin", "1234")}");
        Console.WriteLine($"Login cliente: {cliente.Login("cliente", "abcd")}");

        Console.WriteLine("\nExercicio 6");
        new Passaro().Voar();
        new Peixe().Nadar();
        Pato pato = new Pato();
        pato.Voar();
        pato.Nadar();

        Console.WriteLine("\nExercicio 7");
        ContaBancaria corrente = new ContaCorrente(500);
        ContaBancaria poupanca = new ContaPoupanca(500);
        corrente.Depositar(100);
        poupanca.Depositar(100);
        corrente.Sacar(50);
        poupanca.Sacar(50);
        Console.WriteLine($"Saldo da conta corrente: R$ {corrente.Saldo:F2}");
        Console.WriteLine($"Saldo da conta poupanca: R$ {poupanca.Saldo:F2}");

        Console.WriteLine("\nExercicio 8");
        List<INotificacao> notificacoes = new List<INotificacao>
        {
            new Email(),
            new SMS(),
            new WhatsApp()
        };
        
        foreach (INotificacao notificacao in notificacoes)
            notificacao.Enviar("Aula 7 concluida.");

        Console.WriteLine("\nExercicio 9");
        List<IForma> formas = new List<IForma>
        {
            new Quadrado(4),
            new Retangulo(5, 3),
            new Circulo(2)
        };
        
        foreach (IForma forma in formas)
            Console.WriteLine($"Area: {forma.CalcularArea():F2}");

        Console.WriteLine("\nExercicio 10");
        Aviao aviao = new Aviao("Aviao 01");
        Navio navio = new Navio("Navio 01");
        CarroTransporte carroTransporte = new CarroTransporte("Carro 01");
        
        aviao.ExibirNome();
        aviao.DefinirDestino("Sao Paulo");
        aviao.Decolar();
        aviao.Mover();
        aviao.FazerManutencao();
        
        navio.ExibirNome();
        navio.DefinirDestino("Rio de Janeiro");
        navio.Mover();
        navio.Ancorar();
        navio.FazerManutencao();
        
        carroTransporte.ExibirNome();
        carroTransporte.DefinirDestino("Florianopolis");
        carroTransporte.Mover();
        carroTransporte.Estacionar();
        carroTransporte.FazerManutencao();

        Console.WriteLine("\nDesafio extra");
        List<Pessoa> pessoas = new List<Pessoa>
        {
            new Aluno("Marcos", 8.5),
            new Professor("Eduardo", "Programacao Orientada a Objetos")
        };
        
        foreach (Pessoa pessoa in pessoas)
        {
            pessoa.Apresentar();
        
            if (pessoa is IAvaliavel avaliavel)
                avaliavel.ExibirAvaliacao();
        }
    }
}

abstract class Animal
{
    public string Nome { get; set; }

    public Animal(string nome)
    {
        Nome = nome;
    }

    public abstract void EmitirSom();
}

class Cachorro : Animal
{
    public Cachorro(string nome) : base(nome) { }

    public override void EmitirSom()
    {
        Console.WriteLine($"{Nome}: Au au!");
    }
}

class Gato : Animal
{
    public Gato(string nome) : base(nome) { }

    public override void EmitirSom()
    {
        Console.WriteLine($"{Nome}: Miau!");
    }
}

abstract class Veiculo
{
    public abstract void Mover();

    public void Abastecer()
    {
        Console.WriteLine("Veiculo abastecido.");
    }
}

class Carro : Veiculo
{
    public override void Mover()
    {
        Console.WriteLine("O carro esta andando na estrada.");
    }
}

class Moto : Veiculo
{
    public override void Mover()
    {
        Console.WriteLine("A moto esta andando entre os veiculos.");
    }
}

class Caminhao : Veiculo
{
    public override void Mover()
    {
        Console.WriteLine("O caminhao esta transportando carga.");
    }
}

interface IPagamento
{
    void Pagar(double valor);
}

class PagamentoPix : IPagamento
{
    public void Pagar(double valor)
    {
        Console.WriteLine($"Pagamento de R$ {valor:F2} realizado via Pix.");
    }
}

class PagamentoCartao : IPagamento
{
    public void Pagar(double valor)
    {
        Console.WriteLine($"Pagamento de R$ {valor:F2} realizado no cartao.");
    }
}

class PagamentoBoleto : IPagamento
{
    public void Pagar(double valor)
    {
        Console.WriteLine($"Boleto de R$ {valor:F2} gerado para pagamento.");
    }
}

abstract class Funcionario
{
    public string Nome { get; set; }
    public double SalarioBase { get; set; }

    public Funcionario(string nome, double salarioBase)
    {
        Nome = nome;
        SalarioBase = salarioBase;
    }

    public abstract double CalcularSalario();
}

interface IBonificacao
{
    double CalcularBonus();
}

class Gerente : Funcionario, IBonificacao
{
    public Gerente(string nome, double salarioBase) : base(nome, salarioBase) { }

    public double CalcularBonus()
    {
        return SalarioBase * 0.20;
    }

    public override double CalcularSalario()
    {
        return SalarioBase + CalcularBonus();
    }
}

class Desenvolvedor : Funcionario, IBonificacao
{
    public Desenvolvedor(string nome, double salarioBase) : base(nome, salarioBase) { }

    public double CalcularBonus()
    {
        return SalarioBase * 0.10;
    }

    public override double CalcularSalario()
    {
        return SalarioBase + CalcularBonus();
    }
}

interface IAutenticacao
{
    bool Login(string usuario, string senha);
}

class LoginAdmin : IAutenticacao
{
    public bool Login(string usuario, string senha)
    {
        return usuario == "admin" && senha == "1234";
    }
}

class LoginCliente : IAutenticacao
{
    public bool Login(string usuario, string senha)
    {
        return usuario == "cliente" && senha == "abcd";
    }
}

interface IAnimal
{
    void Voar();
    void Nadar();
}

interface IVoador
{
    void Voar();
}

interface INadador
{
    void Nadar();
}

class Passaro : IVoador
{
    public void Voar()
    {
        Console.WriteLine("O passaro esta voando.");
    }
}

class Peixe : INadador
{
    public void Nadar()
    {
        Console.WriteLine("O peixe esta nadando.");
    }
}

class Pato : IVoador, INadador
{
    public void Voar()
    {
        Console.WriteLine("O pato esta voando.");
    }

    public void Nadar()
    {
        Console.WriteLine("O pato esta nadando.");
    }
}

abstract class ContaBancaria
{
    public double Saldo { get; protected set; }

    public ContaBancaria(double saldoInicial)
    {
        Saldo = saldoInicial;
    }

    public void Depositar(double valor)
    {
        if (valor > 0)
            Saldo += valor;
    }

    public abstract void Sacar(double valor);
}

class ContaCorrente : ContaBancaria
{
    public ContaCorrente(double saldoInicial) : base(saldoInicial) { }

    public override void Sacar(double valor)
    {
        double valorComTaxa = valor + 5;
        if (valorComTaxa <= Saldo)
            Saldo -= valorComTaxa;
    }
}

class ContaPoupanca : ContaBancaria
{
    public ContaPoupanca(double saldoInicial) : base(saldoInicial) { }

    public override void Sacar(double valor)
    {
        if (valor <= Saldo)
            Saldo -= valor;
    }
}

interface INotificacao
{
    void Enviar(string mensagem);
}

class Email : INotificacao
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine($"E-mail enviado: {mensagem}");
    }
}

class SMS : INotificacao
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine($"SMS enviado: {mensagem}");
    }
}

class WhatsApp : INotificacao
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine($"WhatsApp enviado: {mensagem}");
    }
}

interface IForma
{
    double CalcularArea();
}

class Quadrado : IForma
{
    public double Lado { get; set; }

    public Quadrado(double lado)
    {
        Lado = lado;
    }

    public double CalcularArea()
    {
        return Lado * Lado;
    }
}

class Retangulo : IForma
{
    public double Base { get; set; }
    public double Altura { get; set; }

    public Retangulo(double baseRetangulo, double altura)
    {
        Base = baseRetangulo;
        Altura = altura;
    }

    public double CalcularArea()
    {
        return Base * Altura;
    }
}

class Circulo : IForma
{
    public double Raio { get; set; }

    public Circulo(double raio)
    {
        Raio = raio;
    }

    public double CalcularArea()
    {
        return Math.PI * Raio * Raio;
    }
}

abstract class Transporte
{
    public string Nome { get; set; }

    public Transporte(string nome)
    {
        Nome = nome;
    }

    public abstract void Mover();

    public void ExibirNome()
    {
        Console.WriteLine($"Transporte: {Nome}");
    }
}

interface IManutencao
{
    void FazerManutencao();
}

interface INavegacao
{
    void DefinirDestino(string destino);
}

class Aviao : Transporte, IManutencao, INavegacao
{
    public Aviao(string nome) : base(nome) { }

    public override void Mover()
    {
        Console.WriteLine("O aviao esta voando.");
    }

    public void FazerManutencao()
    {
        Console.WriteLine("Manutencao dos motores do aviao.");
    }

    public void DefinirDestino(string destino)
    {
        Console.WriteLine($"Rota aerea definida para {destino}.");
    }

    public void Decolar()
    {
        Console.WriteLine("O aviao decolou.");
    }
}

class Navio : Transporte, IManutencao, INavegacao
{
    public Navio(string nome) : base(nome) { }

    public override void Mover()
    {
        Console.WriteLine("O navio esta navegando.");
    }

    public void FazerManutencao()
    {
        Console.WriteLine("Manutencao do casco do navio.");
    }

    public void DefinirDestino(string destino)
    {
        Console.WriteLine($"Rota maritima definida para {destino}.");
    }

    public void Ancorar()
    {
        Console.WriteLine("O navio foi ancorado.");
    }
}

class CarroTransporte : Transporte, IManutencao, INavegacao
{
    public CarroTransporte(string nome) : base(nome) { }

    public override void Mover()
    {
        Console.WriteLine("O carro esta andando na rodovia.");
    }

    public void FazerManutencao()
    {
        Console.WriteLine("Troca de oleo do carro.");
    }

    public void DefinirDestino(string destino)
    {
        Console.WriteLine($"GPS configurado para {destino}.");
    }

    public void Estacionar()
    {
        Console.WriteLine("O carro foi estacionado.");
    }
}

abstract class Pessoa
{
    public string Nome { get; set; }

    public Pessoa(string nome)
    {
        Nome = nome;
    }

    public abstract void Apresentar();
}

interface IAvaliavel
{
    void ExibirAvaliacao();
}

class Aluno : Pessoa, IAvaliavel
{
    public double Nota { get; set; }

    public Aluno(string nome, double nota) : base(nome)
    {
        Nota = nota;
    }

    public override void Apresentar()
    {
        Console.WriteLine($"Aluno: {Nome}");
    }

    public void ExibirAvaliacao()
    {
        Console.WriteLine($"Nota: {Nota:F1}");
    }
}

class Professor : Pessoa
{
    public string Disciplina { get; set; }

    public Professor(string nome, string disciplina) : base(nome)
    {
        Disciplina = disciplina;
    }

    public override void Apresentar()
    {
        Console.WriteLine($"Professor: {Nome} - Disciplina: {Disciplina}");
    }
}
