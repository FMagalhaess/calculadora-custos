using calculadora_custos.Models;
using calculadora_custos.Results;

namespace calculadora_custos.Services.Calculation;

public interface ICalculeItens
{
    /// <summary>
    /// Calcula custo total de algo quando se passa uma lista de ids de X tabela e uma lista de
    /// quantidade de itens para cada id, seguindo a ordem: listaId[0] será calculado com quantidade[0]
    /// assim por diante
    /// </summary>
    /// <param name="listOfItensId"> Lista de inteiros contendo os ids dos itens</param>
    /// <param name="listOfItensQuantity">Lista de quantidade de cada item a ser calculado</param>
    /// <returns>Retorna estrutura Result! Caso o calculo seja bem sucedido retornara uma estrutura
    /// contendo "IsSuccess" contendo "true" e "data" que será do tipo da estrutura passada, contendo o resultado, caso acontece algum erro
    /// no processo, retornará "IsSuccess" contendo false e um campo "Error" do tipo string com o erro! </returns>
    Result<decimal> CalculateCosts(List<int> listOfItensId, List<decimal> listOfItensQuantity);

    Result<decimal> CalculatePercentage(decimal cost, decimal sellPrice);

    Result<decimal> CalculteDefaultCost(Ingredient ingredient);
}