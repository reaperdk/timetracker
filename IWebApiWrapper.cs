public interface IWebApiWrapper<T> where T : class, IModelBase
    {
        /// <summary>
        /// Gets entity by his id from database via WebApi
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns>T-type entity if found, otherwise null</returns>
        /// <exception cref="ArgumentException">Thrown when id is less or equal zero</exception>
        T Get(int id);
        TResult Get<TResult>(int id) where TResult : class, IModelBase;

        /// <summary>
        /// Gets list of entities of T-type from database via WebApi
        /// </summary>
        /// <returns>List of T-type entities if found, otherwise empty list</returns>
        IEnumerable<T> Get();
        IEnumerable<TResult> Get<TResult>() where TResult : class, IModelBase;

        /// <summary>
        /// Gets list of entities of T-type from database via WebApi with a specified http request
        /// </summary>
        /// <param name="httpRequest">Specified http request</param>
        /// <returns>List of T-type entities if found, otherwise empty list</returns>
        /// <exception cref="ArgumentException">Thrown when httpRequest is null or empty</exception>
        IEnumerable<T> Get(string httpRequest);
        IEnumerable<TResult> Get<TResult>(string httpRequest) where TResult : class, IModelBase;

        /// <summary>
        /// Adds new entity to database via WebApi
        /// </summary>
        /// <param name="entity">Entity to add to database</param>
        /// <returns>List of T-type entities if found, otherwise empty list</returns>
        /// <exception cref="ArgumentException">Thrown when entity is null</exception>
        T Add(T entity);

        /// <summary>
        /// Adds new entity to database via WebApi with a specified http request 
        /// </summary>
        /// <param name="httpRequest">Specified http request</param>
        /// <param name="data">Entity to add to database</param>
        /// <exception cref="ArgumentNullException">Thrown when data is null</exception>
        /// <exception cref="ArgumentException">Thrown when httpRequest is null or empty</exception>
        void Add(string httpRequest, object data);

        /// <summary>
        /// Updates entity in database via WebApi with a specified http request
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>T-type entity if updated, otherwise empty list</returns>
        /// <exception cref="ArgumentNullException">Thrown when data is null</exception>
        T Update(T entity);

        /// <summary>
        /// Deletes T-type entity by its id from database via WebApi
        /// </summary>
        /// <param name="id">Id of </param>
        /// <exception cref="ArgumentException">Thrown when id is less or equal zero</exception>
        void Delete(int id);
    }