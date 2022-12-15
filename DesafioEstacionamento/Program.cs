using DesafioFundamentos.Models;
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal tarifaHora = 0, tarifaInicial = 0;
// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento menu = new Estacionamento(tarifaHora, tarifaInicial);

while (tarifaInicial <= 0)
{
    Console.WriteLine("Digite o valor da taxa de cadastro:");
    tarifaInicial = Convert.ToDecimal(Console.ReadLine());
    menu.ValidarTarifa(tarifaInicial);
}

Console.WriteLine("Agora digite o preço por hora:");
while (tarifaHora <= 0)
{
    Console.WriteLine("Digite a taxa paga por hora:");
    tarifaHora = Convert.ToDecimal(Console.ReadLine());
    menu.ValidarTarifa(tarifaHora);
}

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
   Console.Clear();
   Console.WriteLine("Digite a sua opção:");
   Console.WriteLine("1 - Cadastrar veículo");
   Console.WriteLine("2 - Remover veículo");
   Console.WriteLine("3 - Listar veículos");
   Console.WriteLine("4 - Encerrar");

   switch (Console.ReadLine())
   {
       case "1":
           menu.AdicionarVeiculo();
           break;

       case "2":
           menu.RemoverVeiculo();
           break;

       case "3":
           menu.ListarVeiculos();
           break;

       case "4":
           exibirMenu = false;
           break;

       default:
           Console.WriteLine("Opção inválida");
           break;
   }

   Console.WriteLine("Pressione uma tecla para continuar");
   Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
