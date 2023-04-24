﻿namespace Common.DataTransferObjects.Product
{
    public record ProductDto(Guid Id, string Name, decimal Price, Guid ProductCategoryId, ProductCategoryDto ProductCategory);
}