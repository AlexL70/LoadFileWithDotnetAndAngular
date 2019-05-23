using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoadFiles.Core;
using LoadFiles.Core.Models;
using LoadFiles.Core.Models.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LoadFiles.Controllers
{
    // [Route ("api/[controller]")]
    [Route("api/[controller]")]
    public class MyUsersController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public MyUsersController(
            IUserRepository repository,
            IMapper mapper
        )
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAll() {
            var users = await _repository.GetAll();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        }
    }
}