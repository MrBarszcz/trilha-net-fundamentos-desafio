using System.Data.Common;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora) {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo() {
            Console.WriteLine("\n");

            // Pedir para o usuário digitar a placa e armazenar na variável placa com padrão de letras maiúsculas
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            placa = placa.ToUpper();

            // Verifica se a placa já está estacionada
            if (veiculos.Contains(placa)) {
                Console.WriteLine("\n");

                Console.WriteLine($"Veículo com a placa {placa}, já estacionado");
                return;

            } else {
                /* 
                    Verificando se a placa é do padrão mercosul atual (AAA1A11 - 7 digitos) ou antigo (AAA-1111 - 8 digitos).
                    Se for do padrão atual, verificar se os 3 primeiros caracteres são letras, o 4º é um número, o 5º é uma letra e os dois últimos são números.
                    Se for do padrão antigo, verificar se os 3 primeiros caracteres são letras, o 4º é um traço, o 5º e 6º são números e o 7º e 8º são números.
                    Se a placa for de um dos padrões, adicionar na lista de veículos.
                    Se a placa não for de nenhum dos padrões, exibir "Placa inválida".
                */ 
                if (placa.Length == 7) {
                    if (char.IsLetter(placa[0]) && char.IsLetter(placa[1]) && char.IsLetter(placa[2]) && char.IsDigit(placa[3]) && char.IsLetter(placa[4]) && char.IsDigit(placa[5]) && char.IsDigit(placa[6])) {
                        veiculos.Add(placa);

                        Console.WriteLine("\n");

                        Console.WriteLine("Placa Cadatrada com sucesso");

                    } else {
                        Console.WriteLine("\n");

                        Console.WriteLine("Placa inválida");
                    }

                } else if (placa.Length == 8) {
                    if (char.IsLetter(placa[0]) && char.IsLetter(placa[1]) && char.IsLetter(placa[2]) && placa[3] == '-' && char.IsDigit(placa[4]) && char.IsDigit(placa[5]) && char.IsDigit(placa[6]) && char.IsDigit(placa[7]))  {
                        veiculos.Add(placa);

                        Console.WriteLine("\n");

                        Console.WriteLine("Placa Cadatrada com sucesso");

                    } else {
                        Console.WriteLine("\n");

                        Console.WriteLine("Placa inválida");
                    }

                } else {
                    Console.WriteLine("\n");

                    Console.WriteLine("Placa inválida");
                }
            }
        }

        public void RemoverVeiculo() {
            Console.WriteLine("\n");

            // Pedir para o usuário digitar a placa e armazenar na variável placa com padrão de letras maiúsculas
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            placa = placa.ToUpper();

            /*
                Verifica se o placa está cadastrada.
                O método Any() verifica se pelo menos um elemento da lista atende a uma determinada condição e retorna true ou false.
                "x => x == placa" é uma expressão lambda que verifica se o elemento é igual a placa digitada.
                Uma função lambda é uma função anônima (sem nome) que pode ter nenhum ou vários parâmetros e uma expressão.
                "x" é o parâmetro que representa cada elemento da lista.
                "=>" é o operador lambda que separa o parâmetro da expressão.
                "x == placa" é a condição.
            */
            if (veiculos.Any(x => x == placa)) {
                Console.WriteLine("\n");

                // Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado e armazenar na variável horas
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());

                // Calcular o valor total a ser pago
                decimal valorTotal = precoInicial + (precoPorHora * horas); 

                // Remover o veículo da lista
                veiculos.Remove(placa);
                
                Console.WriteLine("\n");

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            } else {
                Console.WriteLine("\n");

                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos() {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any()) {
                Console.WriteLine("\n");
                Console.WriteLine("Os veículos estacionados são:");
                
                // Percorre a lista de veículos e exibir cada um
                foreach (string veiculo in veiculos) {
                    Console.WriteLine(veiculo);
                }
            } else {
                Console.WriteLine("\n");

                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
