using System.Collections.Generic;

public interface IRepository<TModel> where TModel : class
{
    List<TModel> BuscarTodos();
    TModel Buscar(int id);
    void Incluir(TModel obj);
    void Excluir(TModel obj);
    void Alterar(TModel obj);
}