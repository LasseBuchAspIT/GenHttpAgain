using WebToSipDBLib;
using Microsoft.EntityFrameworkCore;
using GenHTTP.Modules.Webservices;

namespace GenHttpAgain
{
    public class Service
    {

        [ResourceMethod("GetQuickBtns")]
        public async Task<List<QuickBtn>> GetQuickBtn()
        {
            WebToSipDbContext context = new(StaticString.ConnectionString);
            try
            {
                User user = context.Users.FirstOrDefault();
                return await GetQuickBtns(user);
            }
            catch
            {
                return new();
            }
        }

        private async Task<List<QuickBtn>> GetQuickBtns(User user)
        {
            WebToSipDbContext context = new(StaticString.ConnectionString);

            var tmp = new List<QuickBtn>();
            tmp = await context.QuickBtns.Where(a => a.User == user).ToListAsync();

            return tmp;
        }
    }
}
