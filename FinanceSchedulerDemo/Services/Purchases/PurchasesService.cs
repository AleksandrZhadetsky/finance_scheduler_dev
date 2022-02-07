using DAL.DataAccess;
using Domain.Purchases;
using System;
using System.Threading.Tasks;

namespace Services.Purchases
{
    public class PurchasesService
    {
        private readonly AuthDbContext context;

        public PurchasesService(AuthDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Method for retrieving specific purchase.
        /// </summary>
        /// <param name="id"> Model of type <see cref="string"/>. </param>
        /// <returns> Entity of type <see cref="Purchase"/>. </returns>
        public ValueTask<Purchase> GetPurchaseAsync(string id)
        {
            var purchase = context.Purchases.FindAsync(id);

            return purchase;
        }

        /// <summary>
        /// Method for creating the purchase.
        /// </summary>
        /// <param name="purchase"> Model of type <see cref="Purchase"/>. </param>
        /// <returns> Entity of type <see cref="Purchase"/>. </returns>
        public async ValueTask<Purchase> CreatePurchaseAsync(Purchase purchase)
        {
            purchase.RegistrationDate = DateTime.Now;
            var createdPurchase = await context.Purchases.AddAsync(purchase);
            await context.SaveChangesAsync();

            return createdPurchase.Entity;
        }

        /// <summary>
        /// Method for deleting specific purchase.
        /// </summary>
        /// <param name="id"> Model of type <see cref="string"/>. </param>
        /// <returns></returns>
        public async ValueTask DeletePurchaseAsync(string id)
        {
            var purchase = await context.Purchases.FindAsync(id);
            context.Purchases.Remove(purchase);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Method for updating specific purchase.
        /// </summary>
        /// <param name="purchase"> Model of type <see cref="Purchase"/>. </param>
        /// <returns> Entity of type <see cref="Purchase"/>. </returns>
        public async ValueTask<Purchase> UpdatePurchaseAsync(Purchase purchase)
        {
            var updatedCategory = context.Purchases.Update(purchase);
            await context.SaveChangesAsync();

            return updatedCategory.Entity;
        }
    }
}
