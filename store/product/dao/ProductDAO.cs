using store.factory;
using store.product.model;
using MySql.Data.MySqlClient;
using store.exceptions;


namespace store.product.dao
{
    public class ProductDAO
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;


        public void insertProduct(Product product)  // método de INSERIR produtos
        {
            try
            {
                conn = ConnectionFactory.getConnection();
                string sql = "insert into produtos (id, nome, fabricante, categoria, preco, quantidade) " +
                    "values (?, ?, ?, ?, ?, ?)";

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", product.getId());
                cmd.Parameters.AddWithValue("nome", product.getName());
                cmd.Parameters.AddWithValue("fabricante", product.getManufacturer());
                cmd.Parameters.AddWithValue("categoria", product.getCategory());
                cmd.Parameters.AddWithValue("preco", product.getPrice());
                cmd.Parameters.AddWithValue("quantidade", product.getAmount());

                cmd.ExecuteNonQuery();

                Console.WriteLine();
                Console.WriteLine(this.getMessage("INSERTED"));
            }
            catch(MySqlException error)
            {
                throw new ProductException(error.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        public void removeProduct(int id)  // método de REMOVER produto (recebe somente o id)
        {
            try
            {
                Console.WriteLine("The following product has been removed:");
                Product product = searchProductId(id);
                getProductMessage(product);

                conn = ConnectionFactory.getConnection();
                string sql = "delete from produtos where id = ?";

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();

                Console.WriteLine();
                Console.WriteLine(this.getMessage("ERRO"));
            }
            catch (MySqlException error)
            {
                throw new ProductException(error.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        public void changeProduct(int id, Product product)  // método de ALTERAR produto (recebe o id dos dados que serão alterados e os novos dados)
        {
            try
            {
                conn = ConnectionFactory.getConnection();
                string sql = "update produtos set nome = ?, fabricante = ?, categoria = ?, preco = ?, quantidade = ? where id = ?";

                cmd = new MySqlCommand(sql, conn);
                
                cmd.Parameters.AddWithValue("nome", product.getName());
                cmd.Parameters.AddWithValue("fabricante", product.getManufacturer());
                cmd.Parameters.AddWithValue("categoria", product.getCategory());
                cmd.Parameters.AddWithValue("preco", product.getPrice());
                cmd.Parameters.AddWithValue("quantidade", product.getAmount());
                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();

                Product productDb = searchProductId(id);

                Console.WriteLine();
                Console.WriteLine(this.getMessage("CHANGED"));
            }
            catch (MySqlException error)
            {
                throw new ProductException(error.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        public void searchProduct()  // método de LISTAR produtos (imprime TODOS os produtos do banco de dados)
        {
            Product product = new Product();
            try
            {
                conn = ConnectionFactory.getConnection();
                string sql = "select * from produtos";

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    product.setId(reader.GetInt16(0));
                    product.setName(reader.GetString(1));
                    product.setManufacturer(reader.GetString(2));
                    product.setCategory(reader.GetString(3));
                    product.setPrice(reader.GetFloat(4));
                    product.setAmount(reader.GetInt32(5));

                    getProductMessage(product);
                    Console.WriteLine();
                }
            }
            catch (MySqlException error)
            {
                throw new ProductException(error.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        
        public Product searchProductId(int id)  // método de BUSCA de produto pelo id (retorna somente 1 produto)
        {
            Product product = new Product();
            try
            {
                conn = ConnectionFactory.getConnection();
                string sql = "select * from produtos where id = ?";
                
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();  // recebe o conteúdo que vem do banco
                reader.Read();

                product.setId(reader.GetInt16(0));
                product.setName(reader.GetString(1));
                product.setManufacturer(reader.GetString(2));
                product.setCategory(reader.GetString(3));
                product.setPrice(reader.GetFloat(4));
                product.setAmount(reader.GetInt32(5));
            }
            catch (MySqlException error)
            {
                throw new ProductException(error.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return product;
        }


        private string getMessage(string caso)  // método privado de impressão de caso processado
        {
            string message = "";
            switch (caso)
            {
                case "ERRO":
                    message = "PRODUCT REMOVED SUCCESSFULLY.";
                    break;
                case "INSERTED":
                    message = "PRODUCT INSERTED SUCCESFULLY.";
                    break;
                case "CHANGED":
                    message = "PRODUCT CHANGED SUCCESFULLY.";
                    break;
            }

            return message;
        }


        public void getProductMessage(Product product)  // método privado (receber mensagem do produto - imprime dados do produto para o usuário)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ID {product.getId()} | NAME {product.getName()} | MANUFACTURER {product.getManufacturer()} | " +
                $"CATEGORY {product.getCategory()} | PRICE {product.getPrice()} | AMOUNT {product.getAmount()}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
