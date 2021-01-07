using System;

namespace Happy.Weddings.Gateway.Core.Config.ECommerce
{
    public class ECommerceServiceOperation
    {
        /// <summary>
        /// The base URL
        /// </summary>
        const string baseUrl = "/api/v1/E-Commerce-Management";

        /// <summary>
        /// The service name
        /// </summary>
        public static string serviceName = "ECommerceService";

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns></returns>
        public static string GetHealth() => $"/hc";

        #region MultiCode

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <returns></returns>
        public static string GetAllMultiCodes() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string GetMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        /// <summary>
        /// Creates the Multicode.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiCode() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Updates the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string UpdateMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        /// <summary>
        /// Deletes the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string DeleteMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        #endregion

        #region MultiDetail

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <returns></returns>
        public static string GetAllMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="multicodeId">The Multicode identifier.</param>
        /// <returns></returns>
        public static string GetMultiDetailsById(int multicodeId) => $"{baseUrl}/multidetails/{multicodeId}";

        /// <summary>
        /// Creates the Multidetail.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Updates the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        public static string UpdateMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        /// <summary>
        /// Deletes the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        public static string DeleteMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        #endregion

        /// <summary>
        /// Deletes the cart.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        public static string DeleteCart(int cartId) => $"{baseUrl}/carts/{cartId}";


        /// <summary>
        /// Gets the cart by identifier.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        public static string GetCartById(int cartId) => $"{baseUrl}/carts/{cartId}";


        /// <summary>
        /// Gets the cart by identifier.
        /// </summary>
        /// <param name="userId">The cart identifier.</param>
        /// <returns></returns>
        public static string GetCartByUserId(int userId) => $"{baseUrl}/carts/TotPrice/{userId}";

        /// <summary>
        /// Updates the cart.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        public static string UpdateCart(int cartId) => $"{baseUrl}/carts/{cartId}";

        /// <summary>
        /// Creates the cart.
        /// </summary>
        /// <returns></returns>
        public static string CreateCart() => $"{baseUrl}/carts";


        /// <summary>
        /// Gets the carts.
        /// </summary>
        /// <returns></returns>
        public static string GetCarts() => $"{baseUrl}/carts";

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <returns></returns>
        public static string CreateProduct() => $"{baseUrl}/products";

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public static string DeleteProduct(int productId) => $"{baseUrl}/products/{productId}";

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public static string GetProductById(int productId) => $"{baseUrl}/products/{productId}";

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public static string UpdateProduct(int productId) => $"{baseUrl}/products/{productId}";


        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public static string GetProducts() => $"{baseUrl}/products";




        /// <summary>
        /// Creates the productquantity.
        /// </summary>
        /// <returns></returns>
        public static string CreateProductquantity() => $"{baseUrl}/productquantity";

        /// <summary>
        /// Deletes the productquantity.
        /// </summary>
        /// <param name="productquantityId">The productquantity identifier.</param>
        /// <returns></returns>
        public static string DeleteProductquantity(int productquantityId) => $"{baseUrl}/productquantity/{productquantityId}";

        /// <summary>
        /// Gets the productquantity by identifier.
        /// </summary>
        /// <param name="productquantityId">The productquantity identifier.</param>
        /// <returns></returns>
        public static string GetProductquantityById(int productquantityId) => $"{baseUrl}/productquantity/{productquantityId}";

        /// <summary>
        /// Updates the productquantity.
        /// </summary>
        /// <param name="productquantityId">The productquantity identifier.</param>
        /// <returns></returns>
        public static string UpdateProductquantity(int productquantityId) => $"{baseUrl}/productquantity/{productquantityId}";

        /// <summary>
        /// Gets the productquantitys.
        /// </summary>
        /// <returns></returns>
        public static string GetProductQuantities() => $"{baseUrl}/productquantity";

        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <returns></returns>
        public static string CreateOrder() => $"{baseUrl}/orders";

        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public static string DeleteOrder(int orderId) => $"{baseUrl}/orders/{orderId}";

