using store.factory;
using store.product.dao;
using store.product.model;


namespace store
{
    class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                Product product;
                ProductDAO objDAO = new ProductDAO();
                string nome, fabricante, categoria;
                float preco;
                int quantidade, id, opcao;


                Console.WriteLine("Sistema programado para INSERIR, REMOVER, ALTERAR, e BUSCAR produtos.");
                Console.Write("Com base na explicação acima. Digite o caso desejado: ");
                string caso = Console.ReadLine().ToUpper();
                Console.WriteLine();

                switch (caso)
                {
                    case "INSERIR":
                        Console.WriteLine("Abaixo digite os dados do produto.");
                        Console.Write("Digite o id (identificador): ");
                        id = int.Parse(Console.ReadLine());
                        Console.Write("Digite o nome: ");
                        nome = Console.ReadLine();
                        Console.Write("Digite o fabricante: ");
                        fabricante = Console.ReadLine();
                        Console.Write("Digite a categoria: ");
                        categoria = Console.ReadLine();
                        Console.Write("Digite o preço: ");
                        preco = float.Parse(Console.ReadLine());
                        Console.Write("Digite a quantidade para estoque: ");
                        quantidade = int.Parse(Console.ReadLine());

                        product = new Product(id, nome, fabricante, categoria, preco, quantidade);
                        objDAO.insertProduct(product);
                        Console.WriteLine();
                        break;

                    case "REMOVER":
                        Console.Write("Digite o identificador do produto a ser removido: ");
                        id = int.Parse(Console.ReadLine());

                        objDAO.removeProduct(id);
                        Console.WriteLine();
                        break;

                    case "ALTERAR":
                        Console.Write("Digite o id do produto que será alterado: ");
                        id = int.Parse(Console.ReadLine());
                        Console.Write("Digite o nome: ");
                        nome = Console.ReadLine();
                        Console.Write("Digite o fabricante: ");
                        fabricante = Console.ReadLine();
                        Console.Write("Digite a categoria: ");
                        categoria = Console.ReadLine();
                        Console.Write("Digite o preço: ");
                        preco = float.Parse(Console.ReadLine());
                        Console.Write("Digite a quantidade para estoque: ");
                        quantidade = int.Parse(Console.ReadLine());

                        product = new Product(id, nome, fabricante, categoria, preco, quantidade);
                        objDAO.changeProduct(id, product);
                        Console.WriteLine();
                        break;

                    case "BUSCAR":
                        Console.Write("Digite 1 para buscar um único produto ou 2 para listar todos os produtos: ");
                        opcao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        if (opcao == 2)
                        {
                            objDAO.searchProduct();
                        }
                        else if (opcao == 1)
                        {
                            Console.Write("Digite o id do produto que será alterado: ");
                            id = int.Parse(Console.ReadLine());
                            product = objDAO.searchProductId(id);

                            objDAO.getProductMessage(product);
                        }
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Digite uma informação válida conforme sugerido acima.");
                        break;
                }
            }
            catch(Exception error)
            {
                Console.WriteLine("Error: " + error.Message);
            }

        }
    }
}

