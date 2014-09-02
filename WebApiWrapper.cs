public class WebApiWrapper<T> : IWebApiWrapper<T> where T : class, IModelBase
    {
        private const string BASE_ADDRESS = @"http://localhost:8888/api/";

        private readonly string address;

        private readonly IHttpDataProvider httpDataProvider;

        private static readonly ILog logger = LogManager.GetLogger(typeof(WebApiWrapper<T>));

        public WebApiWrapper(IHttpDataProvider httpDataProvider)
        {
            var controllerName = typeof(T).GetControllerProperName();

            address = String.Concat(BASE_ADDRESS, controllerName, @"/");

            httpDataProvider.MediaTypeWithQualityHeader = "application/json";

            this.httpDataProvider = httpDataProvider;
        }

        public T Get(int id)
        {
            var result = GetJson(address + id);

            return result == null ? null : JsonConvert.DeserializeObject<T>(result);
        }

        public TResult Get<TResult>(int id) where TResult : class, IModelBase
        {
            var result = GetJson(address + id);

            return result == null ? null : JsonConvert.DeserializeObject<TResult>(result);
        }

        public IEnumerable<T> Get()
        {
            var result = GetJson(address);

            return result == null ? new List<T>() : JsonConvert.DeserializeObject<IEnumerable<T>>(result);
        }

        public IEnumerable<TResult> Get<TResult>() where TResult : class, IModelBase
        {
            var result = GetJson(address);

            return result == null ? new List<TResult>() : JsonConvert.DeserializeObject<IEnumerable<TResult>>(result);
        }

        public IEnumerable<T> Get(string httpRequest)
        {
            var result = GetJson(String.Concat(address, "Get", httpRequest));

            return result == null ? new List<T>() : JsonConvert.DeserializeObject<IEnumerable<T>>(result);
        }

        public IEnumerable<TResult> Get<TResult>(string httpRequest) where TResult : class, IModelBase
        {
            Guard.NotNullOrEmpty(httpRequest);

            var result = GetJson(String.Concat(address, "Get", httpRequest));

            return result == null ? new List<TResult>() : JsonConvert.DeserializeObject<IEnumerable<TResult>>(result);
        }

        public T Add(T entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            var result = PostJson(address, json);

            return result == null ? null : JsonConvert.DeserializeObject<T>(result);
        }

        public void Add(string httpRequest, object data)
        {
            var json = JsonConvert.SerializeObject(data);

            PutJson(String.Concat(address, "Put", httpRequest), json);
        }

        public T Update(T entity)
        {
            try
            {
                var json = JsonConvert.SerializeObject(entity);
                string result = PutJson(string.Format(CultureInfo.InvariantCulture, @"{0}{1}", address, entity.Id), json);

                return result == null ? null : JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        public void Delete(int id)
        {
            Delete(String.Concat(address, id));
        }

        private string GetJson(string request)
        {
            try
            {
                return httpDataProvider.Get(request);
            }
            catch (ArgumentException e)
            {
                logger.Error("Argument null exception while using httpDataProvider.Get.", e);
                return null;
            }
        }

        private string PostJson(string request, string json)
        {
            try
            {
                return httpDataProvider.Post(request, json);
            }
            catch (ArgumentException e)
            {
                logger.Error("Argument null exception while using httpDataProvider.Post.", e);
                return null;
            }
        }

        private string PutJson(string request, string json)
        {
            try
            {
                return httpDataProvider.Put(request, json);
            }
            catch (ArgumentException e)
            {
                logger.Error("Argument null exception while using httpDataProvider.Put.", e);
                return null;
            }
        }

        private void Delete(string request)
        {
            try
            {
                httpDataProvider.Delete(request);
            }
            catch (ArgumentException e)
            {
                logger.Error("Argument null exception while using httpDataProvider.Delete.", e);
            }
        }
    }