        /// <summary>
        /// Gets the order by identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public static string GetOrderById(int orderId) => $"{baseUrl}/orders/{orderId}";

        /// <summary>
        /// Updates the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public static string UpdateOrder(int orderId) => $"{baseUrl}/orders/{orderId}";

        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <returns></returns>
        public static string GetOrders() => $"{baseUrl}/orders";

        /// <summary>
        /// Gets the orderlocations.
        /// </summary>
        /// <returns></returns>
        public static string GetOrderlocations() => $"{baseUrl}/orderlocations";

        /// <summary>
        /// Creates the orderlocation.
        /// </summary>
        /// <returns></returns>
        public static string CreateOrderlocation() => $"{baseUrl}/orderlocations";

        /// <summary>
        /// Deletes the orderlocation.
        /// </summary>
        /// <param name="orderlocationId">The orderlocation identifier.</param>
        /// <returns></returns>
        public static string DeleteOrderlocation(int orderlocationId) => $"{baseUrl}/orderlocations/{orderlocationId}";

        /// <summary>
        /// Gets the orderlocation by identifier.
        /// </summary>
        /// <param name="orderlocationId">The orderlocation identifier.</param>
        /// <returns></returns>
        public static string GetOrderlocationById(int orderlocationId) => $"{baseUrl}/orderlocations/{orderlocationId}";

        /// <summary>
        /// Updates the orderlocation.
        /// </summary>
        /// <param name="orderlocationId">The orderlocation identifier.</param>
        /// <returns></returns>
        public static string UpdateOrderlocation(int orderlocationId) => $"{baseUrl}/orderlocations/{orderlocationId}";

        /// <summary>
        /// Gets the orderreturns.
        /// </summary>
        /// <returns></returns>
        public static string GetOrderreturns() => $"{baseUrl}/orderreturns";

        /// <summary>
        /// Creates the orderreturn.
        /// </summary>
        /// <returns></returns>
        public static string CreateOrderreturn() => $"{baseUrl}/orderreturns";

        /// <summary>
        /// Deletes the orderreturn.
        /// </summary>
        /// <param name="orderreturnId">The orderreturn identifier.</param>
        /// <returns></returns>
        public static string DeleteOrderreturn(int orderreturnId) => $"{baseUrl}/orderreturns/{orderreturnId}";

        /// <summary>
        /// Gets the orderreturn by identifier.
        /// </summary>
        /// <param name="orderreturnId">The orderreturn identifier.</param>
        /// <returns></returns>
        public static string GetOrderreturnById(int orderreturnId) => $"{baseUrl}/orderreturns/{orderreturnId}";

        /// <summary>
        /// Updates the orderreturn.
        /// </summary>
        /// <param name="orderreturnId">The orderreturn identifier.</param>
        /// <returns></returns>
        public static string UpdateOrderreturn(int orderreturnId) => $"{baseUrl}/orderreturns/{orderreturnId}";


        /// <summary>
        /// Gets the registry.
        /// </summary>
        /// <returns></returns>
        public static string GetRegistry() => $"{baseUrl}/registry";

        /// <summary>
        /// Creates the registry.
        /// </summary>
        /// <returns></returns>
        public static string CreateRegistry() => $"{baseUrl}/registry";

        /// <summary>
        /// Deletes the registry.
        /// </summary>
        /// <param name="registryId">The registry identifier.</param>
        /// <returns></returns>
        public static string DeleteRegistry(int registryId) => $"{baseUrl}/registry/{registryId}";

        /// <summary>
        /// Gets the registry by identifier.
        /// </summary>
        /// <param name="registryId">The registry identifier.</param>
        /// <returns></returns>
        public static string GetRegistryById(int registryId) => $"{baseUrl}/registry/{registryId}";

        /// <summary>
        /// Updates the registry.
        /// </summary>
        /// <param name="registryId">The registry identifier.</param>
        /// <returns></returns>
        public static string UpdateRegistry(int registryId) => $"{baseUrl}/registry/{registryId}";


    }
}
