using WebApp.Model;

namespace WebApp.Data
{
    public interface ICustomizationRepository
    {
        Task<List<Addition>> GetAllAdditionsAsync();
        Task<Addition> GetAdditionByIdAsync(long additionId);
        Task<bool> AddAdditionAsync(Addition addition);
        Task<bool> UpdateAdditionAsync(Addition addition);
        Task<bool> DeleteAdditionAsync(long additionId);
        Task<List<Cake>> GetAllCakesAsync();
        Task<Cake> GetCakeByIdAsync(long cakeId);
        Task<bool> AddCakeAsync(Cake cake);
        Task<bool> UpdateCakeAsync(Cake cake);
        Task<bool> DeleteCakeAsync(long cakeId);
        Task<List<Filling>> GetAllFillingsAsync();
        Task<Filling> GetFillingByIdAsync(long fillingId);
        Task<bool> AddFillingAsync(Filling filling);
        Task<bool> UpdateFillingAsync(Filling filling);
        Task<bool> DeleteFillingAsync(long fillingId);
        Task<List<Glaze>> GetAllGlazesAsync();
        Task<Glaze> GetGlazeByIdAsync(long glazeId);
        Task<bool> AddGlazeAsync(Glaze glaze);
        Task<bool> UpdateGlazeAsync(Glaze glaze);
        Task<bool> DeleteGlazeAsync(long glazeId);
        Task<List<Size>> GetAllSizesAsync();
        Task<Size> GetSizeByIdAsync(long sizeId);
        Task<bool> AddSizeAsync(Size size);
        Task<bool> UpdateSizeAsync(Size size);
        Task<bool> DeleteSizeAsync(long sizeId);
    }
}
