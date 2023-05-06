namespace FirstAPI.Interfaces
{
    public interface IBaseRepo<K,T>
    {
        Task<T> Add(T item);
        Task<T> Get(K key);
    }
}
