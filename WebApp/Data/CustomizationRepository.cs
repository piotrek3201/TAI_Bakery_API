using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Data
{
    public class CustomizationRepository : ICustomizationRepository
    {
        private readonly AppDBContext db;

        public CustomizationRepository(AppDBContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAdditionAsync(Addition addition)
        {
            try
            {
                await db.Additions.AddAsync(addition);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddCakeAsync(Cake cake)
        {
            try
            {
                await db.Cakes.AddAsync(cake);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddFillingAsync(Filling filling)
        {
            try
            {
                await db.Fillings.AddAsync(filling);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddGlazeAsync(Glaze glaze)
        {
            try
            {
                await db.Glazes.AddAsync(glaze);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddSizeAsync(Size size)
        {
            try
            {
                await db.Sizes.AddAsync(size);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAdditionAsync(long additionId)
        {
            try
            {
                var additionToDelete = await GetAdditionByIdAsync(additionId);
                db.Additions.Remove(additionToDelete);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCakeAsync(long cakeId)
        {
            try
            {
                var cakeToDelete = await GetCakeByIdAsync(cakeId);
                db.Cakes.Remove(cakeToDelete);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteFillingAsync(long fillingId)
        {
            try
            {
                var fillingToDelete = await GetFillingByIdAsync(fillingId);
                db.Fillings.Remove(fillingToDelete);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteGlazeAsync(long glazeId)
        {
            try
            {
                var glazeToDelete = await GetGlazeByIdAsync(glazeId);
                db.Glazes.Remove(glazeToDelete);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSizeAsync(long sizeId)
        {
            try
            {
                var sizeToDelete = await GetSizeByIdAsync(sizeId);
                db.Sizes.Remove(sizeToDelete);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Addition> GetAdditionByIdAsync(long additionId)
        {
            return await db.Additions.FirstOrDefaultAsync(x => x.AdditionId == additionId);
        }

        public async Task<List<Addition>> GetAllAdditionsAsync()
        {
            return await db.Additions.ToListAsync();
        }

        public async Task<List<Cake>> GetAllCakesAsync()
        {
            return await db.Cakes.ToListAsync();
        }

        public async Task<List<Filling>> GetAllFillingsAsync()
        {
            return await db.Fillings.ToListAsync();
        }

        public async Task<List<Glaze>> GetAllGlazesAsync()
        {
            return await db.Glazes.ToListAsync();
        }

        public async Task<List<Size>> GetAllSizesAsync()
        {
            return await db.Sizes.ToListAsync();
        }

        public async Task<Cake> GetCakeByIdAsync(long cakeId)
        {
            return await db.Cakes.FirstOrDefaultAsync(x => x.CakeId == cakeId);
        }

        public async Task<Filling> GetFillingByIdAsync(long fillingId)
        {
            return await db.Fillings.FirstOrDefaultAsync(x => x.FillingId == fillingId);
        }

        public async Task<Glaze> GetGlazeByIdAsync(long glazeId)
        {
            return await db.Glazes.FirstOrDefaultAsync(x => x.GlazeId == glazeId);
        }

        public async Task<Size> GetSizeByIdAsync(long sizeId)
        {
            return await db.Sizes.FirstOrDefaultAsync(x => x.SizeId == sizeId);
        }

        public async Task<bool> UpdateAdditionAsync(Addition addition)
        {
            try
            {
                db.Additions.Update(addition);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCakeAsync(Cake cake)
        {
            try
            {
                db.Cakes.Update(cake);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateFillingAsync(Filling filling)
        {
            try
            {
                db.Fillings.Update(filling);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateGlazeAsync(Glaze glaze)
        {
            try
            {
                db.Glazes.Update(glaze);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateSizeAsync(Size size)
        {
            try
            {
                db.Sizes.Update(size);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
