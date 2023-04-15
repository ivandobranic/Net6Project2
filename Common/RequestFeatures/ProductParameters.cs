namespace Common.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        #region Properties

        public Guid? ProductCategoryId { get; set; }

        public bool? IsActive { get; set; }

        #endregion Properties
    }
}