namespace SolutionTestTaskFromMansur.Models.DataBaseModels.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        TKey Id { get; set; }
    }
}
