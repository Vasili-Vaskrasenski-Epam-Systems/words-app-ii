using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace WordsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController: ControllerBase
    {
        private IDatabaseContext _dbContext;

        public WordsController(IDatabaseContext context)
        {

        }
    }
}
