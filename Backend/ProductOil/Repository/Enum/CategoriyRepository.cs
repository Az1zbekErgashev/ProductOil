using Microsoft.EntityFrameworkCore;
using ProductOil.Data;
using ProductOil.Dto;
using ProductOil.Enitiy;

namespace ProductOil.Repository.Enum
{
    public class CategoriyRepository : ICategoriyRepository
    {
        private readonly AppDbContext context;
        public CategoriyRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Categoriy> CreateAsync(CategoriyDto categoriyDto)
        {
            var getCategory = await context.Categoriys
            .Include(i => i.OilCompany).Include(i => i.Clients).Include(i => i.Locations).Include(i => i.FeedBack).Include(i => i.OilProducts).Include(i => i.OilNews).Include(i => i.BenefitOil).Include(i => i.NeftekorCertifieds).Include(i => i.Exmples).FirstOrDefaultAsync(i => i.Id == categoriyDto.Id);

            if (getCategory is null)
            {
                var newCategory = new Categoriy
                {
                    Name = categoriyDto.Name,
                    BenefitOil = new List<BenefitOil>(),
                    Clients = new List<Client>(),
                    Locations = new List<Location>(),
                    NeftekorCertifieds = new List<NeftekorCertified>(),
                    OilCompany = new List<OilCompany>(),
                    OilNews = new List<OilNews>(),
                    FeedBack = new List<FeedBack>(),
                    Exmples = new List<Exemples>(),
                    OilProducts = new List<OilProduct>(),
                    PathUrl = categoriyDto.PathUrl,
                };

                var getBenefitOil = await context.BenefitOil.FirstOrDefaultAsync(x => x.Id == categoriyDto.BenefitOilId);
                var getClients = await context.Client.FirstOrDefaultAsync(x => x.Id == categoriyDto.ClientsId);
                var getLocations = await context.Location.FirstOrDefaultAsync(x => x.Id == categoriyDto.LocationsId);
                var getNeftekorCertifieds = await context.NeftekorCertified.FirstOrDefaultAsync(x => x.Id == categoriyDto.NeftekorCertifiedsId);
                var getOilCompany = await context.OilCompany.FirstOrDefaultAsync(x => x.Id == categoriyDto.OilCompanyId);
                var getOilNews = await context.OilNews.FirstOrDefaultAsync(x => x.Id == categoriyDto.OilNewsId);
                var getFeedBack = await context.FeedBack.FirstOrDefaultAsync(x => x.Id == categoriyDto.FeedBackId);
                var getExmples = await context.Exemples.FirstOrDefaultAsync(x => x.Id == categoriyDto.ExmplesId);
                var getOilProducts = await context.OilProduct.FirstOrDefaultAsync(x => x.Id == categoriyDto.OilProductsId);

                if (getBenefitOil != null)
                {
                    newCategory.BenefitOil.Add(getBenefitOil);
                    context.Categoriys.Add(newCategory);
                    await context.SaveChangesAsync();
                    return newCategory;
                }
                if (getClients != null)
                {
                    newCategory.Clients.Add(getClients);
                    context.Categoriys.Add(newCategory);
                    await context.SaveChangesAsync();
                    return newCategory;
                }
                if (getLocations != null)
                {
                    newCategory.Locations.Add(getLocations);
                    context.Categoriys.Add(newCategory);
                    await context.SaveChangesAsync();
                    return newCategory;
                }
                if (getNeftekorCertifieds != null)
                {
                    newCategory.NeftekorCertifieds.Add(getNeftekorCertifieds);
                    context.Categoriys.Add(newCategory);
                    await context.SaveChangesAsync();
                    return newCategory;
                }
                if (getOilCompany != null)
                {
                    newCategory.OilCompany.Add(getOilCompany);
                    context.Categoriys.Add(newCategory);
                    await context.SaveChangesAsync();
                    return newCategory;
                }
                if (getOilNews != null)
                {
                    newCategory.OilNews.Add(getOilNews);
                    context.Categoriys.Add(newCategory);
                    await context.SaveChangesAsync();
                    return newCategory;
                }
                if (getFeedBack != null)
                {
                    newCategory.FeedBack.Add(getFeedBack);
                    context.Categoriys.Add(newCategory);
                    await context.SaveChangesAsync();
                    return newCategory;
                }
                if (getExmples != null)
                {
                    newCategory.Exmples.Add(getExmples);
                    context.Categoriys.Add(newCategory);
                    await context.SaveChangesAsync();
                    return newCategory;
                }
                if (getOilProducts != null)
                {
                    newCategory.OilProducts.Add(getOilProducts);
                    context.Categoriys.Add(newCategory);
                    await context.SaveChangesAsync();
                    return newCategory;
                }
            }

            return getCategory;
        }

        public async Task DeleteAsync(int id)
        {
            var getCategory = await context.Categoriys.FirstOrDefaultAsync(x => x.Id == id);
            if (getCategory is not null)
            {
                context.Categoriys.Remove(getCategory);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Categoriy>> GetAllAsync() => await context.Categoriys.ToListAsync();

        public async Task<Categoriy> GetByIdAsync(int id)
        {
            var cur = await context.Categoriys.Include(i => i.OilCompany).Include(i => i.Clients).Include(i => i.Locations).Include(i => i.FeedBack).Include(i => i.OilProducts).Include(i => i.OilNews).Include(i => i.BenefitOil).Include(i => i.NeftekorCertifieds).Include(i => i.Exmples).FirstOrDefaultAsync(i => i.Id == id);
            return cur;
        }

        public async Task<Categoriy> UpdateAsync(int id, CategoriyDto categoriyDto)
        {
            var getItem = await context.Categoriys.FirstOrDefaultAsync(x => x.Id == id);
            if (getItem is not null)
            {
                getItem.Id = categoriyDto.Id;
                context.Entry(getItem).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return getItem;
            }
            return getItem;
        }
    }
}
