namespace Common.RequestFeatures
{
    public abstract class RequestParameters
    {
        #region Fields

        private const int maxPageSize = 50;
        private int _pageSize = 10;

        #endregion Fields

        #region Properties

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        #endregion Properties
    }
}