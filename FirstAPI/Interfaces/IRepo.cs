namespace FirstAPI.Interfaces
{
    public interface IRepo<K,T>:IBaseRepo<K,T>
    {
        Task<T> Update(T item);
        Task<T> Delete(K key);
        Task<ICollection<T>> GetAll();
    }
}
