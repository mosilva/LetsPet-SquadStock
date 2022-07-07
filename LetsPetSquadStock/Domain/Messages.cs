using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public static class Messages
    {
        public const string categorySelectionMenu = @"Selecione a categoria de produto 
1 - Shampoo
2 - Condicionador
3 - Perfume
";

        public const string usageSelectionMenu = @"Qual o tipo de uso do produto: 
1 - Geral
2 - Especial
";

        public const string speciesSelectionMenu = @"Para qual tipo de espécie o produto é indicado:
1 - Cachorro
2 - Gato
";

        public const string reportSelectionMenu = @"Selecione sua alternativa:
1 - Relatório por nome de produto
2 - Relatório por tipo de produto
3 - Relatório por marca

Ou pressione ENTER para o relatório com todos os produtos.";

        public const string reportTypeMenu = @"Selecione sua alternativa:
1 - Shampoo
2 - Condicionador
3 - Perfume
4 - Todas as categorias";

        public const string menuProductTest = @"1 - Novo Produto
2 - Ver estoque 
3 - Retirar Produto
4 - Relatório de Estoque"
;

        public const string defaultStockMenu = @"Opções de produtos:
1 - Cadastro de Produtos 
2 - Relatório de Estoque 
3 - Voltar ao menu anterior";             

        public const string inputName = "Qual o nome do produto? ";

        public const string inputBrand = "Qual a marca do produto? ";

        public const string inputQuantity = "Quantos produtos serão cadastrados?";

        public const string inputPrice = "Qual o preço do produto? ";

        public const string inputTotalVolume = "Qual o tamanho do produto em ml? ";

        public const string inputExpirationDate = "Qual a data de validade do produto? ";        

        public const string invalidNullInput = @"Não é possível inserir um valor em branco, tente novamente!";

        public const string formatError = @"Entrada inválida, tente novamente!";        

        public const string reportNameMenu = "Digite o nome do produto desejado: ";

        public const string reportBrandMenu = "Digite a marca do produto desejado: ";

        public const string invalidQuantity = "Quantidade inválida, tente novamente!";

        public const string returnEntryKey = "Digite qualquer tecla para retornar ao menu inicial ";

        public const string maxedOutQuantity = "Não é possível cadastrar mais produtos desse tipo, gostaria de tentar cadastrar um produto de outra categoria? (Sim/Não)";
                     
        public const string productNotFound = "Não existem produtos cadastrados que correspondem às características solicitadas.";

        public const string sucessfullNewProductRegistry = "Produto cadastrado com sucesso!";

        public const string listOfProducts = @"Lista de produtos disponíveis do tipo 
";

        public const string noProductsAvailable = @"Não existem produtos disponíveis do tipo 
";
        public const string headerNewProductRegistry = @"-------------------- Cadastro de Produto --------------------
";

        public const string headerNewReport = @"-------------------- Relatórios --------------------
";

        public const string headerStock = @"-------------------- Estoque Let's Pet --------------------
";

        public const string productStock = @"Produto aberto!E tem quantidade suficiente
";

        public const string productNotEnoughStock = @"Produto aberto!Mas sem quantidade suficiente para banho
";

        public const string productOpenStock = @"Foi aberto um novo produto
";

        public const string serviceNotRegistered = @"Serviço não cadastrado no sistema
";

        public const string animalNotRegistered = @"Animal não cadastrado no sistema
";


        public const string lackOfProduct = @"Não tem produto disponível pra esse serviço! É necessário comprar mais!
";
    }
}
